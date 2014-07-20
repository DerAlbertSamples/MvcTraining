using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcTraining.Entities;

namespace MvcTraining.Controllers
{
    public class EditPersonController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            return View(await DbContext.People.ToListAsync());
        }

        public ActionResult Create()
        {
            return View(new Person());
        }

        [HttpPost]
        public async Task<ActionResult> Create(Person model)
        {
            ValidatePerson(model);
            if (ModelState.IsValid)
            {
                DbContext.People.Add(model);
                await DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        private void ValidatePerson(Person model)
        {
            if (string.IsNullOrWhiteSpace(model.GivenName))
            {
                ModelState.AddModelError("GivenName", "Bitte gib einen Vornamen an");
            }
            if (string.IsNullOrWhiteSpace(model.LastName))
            {
                ModelState.AddModelError("LastName", "Bitte gib einen Nachnamen an");
            }
        }


        public async Task<ActionResult> Edit(long id)
        {
            var person = await GetPerson(id);
            return View(person);
        }
        

        [HttpPost]
        public async Task<ActionResult> Edit(long id, Person model)
        {
            ValidatePerson(model);
            if (ModelState.IsValid)
            {
                var person = await GetPerson(id);
                person.GivenName = model.GivenName;
                person.LastName = model.LastName;
                person.Gender = model.Gender;
                await DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        private async Task<Person> GetPerson(long id)
        {
            return await DbContext.People.SingleAsync(p => p.Id == id);
        }
    }
}