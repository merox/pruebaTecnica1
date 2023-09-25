using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica1.Models;
using PruebaTecnica1.Services;

namespace PruebaTecnica1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClientesServices ser;

        public ClientesController(tiendaBDContext db)
        {
                ser = new ClientesServices(db);
        }

        // GET: Clientes
        public ActionResult Index()
        {
            return View(ser.GetAll());
        }


        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Cliente  obj)
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

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ser.GetById(id));
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] Cliente obj)
        {
            try
            {
                ser.Update(obj, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ser.GetById(id));
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [FromForm] Cliente ob)
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
