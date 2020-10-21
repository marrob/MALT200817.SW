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

        List<ICheckItem> _checkList = new List<ICheckItem>()
            {
                new Check_00_NetFramework(),
                new Check_01_Max(),
                new Check_02_LabView(),
                new Check_03_Xnet(),
                new Check_04_TestStand(),
                new Check_05_ConfigFile(),
                new Check_06_XnetCanBusInterfaceType(),
                new Check_07_XnetDevice(),
                new Check_08_XnetIfaceName(),
                new Check_09_ServiceInstalled(),
                new Check_10_ServiceRunning()
            };

        public App()
        {
            _mainForm = new MainFrom();

            _mainForm.Shown += MainForm_Shown;
            _mainForm.Reset += MainForm_Reset;
 

            Application.Run(_mainForm);
        }



        private void MainForm_Reset(object sender, EventArgs e)
        {
            foreach (ICheckItem item in _checkList)
            {
                item.Dispose();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
 

            List<Control> controls = new List<Control>();

            foreach (ICheckItem item in _checkList)
            {
                var ctrlItem = new CheckItemControl();
                controls.Add(ctrlItem);
                ctrlItem.Update(item);
                _mainForm.AddCheckItem(ctrlItem);

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
