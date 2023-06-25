using System;
using System.Collections.Generic;

namespace Lista_zakupow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool dzialanie = true;
            
            ListaZakupowManager manager = new ListaZakupowManager();
            manager.InitializeDatabase();
            manager.CreateTableIfNotExists();

            List<string> lista_zakupow = manager.GetListaZakupow();

            int userinput = 0;
            Console.WriteLine("----LISTA ZAKUPOW----");
            Console.WriteLine("Wpisz numer:");
            Console.WriteLine("1. Dodaj do Listy");
            Console.WriteLine("2. Zobacz liste");
            Console.WriteLine("3. Usuń z listy");
            Console.WriteLine("4. Zamknij");
            while (dzialanie)
            {
                try
                {
                    userinput = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Musisz wpisać numer 1, 2 lub 3");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Pole nie może być puste");
                }

                switch (userinput)
                {
                    case 1:
                        manager.DodajDoListy(lista_zakupow);
                        break;
                    case 2:
                        manager.WypiszListe(lista_zakupow);
                        break;
                    case 3:
                        manager.UsunZListy(lista_zakupow);
                        break;
                    case 4:
                        dzialanie = false;
                        break;
                    default:
                        Console.WriteLine("Wpisz numer 1, 2 lub 3");
                        break;
                }
            }
            

            Console.ReadKey();
        }
    }
}
