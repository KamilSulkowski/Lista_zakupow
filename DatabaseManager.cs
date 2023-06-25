using System.Collections;
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
            string createTableQuery = "CREATE TABLE IF NOT EXISTS ListaZakupow (Produkt TEXT, Ilosc DOUBLE DEFAULT 0, Cena DOUBLE DEFAULT 0, Suma DOUBLE DEFAULT 0)";
            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<string> GetListaZakupow()
        {
            List<string> lista_zakupow = new List<string>();
            string selectQuery = "SELECT Produkt, Ilosc, Cena, Suma FROM ListaZakupow";
            using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string produkt = reader.GetString(0);
                    double ilosc = reader.GetDouble(1);
                    double cena = reader.GetDouble(2);
                    double suma = reader.GetDouble(3);
                    string item = $"{produkt} (Ilość: {ilosc}, Cena: {cena}, Suma: {suma})";
                    lista_zakupow.Add(item);
                }
            }
            return lista_zakupow;
        }

        public void InsertProductToDatabase(string produkt, double ilosc, double cena, double suma)
        {
            string insertQuery = "INSERT INTO ListaZakupow (Produkt, Ilosc, Cena, Suma) VALUES (@Produkt, @Ilosc, @Cena, @Suma)";
            using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Produkt", produkt);
                command.Parameters.AddWithValue("@Ilosc", ilosc);
                command.Parameters.AddWithValue("@Cena", cena);
                command.Parameters.AddWithValue("@Suma", suma);
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
