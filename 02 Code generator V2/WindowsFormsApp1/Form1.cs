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
using System.Diagnostics;
using dictionary;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.tabControl1.TabPages[this.tabControl1.TabCount - 1].Text = "";
            this.tabControl1.Padding = new Point(12, 4);
            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        public List<String> OpenedFilesList = new List<String> { };

        //public string CurrentDirectory = @"E:\tmp\Data";
        public static string ShowDialog(string text,string OldName)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "input dialogue",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400,Text= OldName };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
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
                    var addImage = Properties.Resources.Add;
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
            catch { }
        }
        private RichTextBox createRichTextBox() {
            RichTextBox richTextBox1 = new RichTextBox();
            richTextBox1.AcceptsTab = true;
            richTextBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            richTextBox1.Location = new System.Drawing.Point(73, 156);
            richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(199, 196);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            richTextBox1.WordWrap = false;
            richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            return richTextBox1;
        }
        public void AddTab(string TabName)
        {
            var lastIndex = this.tabControl1.TabCount - 1;
            this.tabControl1.TabPages.Insert(lastIndex, TabName);
            this.tabControl1.SelectedIndex = lastIndex;
            this.tabControl1.TabPages[lastIndex].UseVisualStyleBackColor = true;
            RichTextBox richTextBox1 = createRichTextBox();
            tabControl1.TabPages[lastIndex].Controls.Add(richTextBox1);
            //this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            
            

            
            richTextBox1.TextChanged += (sender, e) =>
            {
                string name = tabControl1.TabPages[tabControl1.SelectedIndex].Text.ToString();
                int lastIndx = name.Length - 1;
                //  MessageBox.Show("write");
                if (!name.Contains("*"))
                {
                    if (OpenedFilesList.ElementAt(tabControl1.SelectedIndex) == "output")
                        return;
                    tabControl1.TabPages[tabControl1.SelectedIndex].Text += "*";
                }
            };


            //private System.Windows.Forms.RichTextBox richTextBox1; //commenet
        }

        public void SaveChanges(string loc, string data)//public save
        {

            if (loc == "New Tab" || loc == "output")
            {
                SaveFileDialog savefile = new SaveFileDialog();
                // set a default file name
                savefile.FileName = "unknown.txt";
                // set filters - this can be done in properties as well
                savefile.Filter = "All files (*.*)|*.*";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    TextWriter tw1 = new StreamWriter(savefile.FileName);
                    tw1.Write(data);
                    tw1.Close();
                    OpenedFilesList.RemoveAt(tabControl1.SelectedIndex);
                    OpenedFilesList.Insert(tabControl1.SelectedIndex, savefile.FileName);
                    tabControl1.TabPages[tabControl1.SelectedIndex].Text = Path.GetFileName(savefile.FileName);

                }
                return;

            }
            //MessageBox.Show(loc);
            TextWriter tw = new StreamWriter(loc);
            //MessageBox.Show(data);
            tw.Write(data);
            tw.Close();

        }
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)//new tab and close tab
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

                        if (tabControl1.TabPages[i].Text.ToString().Contains('*'))
                        {
                            if (DialogResult.Yes == MessageBox.Show("Do You Want Save ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                            {
                                //MessageBox.Show(OpenedFilesList.ElementAt(i) + '\n' + tabControl1.TabPages[i].Controls[0].Text.ToString());
                                SaveChanges(OpenedFilesList.ElementAt(i), tabControl1.TabPages[i].Controls[0].Text.ToString());
                            }
                        }
                        this.tabControl1.TabPages.RemoveAt(i);
                        OpenedFilesList.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

            if (e.TabPageIndex == this.tabControl1.TabCount - 1)
                e.Cancel = true;


        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }


        private void newToolStripButton_Click(object sender, EventArgs e)//new file
        {
            if (treeView1.SelectedNode !=null&& Directory.Exists(treeView1.SelectedNode.Tag.ToString()))
            {
                string promptValue = ShowDialog("file name:","");
                try
                {
                    string tmp1 = treeView1.SelectedNode.Tag.ToString() + @"\" + promptValue;
                    var myFile = File.Create(tmp1);
                    myFile.Close();
                    DoubleLoadSubDirectories(treeView1.SelectedNode);

                }
                catch { }
            }

        }




        public Process cmd = new Process();

        public string ConfigLoc = @"C:\ProgramData\00 osama CodeGenerator";
        private void Form1_Load(object sender, EventArgs e)
        {
            /* if (!OpenedFilesList.Contains("output"))
             {
                 AddTab("output");
                 OpenedFilesList.Add("output");
             }*/

            if (!Directory.Exists(ConfigLoc))
            {
                System.IO.Directory.CreateDirectory(ConfigLoc);
            }
            if (!File.Exists(ConfigLoc + @"\Config.ini"))
            {
                var myFile = File.Create(ConfigLoc + @"\Config.ini");
                myFile.Close();

            }
            string PathLocs = File.ReadAllText(ConfigLoc + @"\Config.ini");
            //MessageBox.Show(PathLoc);
            foreach (string PathLoc in PathLocs.Split('\n'))
            {
                if (Directory.Exists(PathLoc))
                {
                    //LoadDirectory1(PathLoc);
                    LoadDirectory1(PathLoc);
                }
            }
            if (Program.FilenNames != null)
            {
                foreach (string file in Program.FilenNames)
                {
                    AddTab(Path.GetFileName(file));
                    OpenedFilesList.Add(file);
                    tabControl1.SelectedTab.Controls[0].Text =
                        System.IO.File.ReadAllText(file);
                    tabControl1.TabPages[OpenedFilesList.IndexOf(file)].Text = tabControl1.TabPages[OpenedFilesList.IndexOf(file)].Text.ToString().TrimEnd('*');

                }
            }

            cmd.StartInfo.FileName = "python.exe";
            cmd.StartInfo.Arguments = @"-i";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.OutputDataReceived += new DataReceivedEventHandler((sender2, e2) =>
            {
                tabControl1.Invoke(new MethodInvoker(delegate
                {

                    if (!String.IsNullOrEmpty(e2.Data))
                    {

                        try
                        {
                            
                            tabControl1.TabPages[OpenedFilesList.IndexOf("output")]
                                      .Controls[0].Text += e2.Data.ToString() + "\n";
                        }
                        catch { }
                    }
                }
                ));

            });
            cmd.ErrorDataReceived += new DataReceivedEventHandler((sender2, e2) =>
            {
                tabControl1.Invoke(new MethodInvoker(delegate
                {

                    if (!String.IsNullOrEmpty(e2.Data))
                    {
                        try
                        {
                            tabControl1.TabPages[OpenedFilesList.IndexOf("output")]
                                    .Controls[0].Text += e2.Data.ToString() + "\n";
                            //waitsForInput(); 
                        }
                        catch { }
                    }
                }
                ));

            });
           
            cmd.Start();
            cmd.BeginOutputReadLine();
            cmd.BeginErrorReadLine();

            ToolStripComboBox1_Mode.SelectedIndex = 0;






        }
        

        public void CreateNewFolder( )
        {
            if (treeView1.SelectedNode != null && Directory.Exists(treeView1.SelectedNode.Tag.ToString()))
            {
                string name = ShowDialog("folder name:","");
                string tmp1 = treeView1.SelectedNode.Tag.ToString() + @"\" + name;
                System.IO.Directory.CreateDirectory(tmp1);
                DoubleLoadSubDirectories(treeView1.SelectedNode);

            }
        }
        private void ToolStripButton_NewFolder_Click(object sender, EventArgs e)//Open folder
        {

            string path2 = ShowDialog("Select Directory", "");
            LoadDirectoryInTree(path2);
        }

        private void ToolStripButton_Delete_Click(object sender, EventArgs e)//delete
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent == null)
            {
                return;

            }
            if (treeView1.SelectedNode != null &&
                File.Exists(treeView1.SelectedNode.Tag.ToString()))
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete\n "+treeView1.SelectedNode.Text.ToString() + "\n?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    FileInfo file = new FileInfo(treeView1.SelectedNode.Tag.ToString());
                    file.Delete();
                    DoubleLoadSubDirectories(treeView1.SelectedNode.Parent);
                }

            }
            else if (treeView1.SelectedNode != null &&
                Directory.Exists(treeView1.SelectedNode.Tag.ToString()))
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete\n " + treeView1.SelectedNode.Text.ToString() + "\n?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    if (DialogResult.Yes == MessageBox.Show("Are You sure that you Want to Delete\n " + treeView1.SelectedNode.Text.ToString() + "\n?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        System.IO.Directory.Delete(treeView1.SelectedNode.Tag.ToString(), true); //true for delete if the folder is not empty

                        DoubleLoadSubDirectories(treeView1.SelectedNode.Parent);
                    }
                }
            }
        }

        private void ToolStripButton_Save_Click(object sender, EventArgs e)//save
        {
            //MessageBox.Show(OpenedFilesList.ElementAt(tabControl1.SelectedIndex));
            try
            {
                SaveChanges(OpenedFilesList.ElementAt(tabControl1.SelectedIndex),
                  tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0].Text.ToString());
                tabControl1.TabPages[tabControl1.SelectedIndex].Text =
                    tabControl1.TabPages[tabControl1.SelectedIndex].Text.ToString().TrimEnd('*');
            }
            catch { }
            }

        private void ToolStripMenuItem_Save_Click(object sender, EventArgs e)//save
        {
            SaveChanges(OpenedFilesList.ElementAt(tabControl1.SelectedIndex),
               tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0].Text.ToString());
            tabControl1.TabPages[tabControl1.SelectedIndex].Text =
                tabControl1.TabPages[tabControl1.SelectedIndex].Text.ToString().TrimEnd('*');
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabControl1.TabCount > 0)
            {
                //int i = 0;
                TabControl.TabPageCollection tabcoll = tabControl1.TabPages;
                foreach (TabPage tabpage in tabcoll)
                {
                    tabControl1.SelectedTab = tabpage;
                    if (tabpage.Text.Contains("*"))
                    {
                        DialogResult dg = MessageBox.Show("Do you want to save file " + tabpage.Text + " before close ?", "Save or Not", MessageBoxButtons.YesNoCancel);
                        if (dg == DialogResult.Yes)
                        {
                            SaveChanges(OpenedFilesList.ElementAt(0), tabpage.Controls[0].Text.ToString());
                            tabControl1.TabPages.Remove(tabpage);
                            OpenedFilesList.RemoveAt(0);
                            //  i++;
                        }
                        else if (dg == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                            tabControl1.Select();
                            break;
                        }
                    }
                    else
                    {
                        tabControl1.TabPages.Remove(tabpage);
                        //myTabControlZ_SelectedIndexChanged(sender, e);
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//full screen
        {
            if (this.WindowState != System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                this.Visible = false;

                this.FormBorderStyle = FormBorderStyle.None;
                this.Visible = true;
                toolStripButton1.Text = "unfull_screen";

                // View_FullScreen_MenuItem.Checked = true;
                toolStripButton1.Image = Properties.Resources.unfull_screen;
            }
            else
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.Visible = false;

                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Visible = true;
                toolStripButton1.Text = "full_screen";
                // View_FullScreen_MenuItem.Checked = true;
                toolStripButton1.Image = Properties.Resources.full_screen;
            }

        }
        public void Preprocessing_before_run(string code, ref string result)
        {
            result = code + "\n";
            result = result +
                "print(\"<done>\")";

            result = result.Replace("\t", " ");
            result = result.Replace(@"\", @"\" + @"\");
            result = result.Replace("\"", @"\" + "\"");
            result = result.Replace("\n", @"\n");



            result = "exec(\"" + result + "\")";
            // tabControl1.SelectedTab.Controls[0].Text += result;
        }



        public void RunPythonCode(string code)
        {
            if (tabControl1.SelectedTab.Text.ToString().TrimEnd('*') != "output")
            {

                string result = "";

                Preprocessing_before_run(code, ref result);


                if (!OpenedFilesList.Contains("output"))
                {
                    AddTab("output");
                    OpenedFilesList.Add("output");
                }


                cmd.StandardInput.WriteLine(result);
                tabControl1.SelectTab(OpenedFilesList.IndexOf("output"));
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//Run
        {


            //MessageBox.Show(indx.ToString());
            RunPythonCode(tabControl1.SelectedTab.Controls[0].Text.ToString());



        }

        public void TakeSubString(string src, ref string result, int index, string separator = "#%%")
        {
            if (src.Length <= 0) return;
            int indxl = 0, indxr = 0;
            string srcl = "", srcr = "";

            srcl = src.Substring(0, index + 1);
            srcr = src.Substring(index + 1, src.Length - (index + 1));
            indxl = srcl.LastIndexOf(separator);
            indxr = srcr.IndexOf(separator);
            if (indxl != -1 && indxr != -1)
            {
                result = srcl.Substring(indxl, srcl.Length - (indxl))
                    + srcr.Substring(0, indxr);
                return;
            }
            else if (indxl != -1 && indxr == -1)
            {
                result = srcl.Substring(indxl, srcl.Length - (indxl))
                    + srcr;
                return;
            }
            else if (indxr != -1 && indxl == -1)
            {
                result = srcl + srcr.Substring(0, indxr);
                return;
            }
            else result = src;

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F5")
            {
                string result = "";
                RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                string src = rtb.Text.ToString();



                //int indx = rtb.GetFirstCharIndexOfCurrentLine();
                int indx = rtb.SelectionStart - 1;
                //MessageBox.Show(indx.ToString());
                //MessageBox.Show(indx.ToString());

                //  MessageBox.Show(src);
                TakeSubString(src, ref result, indx);
                src = result;
                //MessageBox.Show(result);

                RunPythonCode(result);
            }
        }

        public string PathLoc = "";
        public void LoadDirectory1(string Dir)
        {
            DirectoryInfo di = new DirectoryInfo(Dir);
            //Setting ProgressBar Maximum Value
            TreeNode tds = treeView1.Nodes.Add(di.Name);
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            LoadFiles(Dir, tds);
            LoadSubDirectories(Dir, tds);
        }
        private void LoadFiles(string dir, TreeNode td)
        {
            string[] Files = Directory.GetFiles(dir, "*.*");

            // Loop through them to see files
            foreach (string file in Files)
            {
                FileInfo fi = new FileInfo(file);
                TreeNode tds = td.Nodes.Add(fi.Name);
                tds.Tag = fi.FullName;
                tds.StateImageIndex = 1;


            }
        }
        private void LoadSubDirectories(string dir, TreeNode td)
        {
            // Get all subdirectories
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            // Loop through them to see if they have any other subdirectories
            foreach (string subdirectory in subdirectoryEntries)
            {

                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tds = td.Nodes.Add(di.Name);
                tds.StateImageIndex = 0;
                tds.Tag = di.FullName;
                // MessageBox.Show(tds.Tag.ToString());
                // LoadFiles(subdirectory, tds);
                //LoadSubDirectories(subdirectory, tds);


            }
        }
        public void LoadDirectoryInTree(string path2)
        {
            
            if (Directory.Exists(path2) &&
                !System.IO.File.ReadAllText(ConfigLoc + @"\Config.ini").Contains(path2))
            {

                PathLoc = path2;
                
                treeView1.Tag = PathLoc;
               // treeView1.Nodes.Clear();
                LoadDirectory1(PathLoc);

                //TreeNode tds = treeView1.Nodes.Add(Path.GetFileName(PathLoc));

                // tds.StateImageIndex = 0;
                var tw =  File.AppendText(ConfigLoc + @"\Config.ini");
                tw.Write('\n'+PathLoc);
                tw.Close();
            }
        }
        private void LoadDirectory_Click(object sender, EventArgs e)
        {
            string path2 = ShowDialog("Select Directory", "");
            LoadDirectoryInTree(path2);
        }
        public void DoubleLoadSubDirectories(TreeNode td)
        {
            td.Nodes.Clear();
            LoadFiles(td.Tag.ToString(), td);
            LoadSubDirectories(td.Tag.ToString(), td);
            string[] subdirectoryEntries = Directory.GetDirectories(td.Tag.ToString());
            // Loop through them to see if they have any other subdirectories
            int i = td.Nodes.Count - subdirectoryEntries.Count();
            foreach (string subdirectory in subdirectoryEntries)
            {
                LoadFiles(subdirectory, td.Nodes[i]);
                LoadSubDirectories(subdirectory, td.Nodes[i]);
                i++;
            }
        }
        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            // MessageBox.Show(e.Node.FullPath);
            DoubleLoadSubDirectories(e.Node);
        }

        public string SelectedNodePath = "";
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            try
            {
                if (ToolStripComboBox1_Mode.SelectedItem.ToString() == "Code"&&
                    File.Exists(treeView1.SelectedNode.Tag.ToString()))
                {
                    SelectedNodePath = treeView1.SelectedNode.Tag.ToString();
                    string txt = System.IO.File.ReadAllText
                        (SelectedNodePath);
                    if (txt.Contains("<***>"))

                    {
                        input f = new input();
                        f.TopMost = true;
                        f.Show();

                    }
                    else
                    {
                        tabControl1.SelectedTab.Controls[0].Text += txt;

                    }
                    
                }
                else if (!OpenedFilesList.Contains(treeView1.SelectedNode.Tag.ToString())&&
                    File.Exists(treeView1.SelectedNode.Tag.ToString()))
                {
                    // MessageBox.Show(CurrentDirectory + @"\" + listBox1.SelectedItem.ToString().TrimEnd('*'));
                    string page = treeView1.SelectedNode.Text.ToString();
                    OpenedFilesList.Add(treeView1.SelectedNode.Tag.ToString());
                    AddTab(treeView1.SelectedNode.Text.ToString());
                    // tabControl1.TabPages.Add(listBox1.SelectedItem.ToString());

                    // RichTextBox rt = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                    //MessageBox.Show(treeView1.SelectedNode.Text.ToString());
                    tabControl1.SelectedTab.Controls[0].Text =
                        System.IO.File.ReadAllText(treeView1.SelectedNode.Tag.ToString());
                    tabControl1.TabPages[tabControl1.SelectedIndex].Text = page;
                }
                else
                {
                    tabControl1.SelectTab(OpenedFilesList.IndexOf(treeView1.SelectedNode.Tag.ToString()));
                }
               // treeView1.SelectedNode = treeView1.Nodes[0];
                

            }
            catch { }


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Select the clicked node
                if (treeView1.SelectedNode != null)
                {
                    treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
                    
                }
               

            }
            else if (e.Button == MouseButtons.Left)
            {
                // Select the clicked node
                if (treeView1.SelectedNode != null)
                {
                    treeView1.SelectedNode = treeView1.Nodes[0];
                    treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
                }


            }
            
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null&&treeView1.SelectedNode.Parent == null)
            {
                return;

            }
            if (treeView1.SelectedNode!=null && File.Exists(treeView1.SelectedNode.Tag.ToString()))
            {

                string temp = ShowDialog("Rename With:", treeView1.SelectedNode.Text);
                if(temp!="")
                {
                    string temp2 = treeView1.SelectedNode.Tag.ToString();
                    File.Move(temp2,
                        Path.GetDirectoryName(temp2)+@"\"+temp);
                    DoubleLoadSubDirectories(treeView1.SelectedNode.Parent);
                }
            }
            else if(treeView1.SelectedNode != null && Directory.Exists(treeView1.SelectedNode.Tag.ToString()))
            {
                string temp = ShowDialog("Rename With:", treeView1.SelectedNode.Text);
                if (temp != "")
                {
                    string temp2 = treeView1.SelectedNode.Tag.ToString();
                    Directory.Move(temp2,
                        Path.GetDirectoryName(temp2) + @"\" + temp);
                    DoubleLoadSubDirectories(treeView1.SelectedNode.Parent);
                }
            }
        }
        public string Cliboard = "";
        public bool  CutFlag = false;
        public TreeNode TN = new TreeNode();
        private void renameToolStripMenuItem_Click(object sender, EventArgs e)//copy
        {
            Cliboard = treeView1.SelectedNode.Tag.ToString();
            
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)//past
        {
            if(treeView1.SelectedNode!=null)
            {
                if(File.Exists(Cliboard))//files
                {
                    File.Copy(Cliboard,
                        treeView1.SelectedNode.Tag.ToString()+@"\"+Path.GetFileName(Cliboard),
                        true);
                    DoubleLoadSubDirectories(treeView1.SelectedNode);
                    if (CutFlag)
                    {
                        FileInfo file = new FileInfo(Cliboard);
                        file.Delete();
                        DoubleLoadSubDirectories(TN.Parent);
                    }
                }
                else if (Directory.Exists(Cliboard))//folders
                {
                    string DestinationPath = treeView1.SelectedNode.Tag.ToString()+
                        @"\"+ Path.GetFileName(Cliboard);
                    Directory.CreateDirectory(DestinationPath);
                    //Now Create all of the directories
                    foreach (string dirPath in Directory.GetDirectories(Cliboard, "*",
                        SearchOption.AllDirectories))
                        Directory.CreateDirectory(dirPath.Replace(Cliboard, DestinationPath));

                    //Copy all the files & Replaces any files with the same name
                    foreach (string newPath in Directory.GetFiles(Cliboard, "*.*",
                        SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(Cliboard, DestinationPath), true);
                    DoubleLoadSubDirectories(treeView1.SelectedNode);
                    if (CutFlag)
                    {
                        Directory.Delete(Cliboard, true);
                        DoubleLoadSubDirectories(TN.Parent);
                    }
                }
                
            }
            CutFlag = false;
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(splitContainer1.Panel1Collapsed.ToString());
            if (splitContainer1.Panel1Collapsed == false)
            {
                splitContainer1.Panel1Collapsed = true;
                
            }
            else
            {
                //MessageBox.Show(splitContainer1.Panel1Collapsed.ToString());
                splitContainer1.Panel1Collapsed = false;
                
            }
        }

        private void openFolderLocation_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(treeView1.SelectedNode.Tag.ToString()))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = treeView1.SelectedNode.Tag.ToString(),
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
            

            
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewFolder();
        }

        private void removeFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode != null && treeView1.SelectedNode.Parent == null)
            {
                
                string text = File.ReadAllText(ConfigLoc + @"\Config.ini");
                text = text.Replace(treeView1.SelectedNode.Tag.ToString(), "");
                TextWriter tw = new StreamWriter(ConfigLoc + @"\Config.ini");
                tw.Write(text);
                tw.Close();
                treeView1.SelectedNode.Remove();

            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
            {
                
                LoadDirectoryInTree(s[i]);
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TN = treeView1.SelectedNode;
            Cliboard = treeView1.SelectedNode.Tag.ToString();
            CutFlag = true;
        }
    }
  
}
    


