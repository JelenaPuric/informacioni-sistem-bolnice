using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Model
{
    public class Resource
    {
        public String id { get; set; }
        public String naziv { get; set; }
        public int kolicina { get; set; }
        public String proizvodjac { get; set; }
        public bool jeStaticka { get; set; }
    }
}
