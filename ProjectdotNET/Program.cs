using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectdotNET
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            //Application.Run(new Form1());
            Application.Run(new Product_ADO());
=======
            Application.Run(new FormCategoryADO());
            Application.Run(new FormCategoryLinQ());
>>>>>>> 3a6c4260fdc9899585a5462def16b2f6b7c2590e
        }
    }
}
