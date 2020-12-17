using System;
using System.Collections.Generic;
using System.Text;

namespace G004_OgrenciYonetimUygulamasi.component
{
    class Utils
    {
        public static void DataWriter(string className, string name, string surname, float ga, int bookCount)
        {
            Console.WriteLine($"{className,10}{name + " " + surname,25}{ga,15}{bookCount,5}");
        }

        public static void ListHeader()
        {
            Console.WriteLine("{0}{1}{2}{3}", "Şube No".PadLeft(10), "Adı Soyadı".PadLeft(25), "Not Ort.".PadLeft(15), "Okuduğu Kitap Say.".PadLeft(20));
            Console.WriteLine("----------------------------------------------------------------------");
        }

    }
}
