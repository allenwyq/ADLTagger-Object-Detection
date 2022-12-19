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
            this.SuspendLayout();
            // 
            // ButtonObject
            // 
            this.ButtonObject.Location = new System.Drawing.Point(685, 145);
            this.ButtonObject.Name = "ButtonObject";
            this.ButtonObject.Size = new System.Drawing.Size(329, 209);
            this.ButtonObject.TabIndex = 0;
            this.ButtonObject.Text = "Object...";
            this.ButtonObject.UseVisualStyleBackColor = true;
            this.ButtonObject.Click += new System.EventHandler(this.ButtonObject_Click_1);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 48F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 707);
            this.Controls.Add(this.ButtonObject);
            this.Name = "FormMain";
            this.Text = "ADLTagger Window";
            this.ResumeLayout(false);

        }

        #endregion

        private Button ButtonObject;
    }
}