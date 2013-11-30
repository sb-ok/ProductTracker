using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductTracker.Autorisation;
using ProductTracker.ProductStructure;

namespace ProductTracker
{
    static class ProductTracker
    { 
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AdministrationWindows());
        }
    }
}
