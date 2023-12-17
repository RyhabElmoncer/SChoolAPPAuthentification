using GestionEtudiant.Models; // Assurez-vous d'importer le modèle School si ce n'est pas déjà fait
using GestionEtudiant.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GestionEtudiant.Controllers
{
   [Authorize(Roles = "Admin,Manager")]


    public class SchoolController : Controller
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        [AllowAnonymous]

        // GET: School
        public ActionResult Index()
        {
            var schools = _schoolRepository.GetAll();
            return View(schools);
        }

        // GET: School/Details/5
        public ActionResult Details(int id)
        {
            var school = _schoolRepository.GetById(id);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        // GET: School/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: School/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School s)
        {
            try
            {
                // Ajouter un nouvel employé
                _schoolRepository.Add(s);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: School/Edit/5
        public ActionResult Edit(int id)
        {
            var school = _schoolRepository.GetById(id);
            return View(school);
        }

        // POST: School/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, School s)
        {
            try
            {
                // Mettre à jour un employé
                _schoolRepository.Edit( s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: School/Delete/5
        public ActionResult Delete(int id)
        {
            var school = _schoolRepository.GetById(id);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        // POST: School/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var school = _schoolRepository.GetById(id);
            if (school == null)
            {
                return NotFound();
            }
            _schoolRepository.Delete(school);
            return RedirectToAction(nameof(Index));
        }
    }
}
