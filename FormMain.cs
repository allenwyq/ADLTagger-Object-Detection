using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace ObjDet
{
    public partial class FormMain : Form
    {
        private string PythonInterpreterPath;
        private string PythonFilePath;

        private string inputfolder;
        private string outputfolder;

        private string PythonInputPath;
        private string PythonOutputPath;
        //private string PythonModelPath;

        public FormMain()
        {
            InitializeComponent();
        }

        // Python Interpreter button
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the selected Python interpreter path
                    PythonInterpreterPath = openFileDialog.FileName;
                }
            }
        }

        // MMD.py file browse button
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Python files (*.py)|*.py|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the selected Python file path
                    PythonFilePath = openFileDialog.FileName;
                }
            }
        }

        // Button to change input path
        private void ButtonIn_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    inputfolder = folderBrowserDialog.SelectedPath;
                }
            }

            // Read the Python file into a string
            string inputpath = File.ReadAllText(PythonFilePath);

            // Modify the path within the string using string manipulation techniques
            // For example, you can use the string.Replace method to replace the old path with the new path
            inputpath = inputpath.Replace("Input\\data50", inputfolder);

            // Write the modified string back to the Python file
            File.WriteAllText(PythonFilePath, inputpath);

        }
        
        
        // Button to change output path
        private void ButtonOut_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    outputfolder = folderBrowserDialog.SelectedPath;
                }
            }

            // Read the Python file into a string
            string outputpath = File.ReadAllText(PythonFilePath);

            // Modify the path within the string using string manipulation techniques
            // For example, you can use the string.Replace method to replace the old path with the new path
            outputpath = outputpath.Replace("Output", outputfolder);

            // Write the modified string back to the Python file
            File.WriteAllText(PythonFilePath, outputpath);

        }




        // Run Object Detection button
        private void ButtonObject_Click_1(object sender, EventArgs e)
        {
            // Set path to Python file
            //string pythonFilePath = @"C:\Users\allen\Desktop\ObjDet\ObjDet\bin\Debug\net7.0-windows\MMD.py";

            // Create a new ProcessStartInfo object with the appropriate properties
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = PythonInterpreterPath,
                Arguments = PythonFilePath,
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