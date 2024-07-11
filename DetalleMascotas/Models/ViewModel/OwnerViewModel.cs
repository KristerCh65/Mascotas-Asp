using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DetalleMascotas.Models.ViewModel
{
    public class OwnerViewModel
    {
        public string OwnerName { get; set; }
        public int OwnerId { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerPhone { get; set; }
        public List<MascotaViewModel> Mascotas { get; set; }

    }
}