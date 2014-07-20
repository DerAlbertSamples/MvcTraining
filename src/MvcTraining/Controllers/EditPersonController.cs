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
            if (string.IsNullOrWhiteSpace(model.GivenName))
            {
                return View(model);
            }
            if (string.IsNullOrWhiteSpace(model.LastName))
            {
                return View(model);
            }
            DbContext.People.Add(model);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Edit(long id)
        {
            var person = await GetPerson(id);
            return View(person);
        }
        

        [HttpPost]
        public async Task<ActionResult> Edit(long id, Person model)
        {
            var person = await GetPerson(id);
            person.GivenName = model.GivenName;
            person.LastName = model.LastName;
            person.Gender = model.Gender;
            await DbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private async Task<Person> GetPerson(long id)
        {
            return await DbContext.People.SingleAsync(p => p.Id == id);
        }
    }
}