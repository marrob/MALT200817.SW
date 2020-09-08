﻿

namespace MALT200817.Explorer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    using Common;
    using View;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading;
    using Events;
    using Properties;
    using Client;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new App();
        }
    }


    public interface IApp
    {

    }

    class App
    {
        readonly IMainForm _mainForm;
        readonly DevicePresenter _devicePresenter;
        readonly DeviceCollection _devices;
        public static SynchronizationContext SyncContext = null;

        public App()
        {
            /*** Application Configuration ***/
            if (!File.Exists(AppConstants.AppConfigurationFilePath))
            {
                AppConfiguration.SaveToFile(AppConstants.AppConfigurationFilePath);
                new ApplicationException("Set the ConfigurationFile! " + AppConstants.AppConfigurationFilePath);
            }
            else
            {
                AppConfiguration.LoadFromFile(AppConstants.AppConfigurationFilePath);
            }
            AppLog.Instance.FilePath = AppConfiguration.Instance.AppLogPath;
            AppLog.Instance.Enabled = AppConfiguration.Instance.AppLogEnabled;
            AppLog.Instance.WriteLine("App()");

            /*** Main Form ***/
            _mainForm = new MainForm();
            _mainForm.Text = AppConstants.SoftwareTitle + " - " + Application.ProductVersion;
            _mainForm.Shown += MainForm_Shown;
            _mainForm.FormClosing += MainForm_FormClosing;
            _mainForm.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);

            /*** MALT TCP Client ***/
            

            _devices = new DeviceCollection();
            _devicePresenter = new DevicePresenter(_mainForm.DevicesDgv, _devices);

            /*** Run ***/
            Application.Run((MainForm)_mainForm);
        }


        void MainForm_Shown(object sender, EventArgs e)
        {
#if TRACE
            AppLog.Instance.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");
#endif

            SyncContext = SynchronizationContext.Current;
            // _mainForm.LayoutRestore();

            //_mainForm.LayoutRestore();
            /*Ö tölti be a projectet*/
            Start(Environment.GetCommandLineArgs());
            /*Kezdő Node Legyen az Adapter node*/
            //EventAggregator.Instance.Publish<TreeViewSelectionChangedAppEvent>(new TreeViewSelectionChangedAppEvent(_startTreeNode));

            EventAggregator.Instance.Publish(new ShowAppEvent());

            // if (Settings.Default.PlayAfterStartUp)
            //_ioService.Play();
        }

        public void Start(string[] args)
        {
#if TRACE
            AppLog.Instance.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + ": " + string.Join("\r\n -", args));
#endif

            MaltClient.Instance.Start("", 9999);

            foreach (DeviceItem dev in MaltClient.Instance.GetDevices())
            {
                _devices.Add(dev);
            }

            _devicePresenter.Update();
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
#if TRACE
            AppLog.Instance.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");
#endif
        }



        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
#if TRACE
            AppLog.Instance.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");
#endif
            MaltClient.Instance.Dispose();

            //TimerService.Instance.Dispose();
            //  _ioService.Dispose();
            //   _mainForm.LayoutSave();
            Settings.Default.Save();
            EventAggregator.Instance.Dispose();
            Settings.Default.Save();
        }

    }
}