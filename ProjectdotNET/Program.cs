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
            //Application.Run(new fCategoryADO());
            /*Application.Run(new FormCategoryLinQ());*/
            /*            Application.Run(new FormEmployeeADO());
                        Application.Run(new FormEmployeeLinQ());*/
            Application.Run(new fLogin());
            //Application.Run(new Product_ADO());
            //Application.Run(new fBill_ADO());
            //Application.Run(new fBillinfo());
        }
    }
}
