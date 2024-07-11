using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DetalleMascotas.Models.ViewModel
{
    public class MascotaViewModel
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int age { get; set; }
        public string color { get; set; }

    }
}