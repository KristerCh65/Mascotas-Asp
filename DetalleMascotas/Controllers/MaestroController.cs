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
            ViewBag.Message = TempData["Message"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(OwnerViewModel ownerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ownerViewModel);
            }

            try
            {
                using (PetFinderEntities dbContext = new PetFinderEntities())
                {
                    Owner owner = new Owner();
                    owner.OwnerName = ownerViewModel.OwnerName;
                    owner.Direction = ownerViewModel.OwnerAddress;
                    owner.Phone = ownerViewModel.OwnerPhone;

                    foreach (var item in ownerViewModel.Mascotas ?? new List<MascotaViewModel>())
                    {
                        Pet pet = new Pet();
                        pet.PetName = item.PetName;
                        pet.age = item.age;
                        pet.color = item.color;
                        owner.Pet.Add(pet);
                    }

                    // Owner and pets are saved in a single transaction
                    dbContext.Owner.Add(owner);
                    await dbContext.SaveChangesAsync();
                }

                TempData["Message"] = "Register added successfully";
                return RedirectToAction("Add");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error saving the register: " + ex.Message;
                return View(ownerViewModel);
            }
        }
    }
}
