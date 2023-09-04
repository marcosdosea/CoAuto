using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoAutoWeb.Controllers
{
    public class DisponibilidadeController : Controller
    {
        // GET: DisponibilidadeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DisponibilidadeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DisponibilidadeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisponibilidadeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisponibilidadeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisponibilidadeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisponibilidadeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisponibilidadeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
