using System;
using System.IO;
using System.Diagnostics;

namespace ObjDet
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonObject_Click_1(object sender, EventArgs e)
        {
            // Set path to Python interpreter and path to Python file
            string pythonInterpreterPath = @"C:\Users\allen\.conda\envs\mmd\python.exe";
            string pythonFilePath = @"C:\Users\allen\Desktop\ObjDet\ObjDet\bin\Debug\net7.0-windows\MMD.py";

            // Create a new ProcessStartInfo object with the appropriate properties
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = pythonInterpreterPath,
                Arguments = pythonFilePath,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            Process process = Process.Start(startInfo);
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            FormObject formObject = new ObjDet.FormObject();
            formObject.ShowDialog();
        }
    }
}