using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MALT200817.Checklist
{
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

    class App
    {
        MainFrom _mainForm;

        List<ICheckItem> m_checkList = new List<ICheckItem>()
            {
                new Check_00_OsVer(),
                new Check_01_NetFramework(),
                new Check_02_Max(),
                new Check_03_LabView(),
                new Check_04_Xnet(),
                new Check_05_TestStand(),
                new Check_06_ConfigFile(),
                new Check_07_XnetCanBusInterfaceType(),
                new Check_08_XnetDevice(),
                new Check_09_XnetIfaceName(),
                new Check_10_ServiceInstalled(),
                new Check_11_ServiceRunning()
            };

        public App()
        {
            _mainForm = new MainFrom();

            _mainForm.Shown += MainForm_Shown;
            _mainForm.Reset += MainForm_Reset;

             var x  =  Tools.IsApplicationInstalled("Notepad++");



            Application.Run(_mainForm);
        }



        private void MainForm_Reset(object sender, EventArgs e)
        {

            foreach (ICheckItem item in m_checkList)
            {
                item.Result = "még dolgozom... kérlek várj...";
                item.Status = ResultStatusType.Unknown;
            }

            foreach (ICheckItem item in m_checkList)
            {
                item.Dispose();
            }

            foreach (ICheckItem item in m_checkList)
            {
                try
                {
                    item.Process();
                }
                catch (Exception ex)
                {
                    item.Result = "Az értékelés során hibatörtént..." + ex.Message;
                    item.Status = ResultStatusType.Failed;
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {

            var controls = new List<Control>();
            int i = 0;
            foreach (ICheckItem item in m_checkList)
            {
                var ctrlItem = new CheckItemControl();
                ctrlItem.Index = i++.ToString() + ".";
                controls.Add(ctrlItem);
                ctrlItem.Update(item);
                _mainForm.AddCheckItem(ctrlItem);
            }


            foreach (ICheckItem item in m_checkList)
            {
                try
                {
                    item.Process();
                }
                catch (Exception ex)
                {
                    item.Result = "Az értékelés során hibatörtént..." + ex.Message;
                    item.Status = ResultStatusType.Failed;
                }
            }


        }


    }
}
