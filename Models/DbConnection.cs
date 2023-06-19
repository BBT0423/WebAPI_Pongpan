using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebAPI_Pongpan.Models
{
    public class DbConnection
    {   
        public DataClasses1DataContext GetConnection()
        {
            return new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["DemoDBConnectionString"].ConnectionString);

        }
       
    }
}