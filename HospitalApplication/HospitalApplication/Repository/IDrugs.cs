using HospitalApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Repository
{
    public interface IDrugs
    {
        public List<Drugs> AllDrugs();
        public void Write();
        public void Read();
    }
}
