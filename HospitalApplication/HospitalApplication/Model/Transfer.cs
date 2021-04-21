using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Model
{
    public class Transfer
    {
        public int idTransfer { get; set; }
        public int idRoomFrom { get; set; }
        public int idRoomTo { get; set; }
        public List<Resource> Res { get; set; }
        public DateTime dat { get; set; }
        public int kolicina { get; set; }
    }
}
