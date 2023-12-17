using GestionEtudiant.Models;
using GestionEtudiant.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GestionEtudiant.Controllers
{
    [Authorize(Roles = "Admin,Manager")]

    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ISchoolRepository _schoolRepository;

        public StudentController(IStudentRepository studentRepository, ISchoolRepository schoolRepository)
        {
            _studentRepository = studentRepository;
            _schoolRepository = schoolRepository;

        }
        [AllowAnonymous]

        // GET: Student
        public IActionResult Index()
        {
            // Remplir ViewBag avec la liste des écoles pour la liste déroulante
            ViewBag.SchoolID = new SelectList(_schoolRepository.GetAll(), "SchoolID", "SchoolName");

            var students = _studentRepository.GetAll();
            return View(students);
        }

        // GET: Student/Details/5
        public IActionResult Details(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            // Remplir ViewBag avec la liste des écoles pour la liste déroulante
            ViewBag.SchoolID = new SelectList(_schoolRepository.GetAll(), "SchoolID", "SchoolName");

            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student s)
        {
            try
            {
                // Ajouter un nouvel employé
                _studentRepository.Add(s);
                return RedirectToAction(nameof(Index));
                // Remplir ViewBag avec la liste des écoles pour la liste déroulante
                ViewBag.SchoolID = new SelectList(_schoolRepository.GetAll(), "SchoolID", "SchoolName");
            }
            catch
            {
                return View();
            }

            

          
        }

        // GET: Student/Edit/5
        public IActionResult Edit(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            // Remplir ViewBag avec la liste des écoles pour la liste déroulante
            ViewBag.SchoolID = new SelectList(_schoolRepository.GetAll(), "SchoolID", "SchoolName");

            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student s)
        {
            try
            {
                // Mettre à jour un employé
                _studentRepository.Edit(s);
                return RedirectToAction(nameof(Index));
                // Remplir ViewBag avec la liste des écoles pour la liste déroulante
                ViewBag.SchoolID = new SelectList(_schoolRepository.GetAll(), "SchoolID", "SchoolName");

            }
            catch
            {
                return View();
            }
            
            
        }
    

    // GET: Student/Delete/5
    public IActionResult Delete(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            _studentRepository.Delete(student);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Search(string name, int? schoolid)
        {
            var students = _studentRepository.GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                students = _studentRepository.FindByName(name);
            }
            else if (schoolid.HasValue)
            {
                students = _studentRepository.GetStudentsBySchoolID(schoolid.Value);
            }

            // Remplir ViewBag avec la liste des écoles pour la liste déroulante
            ViewBag.SchoolID = new SelectList(_schoolRepository.GetAll(), "SchoolID", "SchoolName");

            return View("Index", students);
        }



    }

}
