using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1.Components
{
    public partial class myTreeView : UserControl
    {
        public myTreeView()
        {
            
            InitializeComponent();
            


        }

       
        private void myTreeView_Load(object sender, EventArgs e)
        {


            // MessageBox.Show(this.ConfigLoc);
            try {

                //if (treeSetting!=null &&ConfigLoc!=null && !File.Exists(ConfigLoc))
                //{
                //    var myFile = File.Create(ConfigLoc);
                //    myFile.Close();
                //    MessageBox.Show("Text file is created in this path:\n"+ ConfigLoc+
                //        "\nto Store the Opened Folders in the Tree");

                //}

                //string PathLocs = File.ReadAllText(ConfigLoc);
                string PathLocs = treeSetting();
            //MessageBox.Show(PathLoc);
            foreach (string PathLoc in PathLocs.Split('\n'))
            {
                if (Directory.Exists(PathLoc))
                {
                    //LoadDirectory1(PathLoc);
                    LoadDirectory1(PathLoc);
                }
            }
            }
            catch
            {
                MessageBox.Show("Enter Configration Location in Data Category Proberty \n" +
                    "And the Function that will be Excuted when select item from the tree");
            }
           

        }


        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
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

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {

            DoubleLoadSubDirectories(e.Node);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AfterSelect(sender, e);

            
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


        //Context Menue Strip Events:
        private void delete(object sender, EventArgs e)//delete
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent == null)
            {
                return;

            }
            if (treeView1.SelectedNode != null &&
                File.Exists(treeView1.SelectedNode.Tag.ToString()))
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete\n " + treeView1.SelectedNode.Text.ToString() + "\n?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
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

        private void copy(object sender, EventArgs e)
        {
            Cliboard = treeView1.SelectedNode.Tag.ToString();
        }
        private void cut(object sender, EventArgs e)
        {
            TN = treeView1.SelectedNode;
            Cliboard = treeView1.SelectedNode.Tag.ToString();
            CutFlag = true;
        }

        private void past(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (File.Exists(Cliboard))//files
                {
                    File.Copy(Cliboard,
                        treeView1.SelectedNode.Tag.ToString() + @"\" + Path.GetFileName(Cliboard),
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
                    string DestinationPath = treeView1.SelectedNode.Tag.ToString() +
                        @"\" + Path.GetFileName(Cliboard);
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

        private void rename(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent == null)
            {
                return;

            }
            if (treeView1.SelectedNode != null && File.Exists(treeView1.SelectedNode.Tag.ToString()))
            {

                string temp = new DialogBox("Rename With:", treeView1.SelectedNode.Text).Data();
                if (temp != "")
                {
                    string temp2 = treeView1.SelectedNode.Tag.ToString();
                    File.Move(temp2,
                        Path.GetDirectoryName(temp2) + @"\" + temp);
                    DoubleLoadSubDirectories(treeView1.SelectedNode.Parent);
                }
            }
            else if (treeView1.SelectedNode != null && Directory.Exists(treeView1.SelectedNode.Tag.ToString()))
            {
                string temp = new DialogBox("Rename With:", treeView1.SelectedNode.Text).Data();
                if (temp != "")
                {
                    string temp2 = treeView1.SelectedNode.Tag.ToString();
                    Directory.Move(temp2,
                        Path.GetDirectoryName(temp2) + @"\" + temp);
                    DoubleLoadSubDirectories(treeView1.SelectedNode.Parent);
                }
            }
        }

        private void newFile(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && Directory.Exists(treeView1.SelectedNode.Tag.ToString()))
            {
                string promptValue = new DialogBox("file name:", "").Data();
                try
                {
                    string tmp1 = treeView1.SelectedNode.Tag.ToString() + @"\" + promptValue;
                    var myFile = File.Create(tmp1);
                    myFile.Close();
                    DoubleLoadSubDirectories(treeView1.SelectedNode);

                }
                catch { MessageBox.Show("newFile"); }
            }

        }

        private void newFolder(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && Directory.Exists(treeView1.SelectedNode.Tag.ToString()))
            {
                string name = new DialogBox("folder name:", "").Data();
                string tmp1 = treeView1.SelectedNode.Tag.ToString() + @"\" + name;
                System.IO.Directory.CreateDirectory(tmp1);
                DoubleLoadSubDirectories(treeView1.SelectedNode);

            }
        }

        private void openDirectory(object sender, EventArgs e)
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

        private void removeFolder(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent == null)
            {

                //string text = File.ReadAllText(ConfigLoc);
                string text = treeSetting();
                text = text.Replace(treeView1.SelectedNode.Tag.ToString(), "");
                //TextWriter tw = new StreamWriter(ConfigLoc);
                //tw.Write(text);
                //tw.Close();
                //treeView1.SelectedNode.Remove();
                treeSetting(text);

            }
        }


        

        private void LoadDirectoryInTree(string path2)
        {
            string folders = treeSetting();

            if (Directory.Exists(path2) &&
                !folders.Contains(path2))
            {

                PathLoc = path2;

                treeView1.Tag = PathLoc;
                // treeView1.Nodes.Clear();
                LoadDirectory1(PathLoc);

                //TreeNode tds = treeView1.Nodes.Add(Path.GetFileName(PathLoc));

                // tds.StateImageIndex = 0;
                treeSetting(folders+ '\n' + PathLoc) ;
                //var tw = File.AppendText(ConfigLoc);
                //tw.Write('\n' + PathLoc);
                //tw.Close();
            }
        }

        //insert folder in the root of the tree
        private void LoadDirectory1(string Dir)
        {
            DirectoryInfo di = new DirectoryInfo(Dir);
            //Setting ProgressBar Maximum Value
            TreeNode tds = treeView1.Nodes.Add(di.Name);
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            LoadFiles(Dir, tds);
            LoadSubDirectories(Dir, tds);
        }

        private void DoubleLoadSubDirectories(TreeNode td)
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

        // takes node and it's path and insert all files inside this path
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

        // takes node and it's path and insert all folders inside this path
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

            }
        }





        //[Description("Configration File Location that contains the opened Folders in the tree"), Category("Data")]
        //public string ConfigLoc { get; set; } 
                                              

        public delegate void AfterSelectFunc(object sender, TreeViewEventArgs e);
        [Description("the Function that will be Excuted when select item from the tree"), Category("Data")]
        public AfterSelectFunc AfterSelect { get; set; }

        public delegate string Settings(string str = null);
        public Settings treeSetting;


        private string Cliboard = "";
        private string PathLoc = "";
        private TreeNode TN;
        private bool CutFlag = false;

      





        // public List<string> OpenedFilesList;
    }
}
