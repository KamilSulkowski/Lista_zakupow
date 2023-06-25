using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_zakupow
{
    internal class DatabaseUserMenager
    {
        private SQLiteConnection connection;

        public void InitializeDatabase()
        {
            connection = new SQLiteConnection("Data source=Uzytkownice.db");
            connection.Open();
        }

        public void CreateTableIfNotExist() 
        {
            string createTableQuery = "CREATE TABLE IF NOT EXIST Uzytkownicy (Login TEXT, Haslo TEXT)";
            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection)) 
            {
                command.ExecuteNonQuery();
            }
        }
    }

}
