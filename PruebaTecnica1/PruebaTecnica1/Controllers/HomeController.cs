using Microsoft.AspNetCore.Mvc;
using PruebaTecnica1.Models;
using PruebaTecnica1.Models.DTO;
using PruebaTecnica1.Services;
using System.Diagnostics;

namespace PruebaTecnica1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductosServices pro;
        private readonly ClientesServices cli;
        private readonly PedidosServices ser;

        public HomeController(tiendaBDContext db)
        {
            ser = new PedidosServices(db);
            pro = new ProductosServices(db);
            cli = new ClientesServices(db);
        }

        public IActionResult Index(DateTime? f1, DateTime? f2)
        {
            if (f1 == null)
                f1 = new DateTime(2000, 01, 01);

            if (f2 == null)
                f2 = DateTime.Now;

            return View(pro.GetProductosXPedidoDTO(f1.Value, f2.Value));
        }

        public ActionResult Create()
        {
            ViewBag.Productos = pro.GetProductosDTO();
            ViewBag.Productos2 = pro.GetProductosDTO2();
            ViewBag.Clientes = cli.GetClientesDTO();
            return View();
        }

      
        [HttpPost]
        public IActionResult Insert([FromBody] PedidosDTO PedidosDTO)
        {
            ser.AddPedidoDTO(PedidosDTO);
            //return RedirectToAction(nameof(Index));
            return Json(new { respuesta=true});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}