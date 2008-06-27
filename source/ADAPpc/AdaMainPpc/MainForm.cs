using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using UtilitiesPpc;
using System.Globalization;
using Microsoft.Win32;
using Microsoft.WindowsMobile.Status;

namespace AdaMainPpc
{
    public partial class MainForm : AdaBaseForm
    {
        private static string USING_DFTTS_MALE_VOICE = "MaleVoice";

        private static string[] ADA_APPLICATIONS = new string[] 
        {
            "AdaSchedulePpc.exe", 
            "AdaWorkSystemPpc.exe", 
            "AdaCommunicatorPpc.exe", 
            "AdaTimerPpc.exe", 
            "AdaSyncPpc.exe", 
            "AdaMoneyPpc.exe" 
        };

        private Process[] _childProcesses = new Process[] 
        {
            null, 
            null, 
            null, 
            null, 
            null, 
            null, 
        };

        private string _appDir;
        private bool _maleVoice;

        public MainForm()
        {
            InitializeComponent();

            string maleVoice = this.Setting.GlobalSetting.GetValue(USING_DFTTS_MALE_VOICE, null) as string;
            if (maleVoice != null)
            {
                _maleVoice = bool.Parse(maleVoice);
            }

            menuItemMaleVoice.Enabled = IsVoiceAvailable(true);
            menuItemFemailVoice.Enabled = IsVoiceAvailable(false);

            if (!IsVoiceAvailable(_maleVoice))
            {
                _maleVoice = !_maleVoice;
            }

            SetVoice(_maleVoice);

            this.listBox2App.Items.Add(this.listBox2ItemSchedule);
            this.listBox2App.Items.Add(this.listBox2ItemWorkSystem);
            this.listBox2App.Items.Add(this.listBox2ItemCommunicator);
            this.listBox2App.Items.Add(this.listBox2ItemTimer);
            //this.listBox2App.Items.Add(this.listItemSync);
            //this.listBox2App.Items.Add(this.listBox2ItemMoney);

            this.listBox2App.SelectedIndex = 0;

            string application = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            this._appDir = Path.GetDirectoryName(application) + "\\";

            for (int i = 0; i < ADA_APPLICATIONS.Length; i++)
            {
                try
                {
                    if (ADA_APPLICATIONS[i] == Program.LaunchFrom)
                    {
                        _childProcesses[i] = AttachProcess(ADA_APPLICATIONS[i]);
                        break;
                    }
                }
                catch
                {
                }
            }
        }

        private Process AttachProcess(string applicationName)
        {
            int processId = (int)this.Setting.GlobalSetting.GetValue(applicationName, null);
            return Process.GetProcessById(processId);
        }

        protected override void OnCultureChanged(CultureInfo newCulture)
        {
            global::AdaMainPpc.Properties.Resources.Culture = newCulture;

            this.listBox2ItemSchedule.Text = global::AdaMainPpc.Properties.Resources.Schedule;
            this.listBox2ItemWorkSystem.Text = global::AdaMainPpc.Properties.Resources.WorkSystem;
            this.listBox2ItemCommunicator.Text = global::AdaMainPpc.Properties.Resources.Communicator;
            this.listBox2ItemTimer.Text = global::AdaMainPpc.Properties.Resources.Timer;
        }

        private void OpenApplication(int index)
        {
            if (_childProcesses[index] != null && !_childProcesses[index].HasExited)
            {
                FormEngine.BringMainWindowToTop(_childProcesses[index]);
            }
            else
            {
                string applicationName = ADA_APPLICATIONS[index];
                string arguments = "ADA";

                try
                {
                    _childProcesses[index] = Process.Start(this._appDir + applicationName, arguments);

                    if (!IsBigMemory)
                    {
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        private void CloseAllApplications()
        {
            for (int i = 0; i < _childProcesses.Length; i++)
            {
                Process process = _childProcesses[i];
                _childProcesses[i] = null;

                try
                {
                    if (process != null && !process.HasExited)
                    {
                        process.Kill();
                    }
                }
                catch
                {
                }
            }
        }

        private void listBox2App_Click(object sender, EventArgs e)
        {
            this.RunSelectedApplication();
        }

        private void listBox2App_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.RunSelectedApplication();
            }
        }

        private void RunSelectedApplication()
        {
            int selectedAppIndex = this.listBox2App.SelectedIndex;

            if (selectedAppIndex >= 0 && selectedAppIndex < ADA_APPLICATIONS.Length)
            {
                this.OpenApplication(selectedAppIndex);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.menuItemSimplifiedChinese.Enabled = FormLanguageSwitchSingleton.Instance.IsCultureSupported(SIMPLIFIED_CHINESE_CULTURE);
            this.menuItemTraditionalChinese.Enabled = FormLanguageSwitchSingleton.Instance.IsCultureSupported(TRADITIONAL_CHINESE_CULTURE);

            this.CultureChanged();
        }

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
        }

        private void menuItemRun_Click(object sender, EventArgs e)
        {
            this.RunSelectedApplication();
            //FormEngine.SetFullScreen(this);
        }

        private void CultureChanged()
        {
            if (this.CultureName == SIMPLIFIED_CHINESE_CULTURE)
            {
                this.menuItemEnglish.Checked = false;
                this.menuItemSimplifiedChinese.Checked = true;
                this.menuItemTraditionalChinese.Checked = false;
            }
            else if (this.CultureName == TRADITIONAL_CHINESE_CULTURE)
            {
                this.menuItemEnglish.Checked = false;
                this.menuItemSimplifiedChinese.Checked = false;
                this.menuItemTraditionalChinese.Checked = true;
            }
            else
            {
                this.menuItemEnglish.Checked = true;
                this.menuItemSimplifiedChinese.Checked = false;
                this.menuItemTraditionalChinese.Checked = false;
            }
        }

        private void menuItemEnglish_Click(object sender, EventArgs e)
        {
            this.ChangeCulture(ENGLISH_CULTURE);
            this.CultureChanged();
        }

        private void menuItemSimplifiedChinese_Click(object sender, EventArgs e)
        {
            this.ChangeCulture(SIMPLIFIED_CHINESE_CULTURE);
            this.CultureChanged();
        }

        private void menuItemTraditionalChinese_Click(object sender, EventArgs e)
        {
            this.ChangeCulture(TRADITIONAL_CHINESE_CULTURE);
            this.CultureChanged();
        }

        private void menuItemAdvanced_Click(object sender, EventArgs e)
        {
            ConfirmForm f = new ConfirmForm();

            if (!IsDeployed || f.ShowDialog() == DialogResult.OK)
            {
                this.OpenApplication(4);
            }
        }

        private void menuItemMaleVoice_Click(object sender, EventArgs e)
        {
            SetVoice(true);
        }

        private void menuItemFemailVoice_Click(object sender, EventArgs e)
        {
            SetVoice(false);
        }

        private bool IsVoiceAvailable(bool maleVoice)
        {
            string fullyQualifiedName = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            string strProgramFilesDir = Path.GetDirectoryName(Path.GetDirectoryName(fullyQualifiedName));

            string sNeoSpeechDBFolderPath;
            if (maleVoice)
            {
                sNeoSpeechDBFolderPath = strProgramFilesDir + "\\DFTTS_Male\\Paul32M\\";
            }
            else
            {
                sNeoSpeechDBFolderPath = strProgramFilesDir + "\\DFTTS\\Kate32M\\";
            }

            string dllFileName;

            dllFileName = "dfttsmobile.dll";
            return File.Exists(sNeoSpeechDBFolderPath + dllFileName);
        }

        private void SetVoice(bool maleVoice)
        {
            if (maleVoice != _maleVoice)
            {
                ConfirmForm f = new ConfirmForm();
                f.Text = "Sure to change voice?";

                if (!IsDeployed || f.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CloseAllApplications();

                    try
                    {
                        string fullyQualifiedName = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
                        string strProgramFilesDir = Path.GetDirectoryName(Path.GetDirectoryName(fullyQualifiedName));

                        string sNeoSpeechDBFolderPath;
                        if (maleVoice)
                        {
                            sNeoSpeechDBFolderPath = strProgramFilesDir + "\\DFTTS_Male\\Paul32M\\";
                        }
                        else
                        {
                            sNeoSpeechDBFolderPath = strProgramFilesDir + "\\DFTTS\\Kate32M\\";
                        }

                        string dllFileName;

                        dllFileName = "dfttsmobile.dll";
                        File.Copy(sNeoSpeechDBFolderPath + dllFileName, _appDir + dllFileName, true);

                        dllFileName = "swift.dll";
                        File.Copy(sNeoSpeechDBFolderPath + dllFileName, _appDir + dllFileName, true);

                        dllFileName = "vt_eng.dll";
                        File.Copy(sNeoSpeechDBFolderPath + dllFileName, _appDir + dllFileName, true);

                        _maleVoice = maleVoice;
                        this.Setting.GlobalSetting.SetValue(USING_DFTTS_MALE_VOICE, _maleVoice);
                    }
                    catch (Exception ex)
                    {
                        ReportError(ex);
                    }

                    Cursor.Current = Cursors.Default;
                }
            }

            menuItemMaleVoice.Checked = _maleVoice;
            menuItemFemailVoice.Checked = !_maleVoice;
        }

        private void ReportError(Exception ex)
        {
            string statusMessage = ex.Message.ToString() + "\r\n" + ex.StackTrace;

            MessageBox.Show(statusMessage, this.Text);
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            ConfirmForm f = new ConfirmForm();
            f.Text = "Sure to exit?";

            if (!IsDeployed || f.ShowDialog() == DialogResult.OK)
            {
                CloseAllApplications();
                Close();
            }
        }

    }
}