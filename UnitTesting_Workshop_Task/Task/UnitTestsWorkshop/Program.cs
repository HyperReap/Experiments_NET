using System;
using System.Windows.Forms;
using UnitTestsWorkshop.DragAndDrop;

namespace UnitTestsWorkshop
{
    internal class Program
    {
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TreeViewForm());
        }
    }
}
