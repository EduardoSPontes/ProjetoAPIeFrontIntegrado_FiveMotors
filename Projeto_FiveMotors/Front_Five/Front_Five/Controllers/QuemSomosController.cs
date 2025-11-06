using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiveMotors.Controllers
{
    public class QuemSomosController : Controller
    {
        // GET: SobreController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SobreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SobreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SobreController/Create
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

        // GET: SobreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SobreController/Edit/5
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

        // GET: SobreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SobreController/Delete/5
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
