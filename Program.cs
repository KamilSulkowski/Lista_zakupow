using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Lista_zakupow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool wlaczone = true;
            ProductMenu menu = new ProductMenu();
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.InitializeDatabase();
            dbManager.CreateTableIfNotExists();
            Console.WriteLine("Zarejestruj się albo Zaloguj się: (wpisz zarejestruj albo zaloguj)");
            try
            {
                string ZarZal = Console.ReadLine();
                if (ZarZal.ToLower() == "zarejestruj")
                {
                    Console.WriteLine("");
                }
                else if (ZarZal.ToLower() == "zaloguj")
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("wpisz zarejestruj albo zaloguj");
            }
            


            bool zalogowany = true;
            while (wlaczone)
            {
                if (zalogowany == false)
                {
                    Console.WriteLine("Musisz się zalogować!");
                }
                else
                {
                    menu.StartMenu();
                }
            }
            
            
        }
    }
}
