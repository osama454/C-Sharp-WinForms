
using System.Linq;
using System.Windows.Forms;

namespace Dictionary.Components
{
    partial class myNotePad
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
            // myNotePad
            // 
            this.Name = "myNotePad";
            this.Size = new System.Drawing.Size(679, 375);
            this.ResumeLayout(false);

        }



        #endregion
    }
}
