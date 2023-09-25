using PruebaTecnica1.Models;
using PruebaTecnica1.Services.Abstracts;

namespace PruebaTecnica1.Services
{
    public class CategoriasServices: Repository<Categoria>
    {
        public CategoriasServices(tiendaBDContext db): base(db) 
        { }
    }
}
