using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RoadWays.Class
{

    static class Global
    {
        [DllImport("user32.dll", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SETREDRAW = 0xB;


        public static FrmSearchProperty gFrmSearchProperty = new FrmSearchProperty(); // Add : 21-05-2014 : Narendra 
        public static Form gMainFormRef;
        private static string streamType = string.Empty;
        public static int Gwidth;
        public static int Gheight;

        public static bool gBoolForceFullyClose = false;
        public static string gStrConnectionStringA = string.Empty;
        public static string gStrproviderNameA = string.Empty;
        public static string gStrConnectionDeveloper = string.Empty;
        public static string gStrProviderDeveloper = string.Empty;
        public static string gStrExeUpdateMessageFilePath = string.Empty;

        public static string gStrProdSummarySeeting = string.Empty;

        //public static string DevCellNumberFormatForFloat = "#.00;[#.0];Zero";
        public static string DevCellNumberFormatForFloat = "{0:N2}";
        public static string DevCellNumberFormatForInt = "{0:N0}";

        public static bool gBoolIS64BitOSSystem = false;
        public static string gStrVersion = "";
        public static bool gBool_Voucher_Update_On_Report = false;

        public static string gStrStrHostName = string.Empty;
        public static string gStrStrPort = string.Empty;
        public static string gStrStrServiceName = string.Empty;
        public static string gStrStrUserName = string.Empty;
        public static string gStrStrPasssword = string.Empty;

        public static string gStrDeveloperStrHostName = string.Empty;
        public static string gStrDeveloperStrPort = string.Empty;
        public static string gStrDeveloperStrServiceName = string.Empty;
        public static string gStrDeveloperStrUserName = string.Empty;
        public static string gStrDeveloperStrPasssword = string.Empty;

        public static string gStrWebStrHostName = string.Empty;
        public static string gStrWebStrDatabase = string.Empty;
        public static string gStrWebStrUserName = string.Empty;
        public static string gStrWebStrPasssword = string.Empty;

        public static DataTable DtTransfer = new DataTable();

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt
        (
            IntPtr hdcDest, // handle to destination DC
            int nXDest, // x-coord of destination upper-left corner
            int nYDest, // y-coord of destination upper-left corner
            int nWidth, // width of destination rectangle
            int nHeight, // height of destination rectangle
            IntPtr hdcSrc, // handle to source DC
            int nXSrc, // x-coordinate of source upper-left corner
            int nYSrc, // y-coordinate of source upper-left corner
            System.Int32 dwRop // raster operation code
        );


        //[DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        //public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)]
        //                                 string lpFileName);


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        //[STAThread]

        //static void Main()
        //{
        //    try
        //    {

        //        Global.gBoolIS64BitOSSystem = System.Environment.Is64BitOperatingSystem;

        //        string s = GetTimestamp();
        //        string s2 = GetTimestamp();
        //        string s3 = GetTimestamp();
        //        string s4 = GetTimestamp();
        //        string s5 = GetTimestamp();
        //        string s6 = GetTimestamp();
        //        string s7 = GetTimestamp();
        //        string s8 = GetTimestamp();

        //        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        //        Application.EnableVisualStyles();
        //        Application.SetCompatibleTextRenderingDefault(false);
        //        DevExpress.Skins.SkinManager.EnableFormSkins();
        //        //DevExpress.UserSkins.BonusSkins.Register();
        //        UserLookAndFeel.Default.SetSkinStyle("Blue");



        //        DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint();
        //        FrmLogin FrmLogin = new FrmLogin();

        //        System.Windows.Forms.Application.Idle += new EventHandler(Application_Idle);

        //        GC.Collect();
        //        FrmLogin.ShowDialog();
        //    }
        //    catch (Exception e)
        //    {
        //        Message(e.Message.ToString());
        //    }

        //}
        //static void Application_Idle(object sender, EventArgs e)
        //{

        //    //Compute();
        //}

        public static string GetCommaStr(string tstr)
        {
            if (tstr.Length > 0)
                return tstr = "'" + (tstr.Trim(',').Replace(",", "','")) + "'";
            else
                return "";
        }

        #region  For Suspend Grid To Repaing

        public static void SuspendDrawing(this Control target)
        {
            SendMessage(target.Handle, WM_SETREDRAW, 0, 0);
        }

        public static void ResumeDrawing(this Control target)
        {
            ResumeDrawing(target, true);
        }
        public static void ResumeDrawing(this Control target, bool redraw)
        {
            SendMessage(target.Handle, WM_SETREDRAW, 1, 0);

            if (redraw)
            {
                target.Refresh();
            }
        }

        #endregion


        #region Count Days

        public static int FindHoliday(int pIntYear, int pIntMonth) // Khushbu 29/08/2014
        {

            InterfaceLayer Ope = new InterfaceLayer();
            BLL.Validation Val = new BLL.Validation();

            string StrSql = " AND (EXTRACT(YEAR FROM holiday_date)) = " + pIntYear + "";
            StrSql = StrSql + " AND TRIM(TO_CHAR(TO_DATE(holiday_date), 'MM')) = " + pIntMonth + "";
            StrSql = StrSql + " AND BRANCH_CODE = " + BLL.GlobalDec.gEmployeeProperty.Branch_Code + "";
            StrSql = StrSql + " AND LEAVE_TYPE_CODE IN  (4,6,7)";

            return Val.ToInt(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Hr_Holiday_Master", "COUNT(1)", StrSql));

        }

        public static int FindHoliday(string pStrFromDate, string pStrToDate) // Khushbu 29/08/2014
        {
            InterfaceLayer Ope = new InterfaceLayer();
            BLL.Validation Val = new BLL.Validation();

            string StrSql = " AND holiday_date BETWEEN '" + pStrFromDate + "' AND '" + pStrToDate + "'";
            StrSql = StrSql + " AND BRANCH_CODE = " + BLL.GlobalDec.gEmployeeProperty.Branch_Code + "";
            StrSql = StrSql + " AND LEAVE_TYPE_CODE IN  (4,6,7)";

            return Val.ToInt(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Hr_Holiday_Master", "COUNT(1)", StrSql));
        }

        #endregion

        #region Message Box



        public static void Message(string pStrText, string pStrTitle = "", MessageBoxButtons pMessageBoxButton = MessageBoxButtons.OK, MessageBoxIcon pMessageBoxIcon = MessageBoxIcon.None)
        {
            if (pStrTitle == "")
            {
                pStrTitle = BLL.GlobalDec.gStrMsgTitle;
            }
            DevExpress.XtraEditors.XtraMessageBox.Show(pStrText, pStrTitle, pMessageBoxButton, pMessageBoxIcon);
        }

        public static void ErrorMessage(string pStrText, string pStrTitle = "", MessageBoxButtons pMessageBoxButton = MessageBoxButtons.OK, MessageBoxIcon pMessageBoxIcon = MessageBoxIcon.Error)
        {
            if (pStrTitle == "")
            {
                pStrTitle = BLL.GlobalDec.gStrMsgTitle;
            }
            DevExpress.XtraEditors.XtraMessageBox.Show(pStrText, pStrTitle, pMessageBoxButton, pMessageBoxIcon);
        }

        #endregion

        #region Other Function

        // Add : Narendra ; 18-Mar-2015
        public enum Exports
        {
            pdf = 1,
            xls = 2,
            rtf = 3,
            txt = 4,
            html = 5,
            csv = 6
        }
        public static void Export(string format, GridView gvExportGrid)
        {
            try
            {
                if (gvExportGrid.RowCount < 1)
                {
                    Message("No Rows to Export");
                    return;
                }
                string dlgHeader = string.Empty;
                string dlgFilter = string.Empty;
                format = format.ToLower();
                if (format.Equals(Exports.xls.ToString()))
                {
                    dlgHeader = "Export to Excel";
                    dlgFilter = "Excel files 97-2003 (*.xls)|*.xls|Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*";
                }
                else if (format.Equals(Exports.pdf.ToString()))
                {
                    dlgHeader = "Export to PDF";
                    dlgFilter = "PDF (*.PDF)|*.PDF";
                }
                else if (format.Equals(Exports.rtf.ToString()))
                {
                    dlgHeader = "Export to RTF";
                    dlgFilter = "Word (*.doc) |*.doc;*.rtf|(*.txt) |*.txt|(*.*) |*.*";
                }
                else if (format.Equals(Exports.txt.ToString()))
                {
                    dlgHeader = "Export to Text";
                    dlgFilter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                }
                else if (format.Equals(Exports.html.ToString()))
                {
                    dlgHeader = "Export to HTML";
                    dlgFilter = "Html files (*.html)|*.html|Htm files (*.htm)|*.htm";
                }
                else if (format.Equals(Exports.csv.ToString()))
                {
                    dlgHeader = "Export to CSV";
                    dlgFilter = "csv (*.csv)|*.csv";
                }

                SaveFileDialog svDialog = new SaveFileDialog();
                svDialog.DefaultExt = format;
                svDialog.Title = dlgHeader;
                svDialog.FileName = "Report";
                svDialog.Filter = dlgFilter;
                if ((svDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK))
                {
                    string Filepath = svDialog.FileName;
                    switch (format)
                    {
                        case "pdf":
                            gvExportGrid.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            gvExportGrid.ExportToXls(Filepath);
                            break;
                        case "rtf":
                            gvExportGrid.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            gvExportGrid.ExportToText(Filepath);
                            break;
                        case "html":
                            gvExportGrid.ExportToHtml(Filepath);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.Message.ToString());
            }
        }

        public static DataTable GetCSVObjList(string filename)
        {
            DataTable DTab = new DataTable();
            // Obvioulsly you would have some actual validation and error handling

            string[] Strline = File.ReadAllLines(filename);
            if (Strline.Count() == 0)
            {
                return DTab;
            }

            int n = 1;
            string[] Columns = Strline[0].Split(new char[] { ',' });
            foreach (string Str in Columns)
            {
                if (DTab.Columns.Contains("F" + n.ToString()) == false)
                {
                    DTab.Columns.Add("F" + n.ToString());
                }
                n++;
            }

            foreach (string line in Strline)
            {
                n = 1;
                string[] fields = line.Split(new char[] { ',' });

                DataRow DROw = DTab.NewRow();
                foreach (string Str in fields)
                {
                    DROw["F" + n.ToString()] = fields[n - 1];
                    n++;
                }
                DTab.Rows.Add(DROw);
            }
            return DTab;
        }

        public static double FindHHMMFormat(double DouValue)
        {
            BLL.Validation Val = new BLL.Validation();
            double i1 = 0;
            double i2 = DouValue;

            while (i2 >= 60)
            {
                i1 = i1 + 1;
                i2 = i2 - 60;
            }
            double answer = Val.Val(i1.ToString() + "." + ((i2 < 10) == true ? "0" + i2.ToString() : i2.ToString()));
            return answer;
        }

        public static String GetTimestamp()
        {
            //return ((DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds).ToString();

            DateTime DT = DateTime.Now;
            return DT.ToString("yyyyMMddHHmmssfffff");
            //long l = DateTime.Now.ToFileTime();
            //string ticks = DateTime.Now.Ticks.ToString();
            //ticks = ticks.Substring(ticks.Length - 15);
            //return l.ToString();
        }
        public static String GetMonthName(int pIntMonthNo)
        {
            if (pIntMonthNo == 1) return "Jan";
            else if (pIntMonthNo == 2) return "Feb";
            else if (pIntMonthNo == 3) return "Mar";
            else if (pIntMonthNo == 4) return "Apr";
            else if (pIntMonthNo == 5) return "May";
            else if (pIntMonthNo == 6) return "Jun";
            else if (pIntMonthNo == 7) return "Jul";
            else if (pIntMonthNo == 8) return "Aug";
            else if (pIntMonthNo == 9) return "Sep";
            else if (pIntMonthNo == 10) return "Oct";
            else if (pIntMonthNo == 11) return "Nov";
            else if (pIntMonthNo == 12) return "Dec";
            else return "";

        }
        public static Int32 GetMonthCode(string pStrMonthName)
        {
            if (pStrMonthName.ToUpper() == "JAN") return 1;
            else if (pStrMonthName.ToUpper() == "FEB") return 2;
            else if (pStrMonthName.ToUpper() == "MAR") return 3;
            else if (pStrMonthName.ToUpper() == "APR") return 4;
            else if (pStrMonthName.ToUpper() == "MAY") return 5;
            else if (pStrMonthName.ToUpper() == "JUN") return 6;
            else if (pStrMonthName.ToUpper() == "JUL") return 7;
            else if (pStrMonthName.ToUpper() == "AUG") return 8;
            else if (pStrMonthName.ToUpper() == "SEP") return 9;
            else if (pStrMonthName.ToUpper() == "OCT") return 10;
            else if (pStrMonthName.ToUpper() == "NOV") return 11;
            else if (pStrMonthName.ToUpper() == "DEC") return 12;
            else return 0;

        }

        public static bool BarcodePrint(string pStrBarcode)
        {
            try
            {
                string fileLoc = Application.StartupPath + "\\Barcode.txt";
                FileStream fs = null;

                if (File.Exists(fileLoc) == true)
                {
                    File.Delete(fileLoc);
                }
                if ((!System.IO.File.Exists(fileLoc)))
                {
                    fs = System.IO.File.Create(fileLoc);
                    using (fs)
                    {

                    }
                    StreamWriter sw = new StreamWriter(fileLoc);
                    using (sw)
                    {

                        sw.WriteLine("G0");
                        sw.WriteLine("n");
                        sw.WriteLine("M0500");
                        sw.WriteLine("O0214");
                        sw.WriteLine("V0");
                        sw.WriteLine("t1");
                        sw.WriteLine("Kf0070");
                        sw.WriteLine("SG");
                        sw.WriteLine("L");

                        sw.WriteLine("D11");
                        sw.WriteLine("H19");
                        sw.WriteLine("PG");
                        sw.WriteLine("pG");
                        sw.WriteLine("SG");
                        sw.WriteLine("A2");
                        sw.WriteLine("1e4202700250013B" + pStrBarcode);
                        sw.WriteLine("ySPM");
                        sw.WriteLine("1911A1000100040" + pStrBarcode);
                        sw.WriteLine("Q0001");
                        sw.WriteLine("E");
                    }

                    if (File.Exists(Application.StartupPath + "\\PRINTBARCODE.BAT") && File.Exists(fileLoc))
                    {
                        //Microsoft.VisualBasic.Interaction.Shell(Application.StartupPath + "\\PRINTBARCODE.BAT " + fileLoc, AppWinStyle.Hide, true, -1);
                    }

                    sw.Close();
                    sw.Dispose();
                    sw = null;



                }
            }
            catch (Exception Ex)
            {

                Global.Message(Ex.Message);
            }

            //Process.Start(Application.StartupPath + "\\tagprint.bat");

            return true;
        }

        public static Boolean CheckFormVisible(Form pfrm)
        {
            if (pfrm == null)
            {
                return false;
            }
            else if (pfrm.IsHandleCreated == false)
            {
                return false;
            }
            else
            {
                pfrm.Focus();
                return true;
            }
        }

        public static bool OnKeyPressToOpenPopup(KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.F1)
            {
                return true;
            }
            if (Keys.Control == Control.ModifierKeys
                || Keys.Alt == Control.ModifierKeys
                || Keys.Shift == Control.ModifierKeys
                )
            {
                return false;
            }

            if (e.KeyChar != (Char)Keys.Enter
                && e.KeyChar != (Char)Keys.Back
                && e.KeyChar != (Char)Keys.Escape
                && e.KeyChar != (Char)Keys.Delete
                && e.KeyChar != (Char)Keys.Left
                && e.KeyChar != (Char)Keys.Right
                && e.KeyChar != (Char)Keys.Up
                )
            {
                return true;
            }
            return false;
        }

        public static byte[] ImageToByte(Image pImage)
        {
            //MemoryStream MS = new MemoryStream();
            //pImage.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg);
            //byte[] byteArray = MS.ToArray();
            //MS.Close();
            //MS.Dispose();
            //MS = null;
            //return byteArray;

            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                pImage.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }

        public static byte[] ImageToByte(Bitmap pImage)
        {
            //MemoryStream MS = new MemoryStream();
            //pImage.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg);
            //byte[] byteArray = MS.ToArray();
            //MS.Close();
            //MS.Dispose();
            //MS = null;
            //return byteArray;

            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                pImage.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;

        }

        public static void OpenForm(string pStrFormName, string pStrReportCode, string pStrNamespace = "Report")
        {
            try
            {
                Form objForm = new Form();
                string FullTypeName;
                Type FormInstanceType;
                FullTypeName = (Application.ProductName + ("." + pStrNamespace + "." + pStrFormName));
                FormInstanceType = Type.GetType(FullTypeName, true, true);
                objForm = ((Form)(Activator.CreateInstance(FormInstanceType)));
                //Settings objSettings = new Settings();
                objForm.MdiParent = gMainFormRef;
                objForm.Tag = pStrReportCode;
                objForm.Show();
            }
            catch
            {
                Message(pStrFormName + " :  Form Not Exists");
            }
        }

        public static string GetFinancialYear(string pStrDate)
        {
            BLL.Validation Val = new BLL.Validation();
            string StrReturn = "";
            DateTime DT = DateTime.Parse(pStrDate);
            if (DT.Month >= 4 && DT.Month <= 12)
            {
                StrReturn = DT.Year.ToString() + "-" + Val.Right((DT.Year + 1).ToString(), 2);
            }
            else
            {
                StrReturn = (DT.Year - 1).ToString() + "-" + Val.Right((DT.Year).ToString(), 2);
            }

            Val = null;
            return StrReturn;
        }

        public static string GetFinancialYearNew(string pStrDate)
        {
            BLL.Validation Val = new BLL.Validation();
            string StrReturn = "";
            DateTime DT = DateTime.Parse(pStrDate);
            if (DT.Month >= 1 && DT.Month <= 9)
            {
                StrReturn = DT.Year.ToString() + "0" + Val.Right(DT.Month.ToString(), 2);
            }
            else
            {
                StrReturn = DT.Year.ToString() + "" + Val.Right(DT.Month.ToString(), 2);
            }

            Val = null;
            return StrReturn;
        }

        public static string GetFinancialYearFullFormat(string pStrDate)
        {
            BLL.Validation Val = new BLL.Validation();
            string StrReturn = "";
            DateTime DT = DateTime.Parse(pStrDate);
            if (DT.Month >= 4 && DT.Month <= 12)
            {
                StrReturn = DT.Year.ToString() + "-" + (DT.Year + 1).ToString();
            }
            else
            {
                StrReturn = (DT.Year - 1).ToString() + "-" + (DT.Year).ToString();
            }

            Val = null;
            return StrReturn;
        }

        public static string RemoveDuplicateFromString(string pStrMainString, char SplitChar = ' ', string Seperator = " ")
        {
            return string.Join(Seperator, pStrMainString.Split(SplitChar).Distinct());
        }

        public static string DataGridExportToExcel(DevExpress.XtraGrid.Views.Grid.GridView pDataGrid, string StrFileName)
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Blue");

            string StrFilePath = Application.StartupPath + "\\" + StrFileName + ".xls";

            if (File.Exists(StrFilePath))
            {
                File.Delete(StrFilePath);
            }

            if (pDataGrid.DataRowCount == 0) return "";

            DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions { SheetName = StrFileName, Suppress65536RowsWarning = false };

            pDataGrid.ExportToXls(StrFilePath, options);

            return StrFilePath;
        }

        public static string ExportFormAsImage(Form pThis, string StrFileName)
        {
            string StrFilePath = string.Empty;
            try
            {
                StrFilePath = Application.StartupPath + "\\" + StrFileName + ".jpg";
                Graphics g1 = pThis.CreateGraphics();
                Image MyImage = new Bitmap(pThis.ClientRectangle.Width, pThis.ClientRectangle.Height, g1);
                Graphics g2 = Graphics.FromImage(MyImage);
                IntPtr dc1 = g1.GetHdc();
                IntPtr dc2 = g2.GetHdc();
                BitBlt(dc2, 0, 0, pThis.ClientRectangle.Width, pThis.ClientRectangle.Height, dc1, 0, 0, 13369376);
                g1.ReleaseHdc(dc1);
                g2.ReleaseHdc(dc2);
                MyImage.Save(StrFilePath, ImageFormat.Jpeg);
                FileStream fileStream = new FileStream(StrFilePath, FileMode.Open, FileAccess.Read);

                fileStream.Close();
                fileStream.Dispose();
                fileStream = null;

                g2.Dispose();
                g2 = null;

                MyImage.Dispose();
                MyImage = null;
            }
            catch (Exception)
            {

            }
            return StrFilePath;
        }

        public static double NumberConversion(double pDouNumber, string pToNumberFormat)
        {
            BLL.Validation Val = new BLL.Validation();
            double DouAnswer = 0;
            if (pToNumberFormat == "HUNDREDS")
            {
                DouAnswer = Val.Val(pDouNumber / 100);
            }
            else if (pToNumberFormat == "THOUSANDS")
            {
                DouAnswer = Val.Val(pDouNumber / 1000);
            }
            else if (pToNumberFormat == "LAKHS")
            {
                DouAnswer = Val.Val(pDouNumber / 100000);
            }
            else if (pToNumberFormat == "MILLIONS")
            {
                DouAnswer = Val.Val(pDouNumber / 10000000);
            }
            else if (pToNumberFormat == "CRORES")
            {
                DouAnswer = Val.Val(pDouNumber / 10000000);
            }
            else if (pToNumberFormat == "BILLIONS")
            {
                DouAnswer = Val.Val(pDouNumber / 1000000000);
            }
            else if (pToNumberFormat == "TRILLIONS")
            {
                DouAnswer = Val.Val(pDouNumber / 1000000000000);
            }
            else
            {
                DouAnswer = pDouNumber;
            }
            Val = null;
            return DouAnswer;
        }


        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static DataSet ImportExcelXLS(string FileName, bool hasHeaders, int IntIMEX = 0)
        {
            string HDR = hasHeaders ? "Yes" : "No";
            // string HDR = "No";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                //    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=1\"";
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=" + IntIMEX + "\"";

            else
                //strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=" + IntIMEX + "\"";

            DataSet output = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    if (!sheet.EndsWith("_"))
                    {
                        try
                        {
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                            cmd.CommandType = CommandType.Text;

                            DataTable outputTable = new DataTable(sheet);
                            output.Tables.Add(outputTable);
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }
                }
            }
            return output;
        }

        public static DataTable ImportExcelXLSWithSheetName(string FileName, bool hasHeaders, string SheetName, int IntIMEX = 0)
        {
            string HDR = hasHeaders ? "Yes" : "No";
            // string HDR = "No";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                //    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=1\"";
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=" + IntIMEX + "\"";

            else
                //strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=" + IntIMEX + "\"";

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = new DataTable("Temp");
                //DataTable schemaTable = conn.GetOleDbSchemaTable(
                //    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                //foreach (DataRow schemaRow in schemaTable.Rows)
                //{
                try
                {
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + SheetName + "]", conn);
                    cmd.CommandType = CommandType.Text;

                    new OleDbDataAdapter(cmd).Fill(schemaTable);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", SheetName, FileName), ex);
                }
                return schemaTable;
                //}
            }
        }

        public static string GetSplitedCriteriaForReport(string PStr)
        {
            BLL.Validation Val = new BLL.Validation();
            string ResStr = "";

            if (PStr == "")
            {
                ResStr = "";

            }
            else
            {
                foreach (string str in PStr.Split(','))
                {
                    ResStr += "'" + Val.Trim(str) + "',";

                }

                if (ResStr.Length != 0)
                {
                    ResStr = ResStr.Substring(0, ResStr.Length - 1);
                }
            }
            Val = null;
            return ResStr;
        }

        public static string FindDifferenceGroup(double ConsPer, double ReceivePer)
        {
            double DouDiff = ConsPer - ReceivePer;

            if (Math.Round(DouDiff, 2) >= 10)
                return "A. MORE THAN 10";
            else if (Math.Round(DouDiff, 2) <= 9.99 && Math.Round(DouDiff, 2) >= 9)
                return "B. 9 to 9.99";
            else if (Math.Round(DouDiff, 2) <= 8.99 && Math.Round(DouDiff, 2) >= 8)
                return "C. 8 to 8.99";
            else if (Math.Round(DouDiff, 2) <= 7.99 && Math.Round(DouDiff, 2) >= 7)
                return "D. 7 to 7.99";
            else if (Math.Round(DouDiff, 2) <= 6.99 && Math.Round(DouDiff, 2) >= 6)
                return "E. 6 to 6.99";
            else if (Math.Round(DouDiff, 2) <= 5.99 && Math.Round(DouDiff, 2) >= 5)
                return "F. 5 to 5.99";
            else if (Math.Round(DouDiff, 2) <= 4.99 && Math.Round(DouDiff, 2) >= 4)
                return "G. 4 to 4.99";
            else if (Math.Round(DouDiff, 2) <= 3.99 && Math.Round(DouDiff, 2) >= 3)
                return "H. 3 to 3.99";
            else if (Math.Round(DouDiff, 2) <= 2.99 && Math.Round(DouDiff, 2) >= 2)
                return "I. 2 to 2.99";
            else if (Math.Round(DouDiff, 2) <= 1.99 && Math.Round(DouDiff, 2) >= 1)
                return "J. 1 to 1.99";
            else if (Math.Round(DouDiff, 2) <= 0.99 && Math.Round(DouDiff, 2) >= 0)
                return "K. 0 to 0.99";
            else if (Math.Round(DouDiff, 2) <= -0.01 && Math.Round(DouDiff, 2) >= -0.99)
                return "L. -0.01 to -0.99";
            else if (Math.Round(DouDiff, 2) <= -1 && Math.Round(DouDiff, 2) >= -1.99)
                return "M. -1 to -1.99";
            else if (Math.Round(DouDiff, 2) <= -2 && Math.Round(DouDiff, 2) >= -2.99)
                return "N. -2 to -2.99";
            else if (Math.Round(DouDiff, 2) <= -3 && Math.Round(DouDiff, 2) >= -3.99)
                return "O. -3 to -3.99";
            else if (Math.Round(DouDiff, 2) <= -4 && Math.Round(DouDiff, 2) >= -4.99)
                return "P. -4 to -4.99";
            else if (Math.Round(DouDiff, 2) <= -5 && Math.Round(DouDiff, 2) >= -5.99)
                return "Q. -5 to -5.99";
            else if (Math.Round(DouDiff, 2) <= -6 && Math.Round(DouDiff, 2) >= -6.99)
                return "R. -6 to -6.99";
            else if (Math.Round(DouDiff, 2) <= -7 && Math.Round(DouDiff, 2) >= -7.99)
                return "S. -7 to -7.99";
            else if (Math.Round(DouDiff, 2) <= -8 && Math.Round(DouDiff, 2) >= -8.99)
                return "T. -8 to -8.99";
            else if (Math.Round(DouDiff, 2) <= -9 && Math.Round(DouDiff, 2) >= -9.99)
                return "U. -9 to -9.99";
            else if (Math.Round(DouDiff, 2) <= -10)
                return "V. MORE THAN -10";
            else
                return "";
        }




        #endregion

        #region Temporary Table

        public static DataTable DTabStockFlag()
        {
            DataTable DTab = new DataTable("StatusType");
            DTab.Columns.Add("STOCKFLAG");
            DTab.Columns.Add("STOCKFLAG1");
            DTab.Rows.Add("STOCK3", "STOCK3");
            DTab.Rows.Add("STOCK4", "STOCK4");
            return DTab;
        }

        public static DataTable DTabDiscription()
        {
            DataTable DTab = new DataTable("StatusType");

            DTab.Columns.Add("DESCRIPTION");
            DTab.Columns.Add("DESCRIPTION1");

            DTab.Rows.Add(".", ".");
            DTab.Rows.Add("B", "B");
            DTab.Rows.Add("D", "D");
            DTab.Rows.Add("E", "E");
            DTab.Rows.Add("F", "F");
            DTab.Rows.Add("FANCY", "FANCY");
            DTab.Rows.Add("G", "G");
            DTab.Rows.Add("H", "H");
            DTab.Rows.Add("I", "I");
            DTab.Rows.Add("J", "J");
            DTab.Rows.Add("K", "K");
            DTab.Rows.Add("L", "L");
            DTab.Rows.Add("M", "M");
            DTab.Rows.Add("N", "N");
            DTab.Rows.Add("N.A", "N.A");
            DTab.Rows.Add("O", "O");
            DTab.Rows.Add("OVAL", "OVAL");
            DTab.Rows.Add("P", "P");
            DTab.Rows.Add("TLB", "TLB");
            DTab.Rows.Add("TTLB", "TTLB");
            DTab.Rows.Add("WHITE", "WHITE");

            return DTab;
        }

        public static DataTable DTabMonth()
        {
            DataTable DTab = new DataTable("Month");
            DTab.Columns.Add("Month");
            DTab.Columns.Add("SrNo");
            DTab.Rows.Add("January", "1");
            DTab.Rows.Add("February", "2");
            DTab.Rows.Add("March", "3");
            DTab.Rows.Add("April", "4");
            DTab.Rows.Add("May", "5");
            DTab.Rows.Add("June", "6");
            DTab.Rows.Add("July", "7");
            DTab.Rows.Add("August", "8");
            DTab.Rows.Add("September", "9");
            DTab.Rows.Add("October", "10");
            DTab.Rows.Add("November", "11");
            DTab.Rows.Add("Decembar", "12");
            return DTab;
        }

        public static DataTable DTabDealType()
        {
            DataTable DTab = new DataTable("Month");
            DTab.Columns.Add("DEALTYPE");
            DTab.Columns.Add("DEALTYPE1");
            DTab.Rows.Add("NOT-APPLICABLE", "NOT-APPLICABLE");
            DTab.Rows.Add("CONTRACT", "CONTRACT");
            DTab.Rows.Add("NON-CONTRACT", "NON-CONTRACT");

            return DTab;
        }

        public static DataTable DTabRelation()
        {
            DataTable DTab = new DataTable("Month");
            DTab.Columns.Add("Relation");
            DTab.Rows.Add("GRAND-FATHER");
            DTab.Rows.Add("GRAND-MONTHER");
            DTab.Rows.Add("FATHER");
            DTab.Rows.Add("MOTHER");
            DTab.Rows.Add("ELDER BROTHER");
            DTab.Rows.Add("YOUNGER BROTHER");

            DTab.Rows.Add("BROTHER'S WIFE");

            DTab.Rows.Add("SISTER");

            DTab.Rows.Add("HUSBAND");
            DTab.Rows.Add("WIFE");
            DTab.Rows.Add("UNCLE");
            DTab.Rows.Add("ANTY");
            DTab.Rows.Add("SON");
            DTab.Rows.Add("DAUGHTER");
            DTab.Rows.Add("GRANDSON");
            DTab.Rows.Add("GRANDDAUGHTER");
            return DTab;
        }

        public static DataTable DTabNumericFormat()
        {
            DataTable DTab = new DataTable("");
            DTab.Columns.Add("FORMAT");
            DTab.Rows.Add("N0");
            DTab.Rows.Add("N1");
            DTab.Rows.Add("N2");
            DTab.Rows.Add("N3");
            DTab.Rows.Add("N4");
            DTab.Rows.Add("N5");
            DTab.Rows.Add("N6");
            DTab.Rows.Add("N7");
            DTab.Rows.Add("N8");
            DTab.Rows.Add("N9");
            DTab.Rows.Add("N10");

            return DTab;
        }

        public static DataTable DTabYESNO()
        {
            DataTable DTab = new DataTable("Month");
            DTab.Columns.Add("Option");
            DTab.Rows.Add("YES");
            DTab.Rows.Add("NO");
            return DTab;
        }

        public static DataTable DTabSawType()
        {
            DataTable DTab = new DataTable("Month");
            DTab.Columns.Add("Option");
            DTab.Columns.Add("Option1");
            DTab.Rows.Add("RR", "RR");

            DTab.Rows.Add("TOP-M", "TOP-M");
            DTab.Rows.Add("CENTRE-M", "CENTRE-M");
            DTab.Rows.Add("TOP-SS-DM", "TOP-SS-DM");
            DTab.Rows.Add("TOP-TSS-DM", "TOP-TSS-DM");
            DTab.Rows.Add("CENT-SS-DM", "CENT-SS-DM");
            DTab.Rows.Add("CENT-TSS-DM", "CENT-TSS-DM");
            DTab.Rows.Add("PIE-DM", "PIE-DM");
            DTab.Rows.Add("PLATE-M", "PLATE-M");
            DTab.Rows.Add("KERF", "KERF");
            DTab.Rows.Add("BRUTING-DM", "BRUTING-DM");

            DTab.Rows.Add("T1-DM", "T1-DM");
            DTab.Rows.Add("T2-DM", "T2-DM");
            DTab.Rows.Add("T3-DM", "T3-DM");
            DTab.Rows.Add("T4-DM", "T4-DM");
            DTab.Rows.Add("T5-DM", "T5-DM");
            DTab.Rows.Add("T1-M", "T1-M");
            DTab.Rows.Add("T2-M", "T2-M");
            DTab.Rows.Add("T3-M", "T3-M");
            DTab.Rows.Add("T4-M", "T4-M");
            DTab.Rows.Add("T5-M", "T5-M");

            return DTab;
        }

        #endregion

        public static DialogResult Confirm(string pStrText, string pStrTitle = "", MessageBoxButtons btns = MessageBoxButtons.OK, MessageBoxIcon pMessageBoxIcon = MessageBoxIcon.Information)
        {
            if (pStrTitle == "")
            {
                pStrTitle = BLL.GlobalDec.gStrMsgTitle;
            }
            return MessageBox.Show(pStrText, pStrTitle, btns, pMessageBoxIcon, MessageBoxDefaultButton.Button1);
        }

        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist) // Khushbu 16/07/2014
        {
            DataTable dtReturn = new DataTable();
            // column names 
            PropertyInfo[] oProps = null;
            if (varlist == null) return dtReturn;
            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public static Boolean CheckIPValid(String strIP)
        {
            //  Split string by ".", check that array length is 3
            char chrFullStop = '.';
            string[] arrOctets = strIP.Split(chrFullStop);
            if (arrOctets.Length != 4)
            {
                return false;
            }
            //  Check each substring checking that the int value is less than 255 and that is char[] length is !> 2
            Int16 MAXVALUE = 255;
            Int32 temp; // Parse returns Int32
            foreach (String strOctet in arrOctets)
            {
                if (strOctet.Length > 3)
                {
                    return false;
                }

                temp = int.Parse(strOctet);
                if (temp > MAXVALUE)
                {
                    return false;
                }
            }
            return true;
        }

        public static void LOOKUPCompany(LookUpEdit lookup)
        {
            CompanyMaster objCompany = new CompanyMaster();
            DataTable Company = objCompany.GetData();
            lookup.Properties.DataSource = Company;
            lookup.Properties.ValueMember = "COMPANY_CODE";
            lookup.Properties.DisplayMember = "COMPANY_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        public static void LOOKUPBranch(LookUpEdit lookup)
        {
            BranchMaster objBranch = new BranchMaster();
            DataTable Branch = objBranch.GetData();
            lookup.Properties.DataSource = Branch;
            lookup.Properties.ValueMember = "BRANCH_CODE";
            lookup.Properties.DisplayMember = "BRANCH_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        public static void LOOKUPLocation(LookUpEdit lookup)
        {
            LocationMaster objLocation = new LocationMaster();
            DataTable Location = objLocation.GetData();
            lookup.Properties.DataSource = Location;
            lookup.Properties.ValueMember = "LOCATION_CODE";
            lookup.Properties.DisplayMember = "LOCATION_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        public static void LOOKUPCountry(LookUpEdit lookup)
        {
            CountryMaster objCountry = new CountryMaster();
            DataTable Country = objCountry.GetData();
            lookup.Properties.DataSource = Country;
            lookup.Properties.ValueMember = "COUNTRY_CODE";
            lookup.Properties.DisplayMember = "COUNTRY_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }
        public static void LOOKUPState(LookUpEdit lookup)
        {
            StateMaster objState = new StateMaster();
            DataTable State = objState.GetData();
            lookup.Properties.DataSource = State;
            lookup.Properties.ValueMember = "STATE_CODE";
            lookup.Properties.DisplayMember = "STATE_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }
        public static void LOOKUPCity(LookUpEdit lookup)
        {
            CityMaster objCity = new CityMaster();
            DataTable City = objCity.GetData();
            lookup.Properties.DataSource = City;
            lookup.Properties.ValueMember = "CITY_CODE";
            lookup.Properties.DisplayMember = "CITY_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        public static void LOOKUPTruck(LookUpEdit lookup)
        {
            TruckMaster objTruck = new TruckMaster();
            DataTable Truck = objTruck.GetData();
            lookup.Properties.DataSource = Truck;
            lookup.Properties.ValueMember = "Truck_ID";
            lookup.Properties.DisplayMember = "Truck_No";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }
        public static void LOOKUPItemGroup(LookUpEdit lookup)
        {
            ItemGroupMaster objItemGroup = new ItemGroupMaster();
            DataTable ItemGroup = objItemGroup.GetData();
            lookup.Properties.DataSource = ItemGroup;
            lookup.Properties.ValueMember = "ITEM_GROUP_CODE";
            lookup.Properties.DisplayMember = "ITEM_GROUP_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }
        public static void LOOKUPItemCategory(LookUpEdit lookup)
        {
            ItemCategoryMaster objItemCategory = new ItemCategoryMaster();
            DataTable ItemCategory = objItemCategory.GetData();
            lookup.Properties.DataSource = ItemCategory;
            lookup.Properties.ValueMember = "ITEM_CATEGORY_CODE";
            lookup.Properties.DisplayMember = "ITEM_CATEGORY_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        public static void LOOKUPItemHSN(LookUpEdit lookup)
        {
            ItemHSNMaster objItemHSN = new ItemHSNMaster();
            DataTable ItemHSN = objItemHSN.GetData();
            lookup.Properties.DataSource = ItemHSN;
            lookup.Properties.ValueMember = "HSN_ID";
            lookup.Properties.DisplayMember = "HSN_CODE";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        public static void LOOKUPUnitType(LookUpEdit lookup)
        {
            ItemHSNMaster objItemUnitType = new ItemHSNMaster();
            DataTable ItemUnitType = objItemUnitType.GetData_UnitType();
            lookup.Properties.DataSource = ItemUnitType;
            lookup.Properties.ValueMember = "Unit_ID";
            lookup.Properties.DisplayMember = "Unit_Name";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        public static void LOOKUPUnitType(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            ItemHSNMaster objItemUnitType = new ItemHSNMaster();
            DataTable ItemUnitType = objItemUnitType.GetData_UnitType();
            lookup.DataSource = ItemUnitType;
            lookup.ValueMember = "Unit_ID";
            lookup.DisplayMember = "Unit_Name";
            //   lookup.EditValue = null;            
        }



        // Repository Coding
        public static void LOOKUPCompanyRep(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            CompanyMaster objCompany = new CompanyMaster();
            DataTable Company = objCompany.GetData();
            lookup.DataSource = Company;
            lookup.ValueMember = "COMPANY_CODE";
            lookup.DisplayMember = "COMPANY_NAME";
            //   lookup.EditValue = null;            
        }

        public static void LOOKUPItemHSNRep(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            ItemHSNMaster objItemHSN = new ItemHSNMaster();
            DataTable ItemHSN = objItemHSN.GetData();
            lookup.DataSource = ItemHSN;
            lookup.ValueMember = "HSN_ID";
            lookup.DisplayMember = "HSN_CODE";
        }

        public static void LOOKUPBranchRep(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            BranchMaster objBranch = new BranchMaster();
            DataTable Branch = objBranch.GetData();
            lookup.DataSource = Branch;
            lookup.ValueMember = "BRANCH_CODE";
            lookup.DisplayMember = "BRANCH_NAME";
            //   lookup.EditValue = null;            
        }
        public static void LOOKUPLocationRep(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            LocationMaster objLocation = new LocationMaster();
            DataTable Location = objLocation.GetData();
            lookup.DataSource = Location;
            lookup.ValueMember = "LOCATION_CODE";
            lookup.DisplayMember = "LOCATION_NAME";
            //   lookup.EditValue = null;            
        }

        public static void LOOKUPFromParty(LookUpEdit lookup, Ledger_MasterProperty _Type = null)
        {
            LedgerMaster objParty = new LedgerMaster();
            if (_Type == null)
            {
                _Type = new Ledger_MasterProperty();
            }
            _Type.Active = 1;
            DataTable Party = objParty.From_Party_GetData(_Type);
            Party.DefaultView.Sort = "FROM_Party_NAME asc";
            lookup.Properties.DataSource = Party;
            lookup.Properties.ValueMember = "FROM_Party_Code";
            lookup.Properties.DisplayMember = "FROM_Party_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }
        public static void LOOKUPFrom_PartyName(ComboBoxEdit lookup)
        {
            LedgerMaster objFromParty = new LedgerMaster();
            DataTable From_Party = objFromParty.From_Party_Distinct_GetData();

            foreach (DataRow DRaw in From_Party.Rows)
            {
                lookup.Properties.Items.Add(DRaw["From_Party_Name"]);
                lookup.Properties.Items.Add(DRaw["From_Party_GSTNo"]);
                lookup.ClosePopup();
            }
        }
        public static void LOOKUPTo_PartyName(ComboBoxEdit lookup)
        {
            LedgerMaster objFromParty = new LedgerMaster();
            DataTable From_Party = objFromParty.To_Party_Distinct_GetData();

            foreach (DataRow DRaw in From_Party.Rows)
            {
                lookup.Properties.Items.Add(DRaw["To_Party_Name"]);
                lookup.Properties.Items.Add(DRaw["To_Party_GSTNo"]);
                lookup.ClosePopup();
            }
        }
        public static void LOOKUPTo_Description(ComboBoxEdit lookup)
        {
            LedgerMaster objFromParty = new LedgerMaster();
            DataTable Description = objFromParty.Description_Distinct_GetData();

            foreach (DataRow DRaw in Description.Rows)
            {
                lookup.Properties.Items.Add(DRaw["description"]);
                lookup.ClosePopup();
            }
        }
        public static void LOOKUPToParty(LookUpEdit lookup, Ledger_MasterProperty _Type = null)
        {
            LedgerMaster objParty = new LedgerMaster();
            if (_Type == null)
            {
                _Type = new Ledger_MasterProperty();
            }
            _Type.Active = 1;
            DataTable Party = objParty.To_Party_GetData(_Type);
            Party.DefaultView.Sort = "To_Party_Name asc";
            lookup.Properties.DataSource = Party;
            lookup.Properties.ValueMember = "To_Party_Code";
            lookup.Properties.DisplayMember = "To_Party_Name";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        public static void ComboToParty(DevExpress.XtraEditors.CheckedComboBoxEdit lookup, Ledger_MasterProperty _Type = null)
        {
            LedgerMaster objParty = new LedgerMaster();
            if (_Type == null)
            {
                _Type = new Ledger_MasterProperty();
            }
            _Type.Active = 1;

            DataTable Party = objParty.To_Party_GetData(_Type);
            Party.DefaultView.Sort = "To_Party_Name asc";
            lookup.Properties.DataSource = Party;
            lookup.Properties.ValueMember = "To_Party_Code";
            lookup.Properties.DisplayMember = "To_Party_Name";
            lookup.ClosePopup();
        }


        public static void LOOKUPItemRep(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            ItemMaster objItem = new ItemMaster();
            DataTable Item = objItem.GetDataForSearch();
            lookup.DataSource = Item;
            lookup.ValueMember = "ITEM_CODE";
            lookup.DisplayMember = "ITEM_NAME";
            //   lookup.EditValue = null;            
        }

        public static void LOOKUPCompanyComboBox(DevExpress.XtraEditors.CheckedComboBoxEdit lookup)
        {
            CompanyMaster objCompany = new CompanyMaster();
            DataTable Company = objCompany.GetData();
            lookup.Properties.DataSource = Company;
            lookup.Properties.ValueMember = "COMPANY_CODE";
            lookup.Properties.DisplayMember = "COMPANY_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        public static void LOOKUPBranchComboBox(DevExpress.XtraEditors.CheckedComboBoxEdit lookup)
        {
            BranchMaster objBranch = new BranchMaster();
            DataTable Branch = objBranch.GetData();
            lookup.Properties.DataSource = Branch;
            lookup.Properties.ValueMember = "BRANCH_CODE";
            lookup.Properties.DisplayMember = "BRANCH_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        public static void LOOKUPLocationComboBox(DevExpress.XtraEditors.CheckedComboBoxEdit lookup)
        {
            LocationMaster objLocation = new LocationMaster();
            DataTable Location = objLocation.GetData();
            lookup.Properties.DataSource = Location;
            lookup.Properties.ValueMember = "LOCATION_CODE";
            lookup.Properties.DisplayMember = "LOCATION_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        public static void LOOKUPItemComboBox(DevExpress.XtraEditors.CheckedComboBoxEdit lookup)
        {
            ItemMaster objItem = new ItemMaster();
            DataTable Item = objItem.GetDataForSearch();
            lookup.Properties.DataSource = Item;
            lookup.Properties.ValueMember = "ITEM_CODE";
            lookup.Properties.DisplayMember = "ITEM_NAME";
            //   lookup.EditValue = null;            
        }

        public static void LOOKUPItemCategoryComboBox(DevExpress.XtraEditors.CheckedComboBoxEdit lookup)
        {
            ItemCategoryMaster objItemCategory = new ItemCategoryMaster();
            DataTable ItemCategory = objItemCategory.GetData();
            lookup.Properties.DataSource = ItemCategory;
            lookup.Properties.ValueMember = "ITEM_CATEGORY_CODE";
            lookup.Properties.DisplayMember = "ITEM_CATEGORY_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        public static void LOOKUPItemGroupComboBox(DevExpress.XtraEditors.CheckedComboBoxEdit lookup)
        {
            ItemGroupMaster objItemGroup = new ItemGroupMaster();
            DataTable ItemGroup = objItemGroup.GetData();
            lookup.Properties.DataSource = ItemGroup;
            lookup.Properties.ValueMember = "ITEM_GROUP_CODE";
            lookup.Properties.DisplayMember = "ITEM_GROUP_NAME";
            //   lookup.EditValue = null;
            lookup.ClosePopup();
        }

        // End
    }//Global Method

    public static class Validator
    {
        static Regex ValidEmailRegex = CreateValidEmailRegex();
        /// <returns></returns>
        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        internal static bool EmailIsValid(string emailAddress)
        {
            bool isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }
    }
}