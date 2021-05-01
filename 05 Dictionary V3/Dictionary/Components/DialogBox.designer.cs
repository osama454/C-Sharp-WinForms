
using System.Windows.Forms;

namespace WindowsFormsApp1.Components
{
    partial class DialogBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();


            // 
            // DialogBox
            // 
            Width = 500;
            Height = 150;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Text = "Input Dialogue";
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(textBox);
            Controls.Add(confirmation);
            Controls.Add(textLabel);
            AcceptButton = confirmation;
            this.ResumeLayout(false);

        }
        Label textLabel;
        TextBox textBox;
        Button confirmation;

        #endregion
    }
}
