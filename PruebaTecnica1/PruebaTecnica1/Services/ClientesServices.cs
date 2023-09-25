using PruebaTecnica1.Models;
using PruebaTecnica1.Models.DTO;
using PruebaTecnica1.Services.Abstracts;
using System.Security.Cryptography.X509Certificates;

namespace PruebaTecnica1.Services
{
    public class ClientesServices : Repository<Cliente>
    {
        public ClientesServices(tiendaBDContext db) : base(db)
        {
        }

        public List<ClientesDTO> GetClientesDTO()
        {
            return (from t1 in db.Clientes 
                    select new ClientesDTO()
                    { 
                        Id=t1.Id,
                        Nombre = "[" + t1.Id+ "] " +
                            t1.Nombre.ToUpper() +" " + t1.Apellido.ToUpper()
                    }).ToList();
        }
    }
}
