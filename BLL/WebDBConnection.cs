using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.OleDb;

namespace BLL
{
   public class WebDBConnection
    {
       public static string GetConnection()
       {
           return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MARGOConnectionString"].ConnectionString;
       }
    }
}