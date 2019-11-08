using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace nowy_projekt02
{
    class samochod
    {
        private string marka;
        private string model;
        private silnik Silnik;
        int iloscsetek;

        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public silnik Silnik1 { get => Silnik; set => Silnik = value; }

        public samochod(string marka, string model, double pojemnosc, double iloscbenzyny, double pojemnoscbaku)
        {
            this.marka = marka;
            this.model = model;
            silnik testsilnika = new silnik(pojemnosc, iloscbenzyny, pojemnoscbaku);
            Silnik1 = testsilnika;
        }
        public samochod(string marka, string model, double pojemnosc, double iloscbenzyny)
        {
            this.marka = marka;
            this.model = model;
            silnik testsilnika = new silnik(pojemnosc, iloscbenzyny);
            Silnik1 = testsilnika;
        }
        public samochod(string marka, string model, silnik silnik)
        {
            this.marka = marka;
            this.model = model;
            this.Silnik = silnik;
        }
        public void jedz()
        {
            int kmdoprzejechania;
            do { Console.WriteLine("Wpisz ile km chcesz przejechać"); }
            while (!int.TryParse(Console.ReadLine(), out kmdoprzejechania));
             Console.WriteLine("Jadę");
            Thread.Sleep(kmdoprzejechania * 100);
            iloscsetek = kmdoprzejechania / 100;

            dzialaj();
            Console.WriteLine("Jestem");
            Console.ReadKey();
            Console.Clear();
        }
        public void dzialaj()
        {
            Console.WriteLine("Pojemność baku wynosi " + Silnik.Pojemnosc_zbiornika_na_paliwo);
            Console.WriteLine("Ilość paliwa po odpaleniu auta " + Silnik.Ilosc_paliwa);

            double spalanie = iloscsetek * 4 * Silnik.Pojemnosc;
            Silnik.Ilosc_paliwa = Silnik.Ilosc_paliwa - spalanie;
            Console.WriteLine("Ilość paliwa po przejechaniu dystansu " + iloscsetek * 100 + " wynosi " + Silnik.Ilosc_paliwa);
            Console.WriteLine("Spalanie wyniosło " + spalanie);
        }
        public void tankuj()
        {
            double ilosctankowania;
            double ilemoznamaksymalniezatankowac;
            ilemoznamaksymalniezatankowac = Silnik.Pojemnosc_zbiornika_na_paliwo - Silnik.Ilosc_paliwa;
            Console.WriteLine("Maksymalnie możesz zatankować "+ilemoznamaksymalniezatankowac);
            do { Console.WriteLine("Wpisz wartość tankowania"); }
            while (!double.TryParse(Console.ReadLine(), out ilosctankowania) || ilosctankowania>ilemoznamaksymalniezatankowac);
            Silnik.Ilosc_paliwa = Silnik.Pojemnosc_zbiornika_na_paliwo;
            Console.WriteLine("Auto zostało zatankowane");
            Console.ReadKey();
            Console.Clear();

        }
        public void symulatorsamochodu()
        {

        }

    }
}
