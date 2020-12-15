using System;
using System.Collections.Generic;
using System.Text;

namespace G004_OgrenciYonetimUygulamasi.component
{
    class Address
    {

        public string Province { get; set; }

        public string District { get; set; }

        public string Neighborhood { get; set; }


        public Address(string province, string district, string neighborhood)
        {
            Province = province;
            District = district;
            Neighborhood = neighborhood;
        }
    }
}
