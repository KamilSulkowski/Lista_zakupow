using System;
using System.Collections.Generic;


namespace Lista_zakupow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<String> lista_zakupow = new List<String>();
            menu(lista_zakupow);

            Console.ReadKey();
        }

        static void wypisz_liste(List<string> lista_zakupow)
        {
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
                menu(lista_zakupow);
            }
            else
            {
                Console.WriteLine("Pole nie może być puste!");
            }
            Console.WriteLine("");
            Console.WriteLine("");


        }

        static void menu(List<String> lista_zakupow)
        {
            int userinput = 0;
            bool dzialanie = true;
            Console.WriteLine("----LISTA ZAKUPOW----");
            Console.WriteLine("1. Dodaj do Listy");
            Console.WriteLine("2. Zobacz liste");
            Console.WriteLine("3. Zamknij");
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
                        wypisz_liste(lista_zakupow);
                        break;
                    case 3:
                        dzialanie = false;
                        break;
                }
            }
        }
    }
}