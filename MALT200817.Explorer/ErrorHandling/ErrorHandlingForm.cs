﻿

namespace MALT200817.Explorer.ErrorHandling
{
    using System;
    using System.Windows.Forms;

    public interface IErrorHandlingForm
    {
        string ExceptionType { get; set; }
        string Message { get; set; }
        string TargetSite { get; set; }
        string Application { get; set; }
        string CLR { get; set; }
        string DateTime { get; set; }
        Exception ExceptionObj { get; set; }
        string UserComment { get; set; }
        bool SendReport { get; set; }
        DialogResult ShowDialog();
    }

    public partial class ErrorHandlingForm : Form, IErrorHandlingForm
    {
        public string ExceptionType
        {
            get { return textBoxExceptionType.Text; }
            set { textBoxExceptionType.Text = value; }
        }
        public string Message 
        {
            get { return textBoxMessage.Text; }
            set { textBoxMessage.Text = value; }
        }
        public string TargetSite
        {
            get
            {
                return textBoxTargetSite.Text;
            }
            set
            {
                textBoxTargetSite.Text = value;
            }
        }
        public string Application
        {
            get
            {
                return textBoxApplication.Text;
            }
            set
            {
                textBoxApplication.Text = value;
            }
        }
        public string CLR
        {
            get
            {
                return textBoxClr.Text;
            }
            set
            {
                textBoxClr.Text = value;
            }
        }
        public string DateTime
        {
            get
            {
                return textBoxDateTime.Text;
            }
            set
            {
                textBoxDateTime.Text = value;
            }
        }
        public Exception ExceptionObj
        {
            get { return propertyGrid1.SelectedObject as Exception; }
            set { propertyGrid1.SelectedObject = value; }
        }
        public string UserComment
        {
            get { return textBoxUserComment.Text; }
            set { textBoxUserComment.Text = value; }
        }
        public bool SendReport { get;  set; }

        public ErrorHandlingForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SendReport = false;
            this.Close();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendReport = true;
            this.Close();
        }
    }
}
