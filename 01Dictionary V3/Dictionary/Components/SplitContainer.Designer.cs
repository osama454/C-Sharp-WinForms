
namespace Dictionary.Components
{
    partial class SplitContainer
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.myTreeView1 = new WindowsFormsApp1.Components.myTreeView();
            this.myNotePad1 = new Dictionary.Components.myNotePad();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.myTreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.myNotePad1);
            this.splitContainer1.Size = new System.Drawing.Size(823, 406);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 0;
            // 
            // myTreeView1
            // 
            this.myTreeView1.AfterSelect = null;
            
            this.myTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTreeView1.Location = new System.Drawing.Point(0, 0);
            this.myTreeView1.Name = "myTreeView1";
            this.myTreeView1.Size = new System.Drawing.Size(200, 406);
            this.myTreeView1.TabIndex = 0;
            // 
            // myNotePad1
            // 
            this.myNotePad1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myNotePad1.Location = new System.Drawing.Point(0, 0);
            this.myNotePad1.Name = "myNotePad1";
            this.myNotePad1.Size = new System.Drawing.Size(619, 406);
            this.myNotePad1.TabIndex = 0;
            // 
            // SplitContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SplitContainer";
            this.Size = new System.Drawing.Size(823, 406);
            this.Load += new System.EventHandler(this.SplitContainer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private WindowsFormsApp1.Components.myTreeView myTreeView1;
        private myNotePad myNotePad1;
    }
}
