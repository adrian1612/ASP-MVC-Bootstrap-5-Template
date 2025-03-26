using AJDBLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_MVC_Bootstrap_5_Template_v2.Classes
{
    public class MasterControl : AAJDBControl
    {
        public MasterControl(string ConnectionString) : base(new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString))
        {
            
        }
    }
}