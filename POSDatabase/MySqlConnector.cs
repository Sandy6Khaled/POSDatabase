using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSDatabase
{
    class MySqlConnector
    {
        public DataTable Connector(string TheQueiry)
        {
            string Connection = "server=******; database = *******; uid = ****; pwd = *******;";
            MySqlConnection data = new MySqlConnection(Connection);
            MySqlDataAdapter Adapter = new MySqlDataAdapter(TheQueiry, data);
            DataTable DT = new DataTable();
            Adapter.Fill(DT);
            return DT;
        }
    }
}
