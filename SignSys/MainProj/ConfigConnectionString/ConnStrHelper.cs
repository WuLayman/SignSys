using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProj.ConfigConnectionString
{
    public class ConnStrHelper
    {
        private string protocal;
        private string host;
        private string port;
        private string serviceName;
        private string userID;
        private string password;

        public string Protocal { get => protocal; set => protocal = value; }
        public string Host { get => host; set => host = value; }
        public string Port { get => port; set => port = value; }
        public string ServiceName { get => serviceName; set => serviceName = value; }
        public string UserID { get => userID; set => userID = value; }
        public string Password { get => password; set => password = value; }

        public string GetConnStr()
        {
            //@"metadata=res://*/Model3.csdl|res://*/Model3.ssdl|res://*/Model3.msl;provider=Oracle.ManagedDataAccess.Client;provider connection string=""DATA SOURCE = 192.168.20.1:1521 / orcl; USER ID = SCOTT;PASSWORD=0000""";
            var connStr = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=Oracle.ManagedDataAccess.Client;provider connection string=" + "\"" + " DATA SOURCE = " + Host + ":" + Port + " / " + ServiceName + "; USER ID = " + UserID.ToUpper() + "; PASSWORD = " + Password + "\"" + "";

            return connStr;
        }

        public string GetEntityConnStr()
        {
            var connStr = " DATA SOURCE = " + Host + ":" + Port + " / " + ServiceName + "; USER ID = " + UserID + "; PASSWORD = " + Password + "";
            return connStr;
        }
    }
}
