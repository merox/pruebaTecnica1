using PruebaTecnica1.Models;
using PruebaTecnica1.Models.DTO;
using PruebaTecnica1.Services.Abstracts;
using System.Data.Common;
using System.Runtime.Intrinsics.Arm;

namespace PruebaTecnica1.Services
{
    public class ProductosServices : Repository<Producto>
    {
        public ProductosServices(tiendaBDContext db) : base(db)
        {
        }


        public List<ProductosDTO> GetProductosDTO()
        {
            return (from p in db.Productos
                    join c in db.Categorias on p.Idcategoria equals c.Id
                    select new ProductosDTO()
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                        Precioventa = p.Precioventa,
                        Fechacreacion = p.Fechacreacion,
                        Nombrecategoria = c.Nombre
                    }).ToList();
        }

        public List<ProductosDTO> GetProductosDTO2()
        {
            return (from p in db.Productos
                    join c in db.Categorias on p.Idcategoria equals c.Id
                    select new ProductosDTO()
                    {
                        Id = p.Id,
                        Nombre = p.Nombre + "  [" + p.Precioventa.ToString() ,
                        Precioventa = p.Precioventa,
                        Fechacreacion = p.Fechacreacion,
                        Nombrecategoria = c.Nombre
                    }).ToList();
        }

        public List<ProductosXPedidoDTO> GetProductosXPedidoDTO(
            DateTime f1, DateTime f2)
        {
            return (from p in db.Productos
                    join c in db.Categorias on p.Idcategoria equals c.Id
                    join dp in db.DetallesPedidos on p.Id equals dp.Idproducto
                    join pe in db.Pedidos on dp.Idpedido equals pe.Id
                    where pe.Fecha >= f1 && pe.Fecha<= f2 
                    group new {p.Id, p.Nombre, cat= c.Nombre, dp.Cantidad }
                       by new {p.Id, p.Nombre, cat=c.Nombre} into grupo
                    select new ProductosXPedidoDTO() 
                    { 
                        Id= grupo.Key.Id,
                        Nombre = grupo.Key.Nombre,
                        Categoria= grupo.Key.cat,
                        CantidadPedidos = grupo.Sum(x=> x.Cantidad).GetValueOrDefault()
                    }).ToList();
        }
    }
}
