using BackEndApi.Brain;
using MySql.Data.MySqlClient;
using System.Data;

namespace BackEndApi.General
{
    public class MyConnection
    {

        // SINGLETON
        private static MyConnection instance;

        public static MyConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyConnection();
                }
                return instance;
            }
        }

        private struct connesione
        {
            public string ip;
            public string database;
            public string uid;
            public string pwd;
            public string port;
            public string connectionString;
        }

        public DataTable GetDataFromDb()
        {

            string testConn = "SERVER=localhost;Port=3306;DATABASE=;UID=root;PASSWORD=example;CONNECT TIMEOUT=28800;";

            using (var connection = new MySqlConnection(testConn))
            {

                connection.Open();
                var dati = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand("SELECT *  FROM main.NewTable", connection))
                {
                    cmd.CommandTimeout = 28800;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dati.Load(reader);
                }

                connection.Close();

                return dati;
            }
        }
    }
}
