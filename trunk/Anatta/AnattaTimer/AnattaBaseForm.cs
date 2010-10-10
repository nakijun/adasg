using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.WindowsMobile.Status;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace AnattaTimer
{
    public partial class AnattaBaseForm : Form
    {
        public const string ENGLISH_CULTURE = "en";
        public const string SIMPLIFIED_CHINESE_CULTURE = "zh-CHS";
        public const string TRADITIONAL_CHINESE_CULTURE = "zh-CHT";

        private const string REGISTRY_LANGUAGE = "Language";
        private const string REGISTRY_IS_DEPLOYED = "IsDeployed";
        private const string REGISTRY_IS_BIG_MEMORY = "IsBigMemory";

        private RegistrySetting _setting;

        private RegistryState _languageRegistryState;

        public RegistrySetting Setting
        {
            get { return _setting; }
            set { _setting = value; }
        }

        private bool _isDeployed;

        public bool IsDeployed
        {
            get { return _isDeployed; }
        }

        private bool _isBigMemory;

        public bool IsBigMemory
        {
            get { return _isBigMemory; }
        }

        public AnattaBaseForm()
        {
            InitializeComponent();

            this._setting = new RegistrySetting();

            this._languageRegistryState = new RegistryState(@"HKEY_LOCAL_MACHINE\SOFTWARE\Inflaton\Anatta", REGISTRY_LANGUAGE);
            this._languageRegistryState.Changed += new ChangeEventHandler(languageRegistryState_Changed);

            this._isDeployed = false;

            object o = this._setting.GlobalSetting.GetValue(REGISTRY_IS_DEPLOYED);
            if (o != null)
            {
                this._isDeployed = Convert.ToBoolean(o);
            }

            this._isBigMemory = true;

            o = this._setting.GlobalSetting.GetValue(REGISTRY_IS_BIG_MEMORY);
            if (o != null)
            {
                this._isBigMemory = Convert.ToBoolean(o);
            }
        }

        void languageRegistryState_Changed(object sender, ChangeEventArgs args)
        {
            string cultureName = _languageRegistryState.CurrentValue as string;
        }

        private void AnattaBaseForm_Load(object sender, EventArgs e)
        {
            if (!IsBigMemory && ControlBox && MinimizeBox)
            {
                MinimizeBox = false;
            }

            if (this.GetType().Name == "MainForm")
            {
                string applicationName = AppDomain.CurrentDomain.FriendlyName;
                Process currentProcess = Process.GetCurrentProcess();
                this.Setting.GlobalSetting.SetValue(applicationName, currentProcess.Id);
            }
        }

        private void AnattaBaseForm_Closed(object sender, EventArgs e)
        {
            LoadMainForm();
        }

        protected void LoadMainForm()
        {
            if (this.IsDeployed && this.GetType().Name == "MainForm")
            {
                string mainWindowName = "Anatta Main";

                if (this.Text != mainWindowName)
                {
                    string application = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
                    string mainApp = Path.GetDirectoryName(application) + "\\AnattaMainPpc.exe";

                    FormEngine.BringWindowToTop(mainWindowName, mainApp);
                }
            }
        }

        private void AnattaBaseForm_GotFocus(object sender, EventArgs e)
        {
            if (this.IsDeployed)
            {
                FormEngine.SetFullScreen(this);
            }
        }

        private void AnattaBaseForm_LostFocus(object sender, EventArgs e)
        {

        }

        private void AnattaBaseForm_Deactivate(object sender, EventArgs e)
        {

        }
    }
}