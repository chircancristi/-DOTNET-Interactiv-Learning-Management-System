using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using BusinessLayer;
using System.Data.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _repository;

        public StudentController(StudentRepository repository)
        {
            _repository = repository;
        }

        // GET: Students
        public async Task<IActionResult> Index() => View(await _repository.GetPeopleContext().Students.ToListAsync());

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string firstName, string lastName, string course)
        {
            Student Student = new Student(firstName, lastName, course);

            if (ModelState.IsValid)
            {
                _repository.GetPeopleContext().Add(Student);
                await _repository.GetPeopleContext().SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Student);
        }

        private bool StudentsExists(Guid id)
        {
            return _repository.GetPeopleContext().Students.Any(e => e.Id == id);
        }
    }
}
