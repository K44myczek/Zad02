using System;
using System.Collections.Generic;
using System.Text;

namespace nowy_projekt02
{


    class silnik
    {
        private double pojemnosc;
        private double ilosc_paliwa;
        private double pojemnosc_zbiornika_na_paliwo=40;
      

        public double Pojemnosc { get => pojemnosc; set => pojemnosc = value; }
        public double Ilosc_paliwa { get => ilosc_paliwa; set => ilosc_paliwa = value; }
        public double Pojemnosc_zbiornika_na_paliwo { get => pojemnosc_zbiornika_na_paliwo; set => pojemnosc_zbiornika_na_paliwo = value; }

        public silnik(double pojemnosc, double ilosc_paliwa)
        {
            this.ilosc_paliwa = ilosc_paliwa;
            this.pojemnosc = pojemnosc;
            
           
        }
        public silnik(double pojemnosc, double ilosc_paliwa, double pojemnosc_zbiornika_na_paliwo)
        {
            this.ilosc_paliwa = ilosc_paliwa;
            this.pojemnosc = pojemnosc;
            this.pojemnosc_zbiornika_na_paliwo = pojemnosc_zbiornika_na_paliwo;
        }


        public void nalitry(double mpg)
        {
            double litry;
            litry = 235.2 / mpg;
            Console.WriteLine("Wartość w litrach wynosi: " + litry);
            Console.WriteLine("Wartość w mpg wynosi: " + mpg);

        }
        public void nampg(double litry)
        {
            double mpg;
            mpg = 235.21 / litry;
            Console.WriteLine("Wartość w litrach wynosi: " + litry);
            Console.WriteLine("Wartość w mpg wynosi: " + mpg);
        }
        
    }
}



