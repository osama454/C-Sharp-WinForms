using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Dictionary.Components
{
    public partial class myTabControl : UserControl
    {
        public myTabControl()
        {
           
            InitializeComponent();
            

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

            try
            {
                var tabPage = this.tabControl1.TabPages[e.Index];
                var tabRect = this.tabControl1.GetTabRect(e.Index);
                tabRect.Inflate(-2, -2);
                if (e.Index == this.tabControl1.TabCount - 1)
                {


                    var addImage = Dictionary.Properties.Resources.Add;


                    e.Graphics.DrawImage(addImage,
                        tabRect.Left + (tabRect.Width - addImage.Width) / 2,
                        tabRect.Top + (tabRect.Height - addImage.Height) / 2);
                }
                else
                {
                    var closeImage = Properties.Resources.Close;
                    e.Graphics.DrawImage(closeImage,
                        (tabRect.Right - closeImage.Width),
                        tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
                    TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                        tabRect, tabPage.ForeColor, TextFormatFlags.Left);
                }
            }
            catch {
                MessageBox.Show("tabControl1_DrawItem");
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //MessageBox.Show("tabControl1_Selecting");

            // if (e.TabPageIndex == this.tabControl1.TabCount - 1)
            // e.Cancel = true;


        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)//new tab or close tab
        {
            var lastIndex = this.tabControl1.TabCount - 1;
            if (this.tabControl1.GetTabRect(lastIndex).Contains(e.Location))
            {
                OpenedFilesList.Add("New Tab");
                AddTab("New Tab");
            }
            else
            {
                for (var i = 0; i < this.tabControl1.TabPages.Count; i++)
                {
                    var tabRect = this.tabControl1.GetTabRect(i);
                    tabRect.Inflate(-2, -2);
                    var closeImage = Properties.Resources.Close;
                    var imageRect = new Rectangle(
                        (tabRect.Right - closeImage.Width),
                        tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                        closeImage.Width,
                        closeImage.Height);
                    if (imageRect.Contains(e.Location))
                    {
                        onClose(i,this);
                        break;
                    }
                }
            }
        }
        public void AddTab(string TabName)
        {
            var lastIndex = this.tabControl1.TabCount - 1;
            this.tabControl1.TabPages.Insert(lastIndex, TabName);
            this.tabControl1.SelectedIndex = lastIndex;
            this.tabControl1.TabPages[lastIndex].UseVisualStyleBackColor = true;
            Control myControl = myPage();
            myControl.Dock = System.Windows.Forms.DockStyle.Fill;

            this.tabControl1.TabPages[lastIndex].Controls.Add(myControl);


        }

        
        
        
        [Description("Control that will be Added to Tab when press +"), Category("Data")]
        public Page myPage { get; set; }

        [Description("Function that will be Excuted when press x"), Category("Data")]
        public onClose2 onClose { get; set; }

        public List<string> OpenedFilesList=new List<string>();

        public  delegate Control Page();

        public  delegate void onClose2(int index,myTabControl myTabControl1);
       

    }
}
