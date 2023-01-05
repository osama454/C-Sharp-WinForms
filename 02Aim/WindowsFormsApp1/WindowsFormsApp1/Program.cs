using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace WindowsFormsApp1
{
    class MyForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        const int GWL_EXSTYLE = -20;
        const int WS_EX_LAYERED = 0x80000;
        const int WS_EX_TRANSPARENT = 0x20;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var style = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, style | WS_EX_LAYERED | WS_EX_TRANSPARENT);
        }
    }

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            var width = Screen.PrimaryScreen.Bounds.Width;
            var Height = Screen.PrimaryScreen.Bounds.Height;

            const int s = 2;
            const int l = 10;
            var F = new MyForm()
            {
                BackColor = Color.Magenta,
                TransparencyKey = Color.Magenta,
                AutoSize = false,
                FormBorderStyle = FormBorderStyle.None,
                ShowInTaskbar = false,
                Size = new Size(width, Height),
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0,0),
                TopMost = true,
                TabStop = false
            };
            F.Paint += new PaintEventHandler((object sender, PaintEventArgs e) => {
                Graphics g = F.CreateGraphics();

                Brush b = new SolidBrush(Color.FromArgb(255,255,0,0));
                
                //g.FillEllipse(b, 0, 0,s,s);
                g.FillRectangle(b, width / 2 - s / 2, Height / 2 - l / 2, s, l);
                g.FillRectangle(b, width / 2 - l / 2, Height / 2 - s / 2, l, s);
                g.Dispose();
            });

            Application.Run(F);


        }



    }
}
