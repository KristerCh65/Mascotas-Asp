using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DetalleMascotas.Models.ViewModel;
using DetalleMascotas.Models;
using System.Threading.Tasks;

namespace DetalleMascotas.Controllers
{
    public class MaestroController : Controller
    {
        // GET: Maestro
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async  Task<ActionResult> Add(OwnerViewModel ownerViewModel)
        {
            try
            {
                using (PetFinderEntities dbContext = new PetFinderEntities())
                {
                    Owner owner = new Owner();
                    owner.OwnerName = ownerViewModel.OwnerName;
                    owner.Direction = ownerViewModel.OwnerAddress;
                    owner.Phone = ownerViewModel.OwnerPhone;

                    dbContext.Owner.Add(owner);     
                    dbContext.SaveChanges();
                    
                    foreach (var item in ownerViewModel.Mascotas)
                    {
                        Pet pet = new Pet();
                        pet.PetName = item.PetName;
                        pet.age = item.age;
                        pet.color = item.color;
                        pet.OwnerId = owner.OwnerId;
                        owner.Pet.Add(pet);
                        dbContext.Pet.Add(pet);
                    }

                    ownerViewModel.OwnerId = owner.OwnerId;

                    await dbContext.SaveChangesAsync();

                }

                ViewBag.Message = "Register added successfully";
                return View();
            }
            catch (Exception ex)
            {

                return View();
            }

        }
    }
}