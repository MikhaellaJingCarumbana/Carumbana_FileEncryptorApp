namespace Carumbana_FileEncryptorApp
{
    partial class Form1
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
            btn_Encrypt = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // btn_Encrypt
            // 
            btn_Encrypt.Location = new Point(128, 85);
            btn_Encrypt.Name = "btn_Encrypt";
            btn_Encrypt.Size = new Size(135, 58);
            btn_Encrypt.TabIndex = 0;
            btn_Encrypt.Text = "Encrypt File";
            btn_Encrypt.UseVisualStyleBackColor = true;
            btn_Encrypt.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(328, 85);
            button2.Name = "button2";
            button2.Size = new Size(137, 58);
            button2.TabIndex = 1;
            button2.Text = "Decrypt File";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 190);
            Controls.Add(button2);
            Controls.Add(btn_Encrypt);
            Name = "Form1";
            Text = "File Encryptor";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Encrypt;
        private Button button2;
    }
}
