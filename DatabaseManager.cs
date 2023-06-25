using System.Collections.Generic;
using System.Data.SQLite;

namespace Lista_zakupow
{
    class DatabaseManager
    {
        private SQLiteConnection connection;

        public void InitializeDatabase()
        {
            connection = new SQLiteConnection("Data Source=lista_zakupow.db");
            connection.Open();
        }

        public void CreateTableIfNotExists()
        {
            string createTableQuery = "CREATE TABLE IF NOT EXISTS ListaZakupow (Produkt TEXT)";
            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<string> GetListaZakupow()
        {
            List<string> listaZakupow = new List<string>();
            string selectQuery = "SELECT Produkt FROM ListaZakupow";
            using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string produkt = reader.GetString(0);
                    listaZakupow.Add(produkt);
                }
            }
            return listaZakupow;
        }

        public void InsertProductToDatabase(string produkt)
        {
            string insertQuery = "INSERT INTO ListaZakupow (Produkt) VALUES (@Produkt)";
            using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Produkt", produkt);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProductFromDatabase(string produkt)
        {
            string deleteQuery = "DELETE FROM ListaZakupow WHERE Produkt = @Produkt";
            using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Produkt", produkt);
                command.ExecuteNonQuery();
            }
        }
    }
}
