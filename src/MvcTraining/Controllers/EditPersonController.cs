using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using MvcTraining.Entities;
using MvcTraining.Models;

namespace MvcTraining.Controllers
{
    public class EditPersonController : BaseController
    {
        public async Task<ActionResult> Index(string spalte = "", string richtung = "up")
        {
            spalte = spalte.ToLowerInvariant();
            richtung = richtung.ToLowerInvariant();

            ViewBag.SortSpalte = spalte;
            ViewBag.SortRichtung = richtung;

            IQueryable<Person> people = DbContext.People;

            switch (spalte)
            {
                case "gender":
                    people = richtung == "up" ? people.OrderBy(p => p.Gender) : people.OrderByDescending(p => p.Gender);
                    break;
                case "givenname":
                    people = OrderBy(people, richtung, p => p.GivenName);
                    break;
                case "lastname":
                    people = OrderBy(people, richtung, p => p.LastName);
                    break;
            }
            return View(await people.ToListAsync());
        }

        private static IOrderedQueryable<Person> OrderBy(IQueryable<Person> people, string richtung,
            Expression<Func<Person, object>> keySelector)
        {
            if (richtung == "down")
            {
                return people.OrderByDescending(keySelector);
            }
            return people.OrderBy(keySelector);
        }

        public ActionResult Create()
        {
            return View(new CreatePersonModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePersonModel model)
        {
            if (ModelState.IsValid)
            {
                DbContext.People.Add(Mapper.Map<Person>(model));
                await DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(long id)
        {
            var person = await GetPerson(id);
            return View(Mapper.Map<EditPersonModel>(person));
        }


        [HttpPost]
        public async Task<ActionResult> Edit(long id, EditPersonModel model)
        {
            if (ModelState.IsValid)
            {
                var person = await GetPerson(id);
                Mapper.Map(model, person);
                await DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        private async Task<Person> GetPerson(long id)
        {
            return await DbContext.People.SingleAsync(p => p.Id == id);
        }

        public async Task<ActionResult> Details(long id)
        {
            return View(await GetPerson(id));
        }
    }
}