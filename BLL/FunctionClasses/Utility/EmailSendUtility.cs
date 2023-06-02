using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using BLL.PropertyClasses.Utility;
namespace BLL.FunctionClasses.Utility
{
    public class EmailSendUtility
    {
        static Settings ObjSetting = new Settings();

        
        public static string SendEMail(string pStrToEMails, string pStrSubject, string pStrBody, string pStrCcEMail = "", string pStrDisplayName = "", string pStrBccEMails = "",string pStrAttachments="")
        {
            try
            {
               // markupConverter = new MarkupConverter.MarkupConverter();

                Settings_Property Settings = new Settings().GetDataByPK();

                if (Settings.Allow_Email_Send == 0 )
                {
                    return "";
                }

                System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage();

                mm.From = new System.Net.Mail.MailAddress(Settings.Sender_Email, pStrDisplayName);

                foreach (string Str in pStrToEMails.Split(','))
                {
                    if (Str.Length != 0)
                    {
                        mm.To.Add(Str);
                    }
                }

                foreach (string Str in pStrCcEMail.Split(','))
                {
                    if (Str.Length != 0)
                    {
                        mm.CC.Add(Str);
                    }
                }

                foreach (string Str in pStrBccEMails.Split(','))
                {
                    if (Str.Length != 0)
                    {
                        mm.Bcc.Add(Str);
                    }
                }

                if (pStrAttachments != "")
                {
                    foreach (string StrAttach in pStrAttachments.Split(','))
                    {
                        if (StrAttach.Length != 0)
                        {
                            mm.Attachments.Add(new System.Net.Mail.Attachment(StrAttach));
                        }
                    }
                }

                mm.Subject = pStrSubject;

                mm.IsBodyHtml = true;

                //mm.Body = markupConverter.ConvertRtfToHtml(pStrBody.ToString());
                mm.Body = pStrBody;

                System.Net.Mail.SmtpClient SMTP = new System.Net.Mail.SmtpClient();

                SMTP.Port = Settings.SMTP_Port;
                SMTP.Host = Settings.SMTP_Server;
                SMTP.EnableSsl = Settings.IS_Enable_SSL == 1 ? true : false;

                SMTP.Timeout = 50000;
                SMTP.UseDefaultCredentials = true;
                SMTP.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                SMTP.Credentials = new System.Net.NetworkCredential(Settings.Sender_Email, Settings.Sender_Password);
                SMTP.Send(mm);

                if (pStrAttachments != "")
                {
                    mm.Attachments.Dispose();                    
                }

                mm.Dispose();
                SMTP.Dispose();

                mm = null;
                SMTP = null;
                return "Your Email Is Sent Successfully ";
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
           
        }

        public static string SendEMailNew(string pStrToEMails, string pStrSubject, string pStrBody, string pStrCcEMail = "", string pStrDisplayName = "", string pStrBccEMails = "", string pStrAttachments = "")
        {
            try
            {
                // markupConverter = new MarkupConverter.MarkupConverter();

                Settings_Property Settings = new Settings().GetDataByPK();

                //if (Settings.Allow_Email_Send == 0)
                //{
                //    return "";
                //}

                System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage();

                mm.From = new System.Net.Mail.MailAddress(Settings.Sender_Email, pStrDisplayName);

                foreach (string Str in pStrToEMails.Split(','))
                {
                    if (Str.Length != 0)
                    {
                        mm.To.Add(Str);
                    }
                }

                foreach (string Str in pStrCcEMail.Split(','))
                {
                    if (Str.Length != 0)
                    {
                        mm.CC.Add(Str);
                    }
                }

                foreach (string Str in pStrBccEMails.Split(','))
                {
                    if (Str.Length != 0)
                    {
                        mm.Bcc.Add(Str);
                    }
                }

                if (pStrAttachments != "")
                {
                    foreach (string StrAttach in pStrAttachments.Split(','))
                    {
                        if (StrAttach.Length != 0)
                        {
                            mm.Attachments.Add(new System.Net.Mail.Attachment(StrAttach));
                        }
                    }
                }

                mm.Subject = pStrSubject;

                mm.IsBodyHtml = true;

                //mm.Body = markupConverter.ConvertRtfToHtml(pStrBody.ToString());
                mm.Body = pStrBody;

                System.Net.Mail.SmtpClient SMTP = new System.Net.Mail.SmtpClient();

                SMTP.Port = Settings.SMTP_Port;
                SMTP.Host = Settings.SMTP_Server;
                SMTP.EnableSsl = Settings.IS_Enable_SSL == 1 ? true : false;

                SMTP.Timeout = 50000;
                SMTP.UseDefaultCredentials = true;
                SMTP.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                SMTP.Credentials = new System.Net.NetworkCredential(Settings.Sender_Email, Settings.Sender_Password);
                SMTP.Send(mm);

                if (pStrAttachments != "")
                {
                    mm.Attachments.Dispose();
                }

                mm.Dispose();
                SMTP.Dispose();

                mm = null;
                SMTP = null;
                return "Your Email Is Sent Successfully ";
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }

        }

    }
}
