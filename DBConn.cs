using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Mag
{
    class DBConn
    {
        public static MySqlConnection GetDBConnection()
        {
            String host = "212.220.105.94";
            int port = 33066;
            string database = "38-18";
            string Username = "38-18";
            string Password = "Сергей";
            return MysqlDB.GetDBConnection(host, port, database, Username, Password);

        }
    }
}
