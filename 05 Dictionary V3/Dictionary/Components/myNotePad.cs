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
using WindowsFormsApp1.Components;

namespace Dictionary.Components
{

    public partial class myNotePad : UserControl
    {
        public myNotePad()
        {

            this.SuspendLayout();

            this.myTabControl1 = new myTabControl();

            this.myTabControl1.onClose = onClose;

            this.myTabControl1.myPage = () => { return new AdvanceRichTextBox(this); };
            this.myTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(this.myTabControl1);
            this.ResumeLayout(false);
        }
        private void onClose(int i, myTabControl myTabControl1)
        {
            if (myTabControl1.tabControl1.TabPages[i].Text.ToString().Contains('*'))
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Save ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    RichTextBox rtb = ((RichTextBox)myTabControl1.tabControl1.TabPages[i].Controls[0].Controls[0].Controls[0]);
                    string loc = myTabControl1.OpenedFilesList.ElementAt(i);

                    SaveMyData(rtb, loc);
                }
            }
            myTabControl1.tabControl1.TabPages.RemoveAt(i);
            myTabControl1.OpenedFilesList.RemoveAt(i);
        }

        public  void SaveMyData(RichTextBox rtb, string loc)
        {

            if (loc == "New Tab" || loc == "output")
            {
                SaveFileDialog savefile = new SaveFileDialog();
                // set a default file name
                savefile.FileName = "New Code Note.osos";
                // set filters - this can be done in properties as well
                savefile.Filter = "Osama (*.osos)|*.osos|All files (*.*)|*.*";

                if (savefile.ShowDialog() == DialogResult.OK)
                {

                    rtb.SaveFile(savefile.FileName);
                    myTabControl1.OpenedFilesList.RemoveAt(myTabControl1.tabControl1.SelectedIndex);
                    myTabControl1.OpenedFilesList.Insert(myTabControl1.tabControl1.SelectedIndex, savefile.FileName);
                    myTabControl1.tabControl1.TabPages[myTabControl1.tabControl1.SelectedIndex].Text = Path.GetFileName(savefile.FileName);

                }
                return;
            }
            rtb.SaveFile(loc);
            myTabControl1.tabControl1.SelectedTab.Text = myTabControl1.tabControl1.SelectedTab.Text.TrimEnd('*');


        }


        public myTabControl myTabControl1;
        public AdvanceRichTextBox AdvanceRichTextBox1;
    }



    public class AdvanceRichTextBox : UserControl
    {

        public AdvanceRichTextBox(myNotePad myNotePad1)
        {
            myTabControl myTabControl1 = myNotePad1.myTabControl1;


            myRichTextBox1 = new myRichTextBox();
            myRichTextBox1.Dock = DockStyle.Fill;
            this.Controls.Add(myRichTextBox1);
            myRichTextBox1.richTextBox1.KeyDown += (sender, e) =>
            {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control && e.KeyCode == Keys.S)
                {
                    // do whatever you want to do here...
                    string loc= myNotePad1.myTabControl1.OpenedFilesList[myTabControl1.tabControl1.SelectedIndex];
                    myNotePad1.SaveMyData(this.myRichTextBox1.richTextBox1, loc);
                    e.SuppressKeyPress = true;
                }

            };
             myRichTextBox1.richTextBox1.TextChanged += (sender, e) =>
            {
                string name = myTabControl1.tabControl1.TabPages[myTabControl1.tabControl1.SelectedIndex].Text.ToString();

                //  MessageBox.Show("write");
                if (!name.Contains("*"))
                {
                    if (myTabControl1.OpenedFilesList.ElementAt(myTabControl1.tabControl1.SelectedIndex) == "output")
                        return;
                    myTabControl1.tabControl1.TabPages[myTabControl1.tabControl1.SelectedIndex].Text += "*";
                }
            };


        }

        public delegate void textChange();
        textChange onTextChange { get; set; }

        public myRichTextBox myRichTextBox1;


    }



}





