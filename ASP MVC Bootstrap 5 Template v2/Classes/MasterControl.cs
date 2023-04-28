using AAJControl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_MVC_Bootstrap_5_Template_v2.Classes
{
    public class MasterControl : DBControl
    {
        public MasterControl(string ConnectionString) : base(DatabaseType.MSSQL, ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString)
        {
            
        }
    }
}