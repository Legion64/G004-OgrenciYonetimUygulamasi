using System;
using System.Collections.Generic;
using System.Text;

namespace G004_OgrenciYonetimUygulamasi.component
{
    class Utils
    {
        public static void DataWriter(string className, int id, string name, string surname, float ga, int bookCount)
        {
            Console.WriteLine($"{className,-7}{id,-5}{name + " " + surname,-25}{ga,-15}{bookCount,-20}");
        }

        public static void ListHeader()
        {
            Console.WriteLine($"{"Şube",-7}{"No",-5}{"Adı Soyadı",-25}{"Not Ort.",-15}{"Okuduğu Kitap Say.",-20}");
            Console.WriteLine("------------------------------------------------------------------------");
        }

    }
}
