using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SoftwareLocker;
using RoadWays;

namespace STORE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static bool OpenDetailFormOnClose { get; set; }
        [STAThread]
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [STAThread]
        static void Main(String[] Args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool bNew = true;

            // There can be only one... instance of this application on a machine.
            using (Mutex mutex = new Mutex(true, "MYAPP_2D36E4C1-599F-6b07-DDA5-GE059FB77E8F", out bNew))  //       +2 
            {
                if (bNew)
                {
                    //Application.Run(new FrmMain());
                    // Application.Run(new FrmLogin());
                    //Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
                    //             TrialMaker t = new TrialMaker("RoadWays", Application.StartupPath + "\\RegFile.reg",
                    // "D:" + "\\TMSetpP.dbf",
                    //"Company Name: Tech Rhombus\nPhone: +91 6351631301, Mobile: +91 9687046432",
                    //10, 500000, "143");

                    //     byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63,
                    //     4, 54, 87, 56, 123, 10, 3, 62,
                    //     7, 9, 20, 36, 37, 21, 101, 57};
                    //     t.TripleDESKey = MyOwnKey;

                    //     TrialMaker.RunTypes RT = t.ShowDialog();
                    //     bool is_trial;
                    //     if (RT != TrialMaker.RunTypes.Expired)
                    //     {
                    //         if (RT == TrialMaker.RunTypes.Full)
                    //             is_trial = false;
                    //         else
                    //             is_trial = true;

                    //         OpenDetailFormOnClose = false;

                    // if (OpenDetailFormOnClose)
                    {
                        //Application.Run(new frmCompanyMst());
                        Application.Run(new FrmMain());
                    }
                }
                else
                {
                    Process me = Process.GetCurrentProcess();
                    foreach (Process proc in Process.GetProcessesByName(me.ProcessName))
                    {
                        if (proc.Id != me.Id)
                        {
                            SetForegroundWindow(proc.MainWindowHandle);
                            break;
                        }
                    }
                }  // if
                   // }
            }// using
             //}
        }
    }
}
