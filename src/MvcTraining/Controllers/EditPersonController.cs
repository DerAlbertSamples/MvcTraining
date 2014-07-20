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