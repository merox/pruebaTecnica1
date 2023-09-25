using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica1.Models;
using PruebaTecnica1.Services;

namespace PruebaTecnica1.Controllers
{
    public class CategoriasController : Controller
    {
        
        private readonly CategoriasServices ser;

        public CategoriasController(tiendaBDContext db)
        {
               ser = new CategoriasServices(db);
        }

        // GET: HomeController1

        public ActionResult Index()
        {
            return View(ser.GetAll());
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View(ser.GetById(id));
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Categoria obj)
        {
            try
            {
                obj.Fechacreado = DateTime.Now;
                obj.Estado = 1;
                ser.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ser.GetById(id));
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] Categoria obj)
        {
            try
            {
                ser.Update(obj, obj.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ser.GetById(id));
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,[FromForm] Categoria obj)
        {
            try
            {
                ser.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
