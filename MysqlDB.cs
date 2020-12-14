using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Mag
{
    class MysqlDB
    {
        public static MySqlConnection 
            GetDBConnection(string host,int port,string database,string username, string password)
        {
            string connstr = "server=" + host + ";Port=" + port + ";database=" + database + ";UserID=" + username + ";Password=" + password;
            MySqlConnection conn = new MySqlConnection(connstr);
            return conn;
        } 
    }
}
