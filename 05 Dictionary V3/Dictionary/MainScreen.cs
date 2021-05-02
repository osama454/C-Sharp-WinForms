using System.IO;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            string path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            string fileNam = Path.GetFileName(path);
            string extension = Path.GetExtension(path);
          
            this.Text += fileNam.Replace(extension, null);



        }
        
        
    }
}






