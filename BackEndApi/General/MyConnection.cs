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

        public DataTable GetDataFromDb(string table)
        {

            string testConn = "SERVER=localhost;Port=3306;DATABASE=;UID=root;PASSWORD=example;CONNECT TIMEOUT=28800;";

            using (var connection = new MySqlConnection(testConn))
            {

                connection.Open();
                var dati = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand("SELECT *  FROM " + table, connection))
                {
                    cmd.CommandTimeout = 28800;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dati.Load(reader);
                }

                connection.Close();

                return dati;
            }
        }

        public DataTable GetDataFromSaintTableOfDay(string table,string giorno, string mese)
        {

            string testConn = "SERVER=localhost;Port=3306;DATABASE=;UID=root;PASSWORD=example;CONNECT TIMEOUT=28800;";

            using (var connection = new MySqlConnection(testConn))
            {

                connection.Open();
                var dati = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand("SELECT *  FROM " + table + " WHERE mese='" + mese + "' and giorno=" + giorno , connection))
                {
                    cmd.CommandTimeout = 28800;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dati.Load(reader);
                }

                connection.Close();

                return dati;
            }
        }

        public int UploadOnDbFromDatatable(string queryOp)
        {
            try
            {
                string testConn = "SERVER=localhost;Port=3306;DATABASE=;UID=root;PASSWORD=example;CONNECT TIMEOUT=28800;";
                int rowUpdate;
                using (var connection = new MySqlConnection(testConn))
                {
                    connection.Open();
                    //var dati = new DataTable();
                    using (MySqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = queryOp;
                        cmd.CommandTimeout = 28800;
                        rowUpdate = cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return rowUpdate;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("errore: " + e.Message);
                return -1;
            }
        }
    }
}
