using PruebaTecnica1.Models;
using PruebaTecnica1.Models.DTO;
using PruebaTecnica1.Services.Abstracts;

namespace PruebaTecnica1.Services
{
    public class PedidosServices : Repository<Pedido>
    {
        public PedidosServices(tiendaBDContext db) : base(db)
        {
        }

        public void AddPedidoDTO(PedidosDTO obj)
        {

            if (obj != null)
            {
                PedidosDTO r = obj;

                db.Pedidos.Add(r.pedido);
                db.SaveChanges();

                for (int i = 0; i < r.lsDetalle.Count; i++)
                {
                    DetallesPedido dp = new DetallesPedido();
                    dp.Idpedido = r.pedido.Id;
                    dp.Cantidad = r.lsDetalle[i].Cantidad;
                    dp.Idproducto = r.lsDetalle[i].Idproducto;
                    dp.Valor = r.lsDetalle[i].Valor;
                    dp.Valortotal = r.lsDetalle[i].Valortotal;
                    db.DetallesPedidos.Add(dp);
                }
                db.SaveChanges();
            }
        }

    }
}
