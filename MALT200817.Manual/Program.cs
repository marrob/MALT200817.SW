using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALT200817.Manual.Open
{
    class Program
    {
        static void Main(string[] args)
        {
           string docPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\AltonTech\\MaltManual";

            new App().Check(docPath);


        }
    }




    /*
     * Ha nem létezik a manual.config.xml, akkor létrehozza a default értékekkel
     */
    class App {

        /// <summary>
        /// Ha nem létezik a config.xml, akkor first start
        /// </summary>

        public void Check(string path) {

            if (!System.IO.File.Exists(path + "\\config.xml"))
                FirstStart(path);
            else
            {
                //Read config.xml
             
                Run(path);
            }
        }


        /// <summary>
        /// config.xml, akkor létrehozza a default értékekkel
        /// </summary>
        void FirstStart(string path) {
        
        
        }
        /// <summary>
        /// Futtatja
        /// </summary>
        void Run(string path) {
            //https://stackoverflow.com/questions/6305388/how-to-launch-a-google-chrome-tab-with-specific-url-using-c-sharp/14913755#14913755
            try
            {
                var myProcess = new Process();
                myProcess.StartInfo.FileName = "Chrome";
                myProcess.StartInfo.Arguments = "\"" + path + "\\index.html" + "\"";
                myProcess.Start();
            }
            catch (Exception ex)
            {
                //Edge Chromium
                var myProcess = new Process();
                myProcess.StartInfo.FileName = @"microsoft-edge:" + path + "\\index.html";
                myProcess.Start();

            }

        }
    }


    public class Manual
    {
        int version;

        public Manual()
        {

        }
    }
}
