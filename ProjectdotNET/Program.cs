﻿using System;
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
            Application.Run(new fLogin());
            //Application.Run(new fBill());
            //Application.Run(new fBillinfo());
            //Application.Run(new fOrder());
            //Application.Run(new fRevenue());
            //Application.Run(new fEmployee());
            //Application.Run(new fReportBill());
        }
    }
}
