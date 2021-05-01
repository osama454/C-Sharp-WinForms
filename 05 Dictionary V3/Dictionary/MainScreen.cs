using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dictionary.Components;
using Tulpep.NotificationWindow;

namespace Dictionary
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();

            var Cursor1 = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
            Cursor.Clip = new Rectangle(this.Location, this.Size);

            popup = new PopupNotifier()
            {
                TitleText = "BE HAPPY",
                ContentText = "Thank you"

            };
            popup.Popup();
            

        }
        //Cursor Cursor1;
        PopupNotifier popup;

    }


}
