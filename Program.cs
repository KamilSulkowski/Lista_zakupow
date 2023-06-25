using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Lista_zakupow
{
    internal class Program
    {
        private static SQLiteConnection connection;

        static void InitializeDatabase()
        {
            connection = new SQLiteConnection("Data Source=lista_zakupow.db");
            connection.Open();
        }

        static void CreateTableIfNotExists()
        {
            string createTableQuery = "CREATE TABLE IF NOT EXISTS ListaZakupow (Produkt TEXT)";
            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        static void DeleteProductFromDatabase(string produkt)
        {
            string deleteQuery = "DELETE FROM ListaZakupow WHERE Produkt = @Produkt";
            using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Produkt", produkt);
                command.ExecuteNonQuery();
            }
        }

        static void InsertProductToDatabase(string produkt)
        {
            string insertQuery = "INSERT INTO ListaZakupow (Produkt) VALUES (@Produkt)";
            using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Produkt", produkt);
                command.ExecuteNonQuery();
            }
        }

        static List<string> GetListaZakupowFromDatabase()
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

        static void Main(string[] args)
        {
            InitializeDatabase();
            CreateTableIfNotExists();
            List<String> lista_zakupow = new List<String>();
            wypisz_liste();
            menu(lista_zakupow);
            Console.ReadKey();
        }

        static void wypisz_liste()
        {
            List<string> lista_zakupow = GetListaZakupowFromDatabase();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("----LISTA ZAKUPOW----");
            foreach (string produkt in lista_zakupow)
            {
                Console.WriteLine(produkt);
            }
            Console.WriteLine("----KONIEC----");
            Console.WriteLine("");
            Console.WriteLine("");
            menu(lista_zakupow);
        }

        static void dodaj_do_listy(List<String> lista_zakupow)
        {
            Console.WriteLine("Co dodać do listy? : ");
            string produkt = Console.ReadLine();
            if (!string.IsNullOrEmpty(produkt))
            {
                lista_zakupow.Add(produkt);
                InsertProductToDatabase(produkt);
                menu(lista_zakupow);
            }
            else
            {
                Console.WriteLine("Pole nie może być puste!");
            }
            Console.WriteLine("");
            Console.WriteLine("");

        }

        static void usun_z_listy(List<String> lista_zakupow)
        {
            Console.Write("jaki produkt chcesz usunąć z list ? : ");
            string produkt = Console.ReadLine();
            DeleteProductFromDatabase(produkt);
            Console.WriteLine("Produkt usunięty!");
            wypisz_liste();
        }

        static void menu(List<String> lista_zakupow)
        {
            int userinput = 0;
            bool dzialanie = true;
            Console.WriteLine("----LISTA ZAKUPOW----");
            Console.WriteLine("1. Dodaj do Listy");
            Console.WriteLine("2. Zobacz liste");
            Console.WriteLine("3. usun produkt z listy");
            Console.WriteLine("4. Zamknij");
            while (dzialanie)
            {
                try
                {
                    Console.Write("wpisz numerek: ");
                    userinput = Convert.ToInt32(Console.ReadLine());

                }
                catch (FormatException)
                {
                    Console.WriteLine("Musi zostać wpisany numerek 1,2");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("pole nie może być puste");
                }

                switch (userinput)
                {
                    case 1:
                        dodaj_do_listy(lista_zakupow);
                        break;
                    case 2:
                        wypisz_liste();
                        break;
                    case 3:
                        usun_z_listy(lista_zakupow);
                        break;
                    case 4:
                        dzialanie = false;
                        break;
                }
            }
        }
    }
}