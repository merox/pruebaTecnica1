using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PruebaTecnica1.Models;
using PruebaTecnica1.Services;

namespace PruebaTecnica1.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductosServices ser;
        private readonly CategoriasServices cat;

        public ProductosController(tiendaBDContext db)
        {
                ser = new ProductosServices(db);
                cat = new CategoriasServices(db);
        }

        // GET: ProductosController
        public ActionResult Index()
        {
            return View(ser.GetProductosDTO());
        }


        // GET: ProductosController/Create
        public ActionResult Create()
        {
            ViewBag.CategoriasM = cat.GetAll();
            return View();
        }

        // POST: ProductosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Producto obj)
        {
            try
            {
                obj.Fechacreacion = DateTime.Now;
                ser.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoriasM = cat.GetAll();
            return View(ser.GetById(id));
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] Producto obj)
        {
            try
            {
                obj.Fechaactuailizacion= DateTime.Now;  
                ser.Update(obj, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ser.GetById(id));
        }

        // POST: ProductosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [FromForm] Producto obj)
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
