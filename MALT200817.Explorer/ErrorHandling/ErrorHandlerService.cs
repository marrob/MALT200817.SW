﻿
namespace MALT200817.Explorer.ErrorHandling
{
    using System;
    using System.Text;
    using System.Windows.Forms;
    using System.Net.Mail;

    public class ErrorHandlerService
    {

        public string Show(System.UnhandledExceptionEventArgs args)
        {
           return Show(args.ExceptionObject as Exception);
        }

        public string  Show(System.Threading.ThreadExceptionEventArgs args)
        {
            var ex = args.Exception;
            return Show(ex);
        }

        public string Show(Exception ex)
        {
            var form = new ErrorHandlingForm();

            string exceptionType = ex.GetType().ToString();
            string message = ex.Message;
            string clr = Environment.Version.ToString();
            string application = Application.ProductName + " [" + Application.ProductVersion + "]";
            string targetSite = ex.TargetSite.ToString();
            string timestamp = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

            form.ExceptionType = exceptionType;
            form.Message = ex.Message;
            form.CLR = clr;
            form.Application = application;
            form.TargetSite = targetSite;
            form.ExceptionObj = ex;
            form.DateTime = timestamp;
            form.ShowDialog();

            string report = string.Empty;
            report += "ExceptionType: " + exceptionType + "\r\n";
            report += "Message:" + message + "\r\n";
            report += "CLR:" + clr + "\r\n";
            report += "Appliction:" + application + "\r\n";
            report += "TargetSite:" + targetSite + "\r\n";
            report += "Timestamp:" + timestamp + "\r\n";
            report += "UserComment:" + form.UserComment + "\r\n";
            report += "/*************************************************/\r\n";
            report += "Stack Trace:" + ex.StackTrace;

            if (form.SendReport == true)
            {
                SendReport(application, report);
            }

            form.SendReport = false;

            return report;
        }

        void SendReport(string subject, string body)
        {
            var progress = new ErrorHandlingProgressDialog();
            progress.Comment = "Report Sending... Please Wait...";
            progress.AllowCancel = true;
            progress.Show();

 
            SmtpClient client = new SmtpClient();
            try
            {
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 20000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("konvolucio.report@gmail.com", "konvolucio.a0832d");
                var mm = new MailMessage("donotreply.report@konvolucio.com", "konvolucio.report@gmail.com", subject, body);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.None;
                client.SendAsync(mm, null);
            }
            catch (Exception ex)
            {
                progress.Comment = ex.Message;
                MessageBox.Show("Cant send report..." + ex.Message);
                progress.End();
            }

            client.SendCompleted += (o, e) =>
                {
                    if (e.Cancelled)
                    {
                        progress.Comment = "Cancelled by User...";
                    }
                    else if (e.Error != null)
                    {
                        MessageBox.Show("Cant send report..." + e.Error.Message);
                        progress.Comment = e.Error.Message;
                    }
                    else
                    {
                        progress.Comment = "Complete";
                    }
                    progress.End();
                };

            progress.UserCanceled += (o1, e1) =>
                {
                    client.SendAsyncCancel();
                };
        }
    }
}