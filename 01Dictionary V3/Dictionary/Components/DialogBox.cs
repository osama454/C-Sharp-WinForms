using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Components
{
    public partial class DialogBox : Form
    {
        public DialogBox(string text, string OldName)
        {
            this.text = text;
            this.OldName = OldName;
            textLabel = new Label() { Left = 50, Top = 20, Text = text };
            textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Text = OldName };
            confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            InitializeComponent();
            
        }
        public string Data()
        {
            return ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
        string text = "";
        string OldName = "";
    }
}
