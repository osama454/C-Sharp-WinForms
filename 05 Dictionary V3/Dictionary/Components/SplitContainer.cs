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
    public partial class SplitContainer : UserControl
    {
        public SplitContainer()
        {
            InitializeComponent();

            myTreeView1.ConfigLoc = @"C:\ProgramData\00 osama CodeGenerator\Config.ini";

            myTreeView1.AfterSelect = (sender, e) =>
            {
                AfterSelect();
            };
            
            


        }
        private void SplitContainer_Load(object sender, EventArgs e)
        {
            string loc = Program.OpenedFileLocation;
            if (loc != null)
            {

                List<string> OpenedFilesList = myNotePad1.myTabControl1.OpenedFilesList;
                TabControl tabControl1 = myNotePad1.myTabControl1.tabControl1;
                string path = loc;
                string page = Path.GetFileName(path);
                AddNewTextTab(OpenedFilesList, tabControl1, page, path);
            }
        }
        void AfterSelect()
        {
            try
            {
                List<string> OpenedFilesList = myNotePad1.myTabControl1.OpenedFilesList;
                TreeView treeView1 = myTreeView1.treeView1;
                TabControl tabControl1 = myNotePad1.myTabControl1.tabControl1;

                if (!OpenedFilesList.Contains(treeView1.SelectedNode.Tag.ToString()) &&
                   File.Exists(treeView1.SelectedNode.Tag.ToString())  )
                {
                    string page = treeView1.SelectedNode.Text.ToString();
                    string path = treeView1.SelectedNode.Tag.ToString();
                    AddNewTextTab(OpenedFilesList, tabControl1, page, path);

                }
                else if(OpenedFilesList.Count>0 && File.Exists(treeView1.SelectedNode.Tag.ToString()))
                {
                    tabControl1.SelectTab(OpenedFilesList.IndexOf(treeView1.SelectedNode.Tag.ToString()));
                }
                // treeView1.SelectedNode = treeView1.Nodes[0];


            }
            catch(Exception e) { MessageBox.Show("AfterSelect:\n"+e.Message); }
        }

       

        private void AddNewTextTab(List<string> OpenedFilesList, TabControl tabControl1, string page, string path)
        {
            OpenedFilesList.Add(path);
            myNotePad1.myTabControl1.AddTab(page);

            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0].Controls[0].Controls[0];



            using (StreamReader sr = new StreamReader(path))
            {
                string textFile = sr.ReadLine();
                if (textFile != null && textFile.StartsWith(@"{\rtf1"))
                {

                    rtb.LoadFile(path);

                }
                else
                {
                    rtb.Text = File.ReadAllText(path);
                }
                tabControl1.TabPages[tabControl1.SelectedIndex].Text = page;
            }
        }

       
    }
}
