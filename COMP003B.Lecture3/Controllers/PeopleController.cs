using COMP003B.Lecture3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace COMP003B.Lecture3.Controllers
{
    public class PeopleController : Controller
    {
        private static List<Person> _people = new List<Person>();

        // GET: People
        [HttpGet]
        public IActionResult Index()
        {
            return View(_people);
        }

        // GET: People/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                if (!_people.Any(p => p.Id == person.Id))
                {
                    _people.Add(person);
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: People/Edit/1
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _people.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingPerson = _people.FirstOrDefault(p => p.Id == person.Id);

                if (existingPerson != null)
                {
                    existingPerson.Name = person.Name;
                    existingPerson.Age = person.Age;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        // GET: People/Delete/1
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _people.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _people.Remove(person);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
