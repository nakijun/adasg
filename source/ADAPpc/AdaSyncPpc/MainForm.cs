using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Data.SqlServerCe;
using UtilitiesPpc;
using System.IO;
using System.Reflection;
using System.Data.Common;
using System.Diagnostics;
using Microsoft.WindowsMobile.Status;
using AdaSyncPpc.ADAMobileDataSetTableAdapters;
using Microsoft.Win32;
using System.Net;

namespace AdaSyncPpc
{
    public partial class MainForm : AdaBaseForm
    {
        private const string REGISTRY_SYMBOL_LIBRARY_SYNC_TIME = "SymbolSync";
        private const string REGISTRY_SCHEDULE_SYNC_TIME = "ScheduleSync";
        private const string REGISTRY_COMMUNICATOR_SYNC_TIME = "CommunicatorSync";
        private const string REGISTRY_DEVICE_ID = "DeviceID";
        private const string REGISTRY_AUTO_SYNC_ENABLED = "AutoSync";

        private bool _synchronized;
        private string _deviceID;
        private string _databaseFilePath;
        private bool _autoSyncEnabled;
        private string _publisher;
        private string _internetUrl;
        private bool _connectionAvailable;

        private SystemState _connectionsCount;
        private SystemState _connectionsCount2;
        private SystemState _cradlePresent;
        private SystemState _cradlePresent2;

        public MainForm(bool autoSync)
        {
            InitializeComponent();

            string fullyQualifiedName = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            string strAppDir = Path.GetDirectoryName(fullyQualifiedName);
            _databaseFilePath = strAppDir + "\\ADAMobile.sdf";

            FileInfo fileInfo = new FileInfo(_databaseFilePath);
            if (fileInfo.Exists)
            {
                DateTime d = fileInfo.LastWriteTime;
                this.labelModifiedTime.Text = d.ToShortDateString() + " " + d.ToShortTimeString();
            }

            _autoSyncEnabled = true;

            object autoSyncEnabled = this.Setting.LocalSetting.GetValue(REGISTRY_AUTO_SYNC_ENABLED, null);

            if (autoSyncEnabled != null)
            {
                _autoSyncEnabled = bool.Parse(autoSyncEnabled.ToString());
            }

            _connectionsCount = new SystemState(SystemProperty.ConnectionsCount);

            _connectionsCount.ComparisonType = StatusComparisonType.GreaterOrEqual;
            _connectionsCount.ComparisonValue = 1;

            _connectionsCount2 = new SystemState(SystemProperty.ConnectionsCount);
            _connectionsCount2.Changed += new ChangeEventHandler(connectionsCount_Changed);

            _cradlePresent = new SystemState(SystemProperty.CradlePresent);
            _cradlePresent.ComparisonType = StatusComparisonType.GreaterOrEqual;
            _cradlePresent.ComparisonValue = 1;

            _cradlePresent2 = new SystemState(SystemProperty.CradlePresent);
            _cradlePresent2.Changed += new ChangeEventHandler(connectionsCount_Changed);

            SetupApplicationLauncher();

            if (autoSync)
            {
                this.timerAutoSync.Enabled = true;
            }

            object syncTimeValue = this.Setting.LocalSetting.GetValue(REGISTRY_SYMBOL_LIBRARY_SYNC_TIME, null) as string;
            if (syncTimeValue != null)
            {
                DateTime d = Convert.ToDateTime(syncTimeValue);
            }

            syncTimeValue = this.Setting.LocalSetting.GetValue(REGISTRY_SCHEDULE_SYNC_TIME, null) as string;
            if (syncTimeValue != null)
            {
                DateTime d = Convert.ToDateTime(syncTimeValue);
            }

            syncTimeValue = this.Setting.LocalSetting.GetValue(REGISTRY_COMMUNICATOR_SYNC_TIME, null) as string;
            if (syncTimeValue != null)
            {
                DateTime d = Convert.ToDateTime(syncTimeValue);
                this.labelSyncTime.Text = d.ToShortDateString() + " " + d.ToShortTimeString();
            }

            this._deviceID = this.Setting.GlobalSetting.GetValue(REGISTRY_DEVICE_ID, null) as string;

            if (this._deviceID == null)
            {
                try
                {
                    this._deviceID = DeviceID.GetDeviceID();
                    this.Setting.GlobalSetting.SetValue(REGISTRY_DEVICE_ID, this._deviceID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            _publisher = (string)Setting.LocalSetting.GetValue("Server", "WIN2003");
            _internetUrl = string.Format("http://{0}/ADA/sqlcesa30.dll", _publisher);
        }

        private void SetupApplicationLauncher()
        {
            if (_autoSyncEnabled)
            {
                string fullyQualifiedName = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
                _connectionsCount.EnableApplicationLauncher("ADASync", fullyQualifiedName, "-EVENT");
                _cradlePresent.EnableApplicationLauncher("ADASync", fullyQualifiedName, "-EVENT");
            }
            else
            {
                _connectionsCount.DisableApplicationLauncher();
                _cradlePresent.DisableApplicationLauncher();
            }

            menuItemAutoSync.Checked = _autoSyncEnabled;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(_databaseFilePath))
            {
                menuItemSymbolExplorer.Enabled = false;
            }

            connectionsCount_Changed(sender, null);
        }

        void connectionsCount_Changed(object sender, ChangeEventArgs args)
        {
            checkConnection();

            if (args != null && _connectionAvailable &&
                _autoSyncEnabled && !_synchronized)
            {
                this.Synchronize();
            }
        }

        private bool Synchronize()
        {
            return Synchronize(false);
        }

        private bool SynchronizeSubscription(string subsriptionName, bool reinitializeSubscription, string registryKey, Label label)
        {
            bool result = false;

            Cursor.Current = Cursors.WaitCursor;

            SqlCeReplication repl = null;
            try
            {
                PerformanceSampling.StartSample(0, "Synchronization time");
                repl = new SqlCeReplication();

                repl.Publisher = _publisher;
                repl.InternetUrl = _internetUrl;

                this.textBoxStatus.Text += "Synchronizing " + subsriptionName + " data with " + repl.Publisher + " ...\r\n";
                this.textBoxStatus.Update();

                repl.PublisherDatabase = @"ADA";
                repl.PublisherSecurityMode = SecurityType.DBAuthentication;
                repl.PublisherLogin = @"ada";
                repl.PublisherPassword = @"p@ssw0rd";

                repl.Publication = subsriptionName;
                repl.Subscriber = subsriptionName;
                repl.SubscriberConnectionString = ("Data Source ="
                        + (_databaseFilePath)
                        + (";Password =" + "\"\";"));
                repl.HostName = _deviceID;

                if (!File.Exists(_databaseFilePath))
                {
                    repl.AddSubscription(AddOption.CreateDatabase);
                }

                if (reinitializeSubscription)
                {
                    repl.ReinitializeSubscription(false);
                }

                repl.Synchronize();

                PerformanceSampling.StopSample(0);

                DateTime now = System.DateTime.Now;
                label.Text = now.ToShortDateString() + " " + now.ToShortTimeString();
                label.Update();
                this.Setting.LocalSetting.SetValue(registryKey, now);

                this.textBoxStatus.Text += "Successful!\r\n" + PerformanceSampling.GetSampleDurationText(0) + "\r\n";
                result = true;
            }
            catch (SqlCeException sqlex)
            {
                this.textBoxStatus.Text += "Failed! \r\n";
                foreach (SqlCeError sqlError in sqlex.Errors)
                {
                    this.textBoxStatus.Text += "Error messages:" + sqlError.Message + "\r\n";
                    this.textBoxStatus.Text += "Native error:" + sqlError.NativeError + "\r\n";
                }
            }
            catch (Exception ex)
            {
                this.textBoxStatus.Text += "Failed! Error messages:\r\n" + ex.Message + "\r\n";
            }
            finally
            {
                if (repl != null)
                {
                    repl.Dispose();
                }
            }

            Cursor.Current = Cursors.Default;

            return result;
        }

        private void menuItemSync_Click(object sender, EventArgs e)
        {
            this.Synchronize();
        }

        private void timerAutoSync_Tick(object sender, EventArgs e)
        {
            this.timerAutoSync.Enabled = false;

            if (_connectionAvailable)
            {
                if (this.Synchronize())
                {
                    this.Update();
                    Thread.Sleep(2000);
                    Exit();
                }
            }
        }

        private void menuItemSymbolExplorer_Click(object sender, EventArgs e)
        {
            try
            {
                SymbolExplorer symbolExploerer = new SymbolExplorer(this.CultureName);
                SymbolInfo selectedSymbol = symbolExploerer.BrowseSymbol();

                if (selectedSymbol != null)
                {
                    SymbolDetailForm symbolDetailForm = new SymbolDetailForm();
                    symbolDetailForm.Symbol = selectedSymbol;
                    symbolDetailForm.ShowDialog();
                }
            }
            catch (SqlCeException sqlex)
            {
                this.textBoxStatus.Text = "Failed! Error messages:\r\n";
                foreach (SqlCeError sqlError in sqlex.Errors)
                {
                    this.textBoxStatus.Text += sqlError.Message;
                }
            }
            catch (Exception ex)
            {
                this.textBoxStatus.Text = "Failed! Error messages:\n" + ex.Message;
            }
        }

        private void menuItemReinitialize_Click(object sender, EventArgs e)
        {
            if (File.Exists(_databaseFilePath))
            {
                File.Delete(_databaseFilePath);
            }

            this.menuItemReinitialize.Enabled = File.Exists(_databaseFilePath);
        }

        private bool Synchronize(bool reinitializeSubscription)
        {
            bool result = false;
            this.textBoxStatus.Text = "";

            if (SynchronizeSubscription("Symbol", reinitializeSubscription, REGISTRY_SYMBOL_LIBRARY_SYNC_TIME, this.labelSyncTime))
            {
                if (SynchronizeSubscription("Schedule", reinitializeSubscription, REGISTRY_SCHEDULE_SYNC_TIME, this.labelSyncTime))
                {
                    result = SynchronizeSubscription("Communicator", reinitializeSubscription, REGISTRY_COMMUNICATOR_SYNC_TIME, this.labelSyncTime);
                }
            }

            menuItemSymbolExplorer.Enabled = File.Exists(_databaseFilePath);

            if (!_synchronized && result)
            {
                _synchronized = true; ;
            }

            return result;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            if (this.IsDeployed)
            {
                LoadMainForm();
            }
            else
            {
                Close();
            }
        }

        private void menuItemCheckConnection_Click(object sender, EventArgs e)
        {
            checkConnection();
        }

        private void checkConnection()
        {
            Cursor.Current = Cursors.WaitCursor;

            _connectionAvailable = false;
            this.textBoxStatus.Text = "";

#if DEBUG
            this.textBoxStatus.Text += (SystemState.CradlePresent ? "Cradle Connected" : "Cradle Disconnected") + "\r\n";

            this.textBoxStatus.Text += "ConnectionsCount = " + SystemState.ConnectionsCount + "\r\n";

            this.textBoxStatus.Text += "ConnectionsDesktopCount = " + SystemState.ConnectionsDesktopCount + "\r\n";
            this.textBoxStatus.Text += "ConnectionsDesktopDescriptions = " + SystemState.ConnectionsDesktopDescriptions + "\r\n";

            this.textBoxStatus.Text += "ConnectionsNetworkAdapters = " + SystemState.ConnectionsNetworkAdapters + "\r\n";
            this.textBoxStatus.Text += "ConnectionsNetworkCount = " + SystemState.ConnectionsNetworkCount + "\r\n";
            this.textBoxStatus.Text += "ConnectionsNetworkDescriptions = " + SystemState.ConnectionsNetworkDescriptions + "\r\n";

            this.textBoxStatus.Text += "ConnectionsBluetoothCount = " + SystemState.ConnectionsBluetoothCount + "\r\n";
            this.textBoxStatus.Text += "ConnectionsBluetoothDescriptions = " + SystemState.ConnectionsBluetoothDescriptions + "\r\n";
#endif
            if (SystemState.ConnectionsCount > 0 || SystemState.CradlePresent)
            {
                try
                {
                    WebRequest req = WebRequest.Create(_internetUrl);
                    WebResponse result = req.GetResponse();
#if DEBUG
                    Stream ReceiveStream = result.GetResponseStream();
                    Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                    StreamReader sr = new StreamReader(ReceiveStream, encode);

                    // Read the stream into arrays of 30 characters
                    // to add as items in the list box. Repeat until
                    // buffer is read.
                    Char[] read = new Char[30];
                    int count = sr.Read(read, 0, 30);
                    while (count > 0)
                    {
                        String str = new String(read, 0, count);
                        this.textBoxStatus.Text += str;
                        count = sr.Read(read, 0, 30);
                    }

                    this.textBoxStatus.Text += "\r\n";
#endif
                    _connectionAvailable = true;
                }
                catch (WebException ex)
                {
                    string message = ex.Message;
                    HttpWebResponse response = (HttpWebResponse)ex.Response;
                    if (null != response)
                    {
                        message = response.StatusDescription;
                        response.Close();
                    }
#if DEBUG
                    this.textBoxStatus.Text += message + "\r\n";
#endif
                }
                catch (Exception ex)
                {
#if DEBUG
                    this.textBoxStatus.Text += ex.Message + "\r\n";
#endif
                }
            }

            this.textBoxStatus.Text += string.Format("Connection to server {0} is {1}",
                _publisher,
                _connectionAvailable ? "available" : "unavailable");

            this.menuItemSync.Enabled = _connectionAvailable;
            this.menuItemReinitialize.Enabled = File.Exists(_databaseFilePath);
            this.menuItemSyncSymbol.Enabled = _connectionAvailable;
            this.menuItemSyncSchedule.Enabled = _connectionAvailable;
            this.menuItemSyncCommunicator.Enabled = _connectionAvailable;

            Cursor.Current = Cursors.Default;
        }

        private void menuItemSyncSymbol_Click(object sender, EventArgs e)
        {
            SynchronizeSubscription("Symbol", false, REGISTRY_SYMBOL_LIBRARY_SYNC_TIME, this.labelSyncTime);
        }

        private void menuItemSyncSchedule_Click(object sender, EventArgs e)
        {
            SynchronizeSubscription("Schedule", false, REGISTRY_SCHEDULE_SYNC_TIME, this.labelSyncTime);
        }

        private void menuItemSyncCommunicator_Click(object sender, EventArgs e)
        {
            SynchronizeSubscription("Communicator", false, REGISTRY_COMMUNICATOR_SYNC_TIME, this.labelSyncTime);
        }

        private void menuItemAutoSync_Click(object sender, EventArgs e)
        {
            _autoSyncEnabled = !_autoSyncEnabled;
            this.Setting.LocalSetting.SetValue(REGISTRY_AUTO_SYNC_ENABLED, _autoSyncEnabled.ToString());
            SetupApplicationLauncher();
        }
    }
}