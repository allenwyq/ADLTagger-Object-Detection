namespace ObjDet
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonObject = new System.Windows.Forms.Button();
            this.ButtonPythonInterpreter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ButtonIn = new System.Windows.Forms.Button();
            this.ButtonOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonObject
            // 
            this.ButtonObject.BackColor = System.Drawing.Color.YellowGreen;
            this.ButtonObject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonObject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonObject.Location = new System.Drawing.Point(451, 635);
            this.ButtonObject.Name = "ButtonObject";
            this.ButtonObject.Size = new System.Drawing.Size(607, 139);
            this.ButtonObject.TabIndex = 0;
            this.ButtonObject.Text = "Begin Object Detection";
            this.ButtonObject.UseVisualStyleBackColor = false;
            this.ButtonObject.Click += new System.EventHandler(this.ButtonObject_Click_1);
            // 
            // ButtonPythonInterpreter
            // 
            this.ButtonPythonInterpreter.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ButtonPythonInterpreter.Location = new System.Drawing.Point(44, 67);
            this.ButtonPythonInterpreter.Name = "ButtonPythonInterpreter";
            this.ButtonPythonInterpreter.Size = new System.Drawing.Size(656, 187);
            this.ButtonPythonInterpreter.TabIndex = 1;
            this.ButtonPythonInterpreter.Text = "Browse for Python Interpreter Location (python.exe)\r\n(Please use python 3.10)";
            this.ButtonPythonInterpreter.UseVisualStyleBackColor = false;
            this.ButtonPythonInterpreter.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Location = new System.Drawing.Point(835, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(591, 187);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse for Python Execution file (MMD.py)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ButtonIn
            // 
            this.ButtonIn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ButtonIn.Location = new System.Drawing.Point(44, 317);
            this.ButtonIn.Name = "ButtonIn";
            this.ButtonIn.Size = new System.Drawing.Size(656, 177);
            this.ButtonIn.TabIndex = 3;
            this.ButtonIn.Text = "Select the Input path";
            this.ButtonIn.UseVisualStyleBackColor = false;
            this.ButtonIn.Click += new System.EventHandler(this.ButtonIn_Click);
            // 
            // ButtonOut
            // 
            this.ButtonOut.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ButtonOut.Location = new System.Drawing.Point(835, 317);
            this.ButtonOut.Name = "ButtonOut";
            this.ButtonOut.Size = new System.Drawing.Size(591, 177);
            this.ButtonOut.TabIndex = 4;
            this.ButtonOut.Text = "Select the Output path";
            this.ButtonOut.UseVisualStyleBackColor = false;
            this.ButtonOut.Click += new System.EventHandler(this.ButtonOut_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 48F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 920);
            this.Controls.Add(this.ButtonOut);
            this.Controls.Add(this.ButtonIn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ButtonPythonInterpreter);
            this.Controls.Add(this.ButtonObject);
            this.Name = "FormMain";
            this.Text = "ADLTagger Window";
            this.ResumeLayout(false);

        }

        #endregion

        private Button ButtonObject;
        private Button ButtonPythonInterpreter;
        private Button button1;
        private Button ButtonIn;
        private Button ButtonOut;
    }
}