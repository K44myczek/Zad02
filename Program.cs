using System;

namespace nowy_projekt02
{
    class Program
    {
        enum Menu { Dalsza_jazda = 1, Tankowanie = 2, Wyjście = 3 }
        static void Main(string[] args)
        {
            //  silnik testsilnika = new silnik(2, 20, 40);
            string marka;
            string model;
            double pojemnosc;
            double ilosc_paliwa;
            double pojemnosc_baku;
            Console.WriteLine("Witaj w symulatorze jazdy samochodem");
            Console.WriteLine("Wpisz markę samochodu");
            marka = Console.ReadLine();
            Console.WriteLine("Wpisz model");
            model = Console.ReadLine();
            do { Console.WriteLine("Wpisz pojemność"); }
            while (!double.TryParse(Console.ReadLine(), out pojemnosc) || pojemnosc > 20 || pojemnosc < 0.5);
            do { Console.WriteLine("Wpisz pojemność baku"); }
            while (!double.TryParse(Console.ReadLine(), out pojemnosc_baku) || pojemnosc_baku > 100 || pojemnosc_baku < 1);
            do { Console.WriteLine("Wpisz ilość paliwa"); }
            while (!double.TryParse(Console.ReadLine(), out ilosc_paliwa) || ilosc_paliwa > pojemnosc_baku || ilosc_paliwa < 1);
            samochod test = new samochod(marka, model, pojemnosc, ilosc_paliwa, pojemnosc_baku);
            Console.Clear();
            bool powrotdomenu = true;
            while (powrotdomenu)
            {
                Console.WriteLine("Wybierz jedną z opcji");
                Console.WriteLine("1-Podróż");
                Console.WriteLine("2-Zatankuj");
                Console.WriteLine("3-Koniec jazdy");

                Menu operacje;
                bool czypoprawna = Enum.TryParse<Menu>(Console.ReadLine(), out operacje);
                if (!czypoprawna)
                {
                    Console.WriteLine("Wybrałeś nieprawidłową opcję");
                }
                switch (operacje)
                {
                    case Menu.Dalsza_jazda:
                        test.jedz();
                        break;
                    case Menu.Tankowanie:
                        test.tankuj();
                        break;
                    case Menu.Wyjście:
                        Console.WriteLine("Koniec symulatora");
                        powrotdomenu = false;
                        break;
                }
                
            }
        }
    }
}
