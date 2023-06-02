using System.Collections.Specialized;
using System.Net;

namespace RoadWays.Class
{
    public class SendSMS
    {
        public string sendSMS(string StrMessage, string Mobile_No)
        {
            //String message = HttpUtility.UrlEncode("This is your message");

            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "Ha1jmIWKs0I-tKWF5RHhysMPIiQkRd8Ssq6CTNzyBb"},
                {"numbers" , Mobile_No},
                {"message" , StrMessage},
                {"sender" , "TXTLCL"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }

        }
    }
}
