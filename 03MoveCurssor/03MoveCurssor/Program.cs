using System;

using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace _03MoveCurssor
{
    
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
            var kbh = new LowLevelKeyboardHook();
            var sim = new InputSimulator();
            kbh.OnKeyPressed += (object sender, Keys e) => {
                if (e.ToString() == "LShiftKey") {
                    sim.Mouse.MoveMouseBy(width/2-1, 0);
                }
                
            };
            kbh.OnKeyUnpressed += (object sender, Keys e) => {

            };
            kbh.HookKeyboard();
            var F = new Form();
           
            Application.Run(F);
        }
    }
}
