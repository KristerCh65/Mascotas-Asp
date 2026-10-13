using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DetalleMascotas.Models.ViewModel
{
    public class OwnerViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string OwnerName { get; set; }
        public int OwnerId { get; set; }
        [Display(Name = "Dirección")]
        public string OwnerAddress { get; set; }
        [Display(Name = "Teléfono")]
        public string OwnerPhone { get; set; }
        public List<MascotaViewModel> Mascotas { get; set; }

    }
}
