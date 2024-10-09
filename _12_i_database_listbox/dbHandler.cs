using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _12_i_database_listbox
{
    public class dbHandler
    {
        MySqlConnection connection;
        string tableName = "kolbasz";
        public dbHandler()
        {
            string host = "localhost";
            string uname = "root";
            string password = "";
            string dbName = "kolbasz";

            string connectionString = $"Host={host};username={uname};password={password};database={dbName}";
            connection = new MySqlConnection(connectionString);
        }
        public void readAll()
        {
            try
            {
                connection.Open();
                string query = $"select * from {tableName}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                kolbasz.kolbaszok.Clear();
                while (read.Read())
                {
                    kolbasz oneKolbasz = new kolbasz();
                    oneKolbasz.id = read.GetInt32(read.GetOrdinal("id"));
                    oneKolbasz.name = read.GetString(read.GetOrdinal("name"));
                    oneKolbasz.price = read.GetInt32(read.GetOrdinal("price"));
                    oneKolbasz.weight = read.GetInt32(read.GetOrdinal("weight"));
                    kolbasz.kolbaszok.Add(oneKolbasz);
                }
                read.Close();
                command.Dispose();
                connection.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        public void deleteOne(kolbasz oneKolbasz)
        {
            try
            {
                connection.Open();
                string query = $"delete from {tableName} where id = {oneKolbasz.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        public void deleteAll()
        {
            try
            {
                connection.Open();
                string query = $"delete from {tableName}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        public void insertOne(kolbasz oneKolbasz)
        {
            try
            {
                connection.Open();
                string query = $"insert into {tableName} (name,price,weight) " +
                    $"values ('{oneKolbasz.name}',{oneKolbasz.price},{oneKolbasz.weight})";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }

        }



    }
    public class kolbasz
    {
        public static List<kolbasz> kolbaszok = new List<kolbasz>();
        public int id { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public int price { get; set; }
    }
}