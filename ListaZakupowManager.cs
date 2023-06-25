using System;
using System.Collections.Generic;

namespace Lista_zakupow
{
    class ListaZakupowManager
    {
        private DatabaseManager databaseManager;

        public ListaZakupowManager()
        {
            databaseManager = new DatabaseManager();
        }

        public void InitializeDatabase()
        {
            databaseManager.InitializeDatabase();
        }

        public void CreateTableIfNotExists()
        {
            databaseManager.CreateTableIfNotExists();
        }

        public List<string> GetListaZakupow()
        {
            return databaseManager.GetListaZakupow();
        }

        public void DodajDoListy(List<string> lista_zakupow)
        {
            Console.WriteLine("Co dodać do listy? : ");
            string produkt = Console.ReadLine();

            if (!string.IsNullOrEmpty(produkt))
            {
                lista_zakupow.Add(produkt);
                databaseManager.InsertProductToDatabase(produkt);
            }
            else
            {
                Console.WriteLine("Pole nie może być puste");
            }
        }

        public void WypiszListe(List<string> lista_zakupow)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("----LISTA ZAKUPOW----");
            foreach (string produkt in lista_zakupow)
            {
                Console.WriteLine(produkt);
            }
            Console.WriteLine("----KONIEC----");

        }

        public void UsunZListy(List<string> lista_zakupow)
        {
            Console.Write("Jaki produkt chcesz usunąć z listy? : ");
            string produkt = Console.ReadLine();
            if (!string.IsNullOrEmpty(produkt))
            {
                databaseManager.DeleteProductFromDatabase(produkt);
            }
            else
            {
                Console.WriteLine("Pole nie może być puste");
            }
            Console.WriteLine("Produkt usunięty!");
            WypiszListe(lista_zakupow);
        }
    }
}
