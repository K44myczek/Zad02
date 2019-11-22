using System;

namespace nowy_projekt02
{
    class Program
    {
        enum Menuserializacji { Nowy_użytkowik = 1, Wczytaj = 2 }
        enum Menu { Dalsza_jazda = 1, Tankowanie = 2, Licznik = 3, Zapisz = 4, Wyjście = 5 }
        static void Main(string[] args)
        {

            string marka;
            string model;
            double pojemnosc;
            double ilosc_paliwa;
            double pojemnosc_baku;

            Menuserializacji operacjieserializacji;
            Console.WriteLine("1-Nowy użytkownik \n2-Wczytaj ostatni zapis");
            bool czypoprawnemenuserializaji = Enum.TryParse<Menuserializacji>(Console.ReadLine(), out operacjieserializacji);
            if (!czypoprawnemenuserializaji)
            {
                Console.WriteLine("Wybrałeś nieprawidłową opcję");
            }
            switch (operacjieserializacji)
            {
                case Menuserializacji.Nowy_użytkowik:
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
                        Console.Clear();
                        Console.WriteLine("Wybierz jedną z opcji");
                        Console.WriteLine("1-Podróż");
                        Console.WriteLine("2-Zatankuj");
                        Console.WriteLine("3-Licznik");
                        Console.WriteLine("4-Zapisz");
                        Console.WriteLine("5-Koniec jazdy");

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
                            case Menu.Licznik:
                                Console.WriteLine("Licznik przejechanych kilometrów wynosi " + test.Licznik); ;
                                Console.ReadKey();
                                break;
                            case Menu.Zapisz:
                                Console.WriteLine("Informacje o samochodzie zostały zapisane ");
                                test.Save(test);
                                //test.SaveXML(test);
                                Console.ReadKey();
                                break; 

                            case Menu.Wyjście:
                                Console.WriteLine("Koniec symulatora");
                                test = test.deSave(test);
                                powrotdomenu = false;
                                break;
                        }

                    }
                    break;
                case Menuserializacji.Wczytaj:
                    Console.WriteLine("Witaj w symulatorze jazdy samochodem");
                    samochod test1 = new samochod("", "", 1, 1, 1);
                    test1 = test1.deSave(test1);
                    //test1 = test1.UNSaveXML(test1);
                    Console.Clear();
                    bool powrotdomenu2 = true; 
                    while (powrotdomenu2)
                    {
                        Console.Clear();
                        Console.WriteLine("Wybierz jedną z opcji");
                        Console.WriteLine("1-Podróż");
                        Console.WriteLine("2-Zatankuj");
                        Console.WriteLine("3-Licznik");
                        Console.WriteLine("4-Zapisz");
                        Console.WriteLine("5-Koniec jazdy");

                        Menu operacje;
                        bool czypoprawna = Enum.TryParse<Menu>(Console.ReadLine(), out operacje);
                        if (!czypoprawna)
                        {
                            Console.WriteLine("Wybrałeś nieprawidłową opcję");
                        }
                        switch (operacje)
                        {
                            case Menu.Dalsza_jazda:
                                test1.jedz();
                                break;
                            case Menu.Tankowanie:
                                test1.tankuj();
                                break;
                            case Menu.Licznik:
                                Console.WriteLine("Licznik przejechanych kilometrów wynosi " + test1.Licznik); ;
                                Console.ReadKey();

                                break;
                            case Menu.Zapisz:
                                Console.WriteLine("Informacje o samochodzie zostały zapisane"); ;
                                test1.Save(test1);
                                Console.ReadKey();

                                break;
                            case Menu.Wyjście:
                                Console.WriteLine("Koniec symulatora");
                                powrotdomenu2 = false;
                                break;
                        }

                    }
                    break;
                default:
                    break;
            }


        }
    }
}
