using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace nowy_projekt02
{
    [Serializable]
    public class samochod
    {
        private string marka;
        private string model;
        private silnik Silnik;
        int iloscsetek;
        private double licznik=0;

        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public silnik Silnik1 { get => Silnik; set => Silnik = value; }
        public double Licznik { get => licznik;  }

        public samochod()
        {

        }
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
            licznik += kmdoprzejechania;
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
        public void Save(samochod obiekt)//binarnie
        {
            using (Stream fstream = new FileStream("plik.dat",FileMode.Create,FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fstream, obiekt);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fstream.Close();
                }
            }
        }
         public samochod deSave(samochod obiekt)//binarnie
        {
            using (Stream fstream = new FileStream("plik.dat",FileMode.Open,FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    obiekt = (samochod)formatter.Deserialize(fstream);
                    return obiekt;
                }
                
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fstream.Close();
                }
            }
        }
        public void SaveXML(samochod obiekt)
        {
            using (Stream fstream = new FileStream("plikXML.xml", FileMode.Create, FileAccess.Write))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(samochod));
                try
                {
                    formatter.Serialize(fstream, obiekt);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fstream.Close();
                }
            }
        }
        public samochod UNSaveXML(samochod obiekt)
        {
            using (Stream fstream = new FileStream("plikXML.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(samochod));
                try
                {
                    obiekt = (samochod)formatter.Deserialize(fstream);
                    return obiekt;
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fstream.Close();
                }
            }
        }


    }
}
