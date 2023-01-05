using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string str = "asdasd";
            
            char[] tmp2 = { 'a', 'd' };
            string[] arr = str.Split('=');
            foreach (string tmp in arr) MessageBox.Show(arr[0]);
        }
    }
}
