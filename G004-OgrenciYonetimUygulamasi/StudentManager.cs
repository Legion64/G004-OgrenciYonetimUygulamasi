using G004_OgrenciYonetimUygulamasi.component;
using System;
using System.Collections.Generic;
using System.Text;

namespace G004_OgrenciYonetimUygulamasi
{
    class StudentManager
    {
        public List<Student> Students { get; set; }

        public StudentManager()
        {
            Students = new List<Student>();
        }

        // Bu sınıf verinin işleneceği sınıf
    }
}
