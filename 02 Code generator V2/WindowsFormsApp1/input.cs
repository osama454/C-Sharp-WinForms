using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using System.Collections.Specialized;
namespace dictionary
{
    public partial class input : Form
    {
        public input()
        {
            InitializeComponent();
        }
        public  string modify(string src, string old, string mod)
        {
            string result = src;
            string templ, tempr;

            int a, b, c;
            while (true)
            {
                if (result.Contains(old))
                {
                    a = result.IndexOf(old);
                    b = a + old.Length - 1;
                    c = result.Length;
                    templ = result.Substring(0, a);
                    tempr = result.Substring(b + 1, c - b - 1);
                    result = templ + mod + tempr;
                }
                else
                { break; }
            }
            return result;
        }
        public  void split(string src, string s, ref string lift, ref string right)
        {
            if (src.Contains(s))
            {
                int a, b, c;
                a = src.IndexOf(s);
                b = a + s.Length - 1;
                c = src.Length;
                lift = src.Substring(0, a);
                right = src.Substring(b + 1, c - b - 1);
            }
        }
        private void creat(string str)
        {
            
            str = str.Substring(1, str.Length - 1);
            

            int a, b, i = -1;
            string line;
            string temp1 = "", temp2 = "", temp3 = "";
            while (str.Length != 0)
            {
                i++;
                a = str.IndexOf("\n");

               
                b = str.Length;
                if (a <= 0) break;
                line = str.Substring(0, a);
                
                str = str.Substring(a + 1, b - a - 1);
                if (line.Contains("="))
                {
                    a = line.IndexOf("=");

                }
                else
                {
                    a = line.Length;
                }
                Label lbl = new Label();
                lbl.Text = line.Substring(0, a) + ":";
                lbl.AutoSize = true;
                //lbl.Size = new System.Drawing.Size(75, 29);
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.AutoScroll = true;
                //flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
                flp.Location = new System.Drawing.Point(3, 3);
                flp.Size = new System.Drawing.Size(667, 42);
                flp.TabIndex = 3;
                flp.Controls.Add(lbl);
                flowLayoutPanel1.Controls.Add(flp);

                if (line.Contains("{"))
                {

                    a = line.IndexOf("{");
                    b = line.IndexOf("}");
                    temp1 = line.Substring(a + 1, b - a - 1);
                    while (true)
                    {

                        // MessageBox.Show(temp1);
                        split(temp1, ",", ref temp2, ref temp3);
                        temp1 = temp3;
                        RadioButton rb = new RadioButton();
                        rb.AutoSize = true;
                        rb.Text = temp2;
                        flp.Controls.Add(rb);
                        // MessageBox.Show(temp2);
                        if (temp3.Contains(",") == false || temp2.Length <= 0)
                        {
                            RadioButton rb2 = new RadioButton();
                            rb2.AutoSize = true;
                            rb2.Text = temp3;
                            flp.Controls.Add(rb2);

                            if (line.Contains(":"))
                            {
                                a = line.IndexOf(":");
                                b = line.Length;
                                temp1 = line.Substring(a + 1, b - a - 1);
                                a = Int32.Parse(temp1);
                                RadioButton rb3 = (RadioButton)flowLayoutPanel1.Controls[i].Controls[a + 1];
                                rb3.Checked = true;


                            }
                            break;
                        }

                    }


                }
                else
                {
                    TextBox tb = new TextBox();
                    tb.Size = new System.Drawing.Size(412, 36);
                    tb.AcceptsTab = true;
                    tb.Multiline = true;
                    flp.Controls.Add(tb);
                    if (line.Contains("="))
                    {
                        a = line.IndexOf("=");
                        b = line.Length;
                        tb.Text = line.Substring(a + 1, b - a - 1);

                    }
                }

            }
        }
        

        private void creat2(string str)
        {
            /********************************************************************************/
            //Data                                      
            //List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            
            str = str.TrimEnd('\n');
            str = str.TrimStart('\n');
            string temp = "";//string after Trim spaces
            string[] tmp0= str.Split('\n');
            string [] tmp1 ;//split = 
            string[] tmp2; //split { }
            string[] tmp3;//splt :
            string temp3 = "";
            
            foreach (string line in tmp0)
            {
                /********************************************************************************/
                //Label
                //MessageBox.Show(line);
                temp = line;//.Trim();
                tmp1=temp.Split('=');
                FlowLayoutPanel flp = new FlowLayoutPanel();
                Label lbl = new Label();
                lbl.Text = tmp1[0] + ":";
                lbl.AutoSize = true;
                
                flp.AutoScroll = true;
                flp.Location = new System.Drawing.Point(3, 3);
                flp.Size = new System.Drawing.Size(667, 42);
                flp.TabIndex = 3;
                flp.Controls.Add(lbl);
                flowLayoutPanel1.Controls.Add(flp);
                //MessageBox.Show(tmp1[0].ToString());
                if(tmp1.Count()>1&&tmp1[1].Contains('{'))
                {
                    char[] ch1 = { '{', '}' };
                    tmp2 = tmp1[1].Split(ch1);
                    foreach (string temp2 in tmp2[1].Split(','))
                    {
                        /********************************************************************************/
                        //Radio Button
                        RadioButton rb = new RadioButton();
                        temp3 = temp2;
                        //result.Add(new Dictionary<string, string>());
                        
                        if (temp2.Contains(':'))
                        {
                            tmp3 = temp2.Split(':');
                            temp3 = tmp3[0];
                            //result[result.Count - 1].Add(temp3, tmp3[1]);
                            rb.Tag = tmp3[1];
                        }
                        else
                        {
                            //result[result.Count - 1].Add(temp3, temp3);
                            rb.Tag = temp3;
                        }
                        
                          
                          rb.AutoSize = true;
                          rb.Text = temp3;
                        flp.Controls.Add(rb);
                        
                          
                         
                    }
                    if (tmp2[2] != "")
                    {
                        tmp2[2] = tmp2[2].TrimStart(':');
                       // MessageBox.Show(tmp2[2]);
                        FlowLayoutPanel FLb = (FlowLayoutPanel)flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1];

                        RadioButton RB = (RadioButton)FLb.Controls[Int32.Parse(tmp2[2]) + 1];//
                       // MessageBox.Show(RB.Text.ToString());
                        RB.Checked = true;
                    }
                }
                else
                {
                    /********************************************************************************/
                    //TextBox
                    TextBox tb = new TextBox();
                    tb.Size = new System.Drawing.Size(412, 36);
                    tb.AcceptsTab = true;
                    tb.Multiline = true;
                    if (tmp1.Count() > 1)
                    {
                        if (tmp1[1] == "")
                        {
                            tmp1[1] = " ";
                        }
                        tb.Text = tmp1[1];
                    }
                    flp.Controls.Add(tb);
                }

            }
        }

        private void input_Load(object sender, EventArgs e)
        {
            
            Form1 f=new Form1()  ;
          
           foreach (Form1 oForm2 in Application.OpenForms.OfType<Form1>())
            {
                f = oForm2;


            }
        
        
            
            string path = f.SelectedNodePath;
            string text = System.IO.File.ReadAllText(path)+"\n";
            string lift = "", right = "";
            split(text, "<***>", ref lift, ref right);
            creat2(right);
            // MessageBox.Show(right);

    
        }

        public void OKpressed2()
        {
            Form1 f = new Form1();
            // Form[] Forms = new Form[] { };
            foreach (Form1 oForm2 in Application.OpenForms.OfType<Form1>())
            {
                f = oForm2;


            }

            string path = f.SelectedNodePath;
            string text = System.IO.File.ReadAllText(path);
            string[] splited = text.Split(new string[]{"<***>" }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (FlowLayoutPanel FLB in flowLayoutPanel1.Controls)
            {
                //MessageBox.Show("foreach (FlowLayoutPanel FLB in flowLayoutPanel1.Controls)");
                if (FLB.Controls[0] is Label)
                {
                    //MessageBox.Show("if(FLB.Controls[0] is Label)");
                    var checkedButton = FLB.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                    var textBox = FLB.Controls.OfType<TextBox>();
                    
                    //textBox.First();
                    if (FLB.Controls[1] is TextBox)
                    {
                        
                        splited[0] = splited[0].Replace("<" + FLB.Controls[0].Text.TrimEnd(':') + ">",
                            textBox.First().Text);
                       // MessageBox.Show(splited[0]);
                    }
                    else
                    {
                       // MessageBox.Show("else");
                        splited[0] = splited[0].Replace("<" + FLB.Controls[0].Text.TrimEnd(':') + ">",
                           checkedButton.Tag.ToString());
                        
                    }
                    
                    
                }
            }
            f.tabControl1.SelectedTab.Controls[0].Text += splited[0];
            //MessageBox.Show("this.Close();");
            this.Close();

        }
        public void OKpressed()
        {
            //MessageBox.Show(flowLayoutPanel1.Controls[0].Controls[0].Text.ToString());

            Form1 f = new Form1();
            // Form[] Forms = new Form[] { };
            foreach (Form1 oForm2 in Application.OpenForms.OfType<Form1>())
            {
                f = oForm2;


            }

            string path = f.SelectedNodePath;
            string text = System.IO.File.ReadAllText(path);
            string lift = "", right = "";
            split(text, "<***>", ref lift, ref right);
            string str, lbl;

            int i = 0, j = 0;
            while (true)
            {
                try
                {
                    Label lb = (Label)flowLayoutPanel1.Controls[i].Controls[0];

                }
                catch
                {
                    goto L3;
                }
                try
                {
                    TextBox tb = (TextBox)flowLayoutPanel1.Controls[i].Controls[1];
                    lbl = flowLayoutPanel1.Controls[i].Controls[0].Text.ToString();
                    lbl = lbl.Substring(0, lbl.Length - 1);
                    str = tb.Text.ToString();
                    if (str.Length <= 0) goto L;
                    //MessageBox.Show(str);
                    i += 1;

                }
                catch (Exception)
                {
                    try
                    {
                        j = 1;
                        while (true)
                        {
                            RadioButton tb = (RadioButton)flowLayoutPanel1.Controls[i].Controls[j];
                            if (tb.Checked)
                            {
                                str = tb.Text.ToString();
                                lbl = flowLayoutPanel1.Controls[i].Controls[0].Text.ToString();
                                lbl = lbl.Substring(0, lbl.Length - 1);
                                //MessageBox.Show(str);
                                i += 1;
                                //MessageBox.Show(str);
                                goto L2;
                            }
                            j++;
                        }



                    }
                    catch (Exception)
                    {
                        //MessageBox.Show(j.ToString());
                        goto L;
                    }
                }
            L2:
                //MessageBox.Show(lbl);
                lift = modify(lift, "<" + lbl + ">", str);
                // MessageBox.Show(lift);

            }

        L3:
            try
            {
                f.tabControl1.TabPages[f.tabControl1.SelectedIndex].Controls[0].Text
               += lift;
                this.Close();
            }
            catch { }
        L:;  
        }
        private void button1_Click(object sender, EventArgs e)
        {

            OKpressed2();

        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
           // MessageBox.Show(e.KeyCode.ToString());
            if(e.KeyCode.ToString()=="Return")
            {
                OKpressed();
            }
        }
    }
}
