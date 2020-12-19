using System;
using System.Collections.Generic;
using System.Text;

namespace G004_OgrenciYonetimUygulamasi
{
    class Kisi
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender gender { get; set; }

        public string TC { get; set; }


        public enum Gender
        {
            Undefined,
            E,
            K
        }
    }
}
