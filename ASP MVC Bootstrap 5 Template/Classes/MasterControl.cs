using AAJdbController;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_MVC_Bootstrap_5_Template.Classes
{
    public class MasterControl : AAJControl
    {
        public MasterControl(string ConnectionString) : base(DatabaseType.SQLServer, ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString)
        {
            ErrorOccured += MasterControl_ErrorOccured;
        }

        private void MasterControl_ErrorOccured(ErrorMessage e)
        {
            throw new Exception(e.ExceptionMessage);
        }
    }
}