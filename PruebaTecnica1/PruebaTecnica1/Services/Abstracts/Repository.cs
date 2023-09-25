using PruebaTecnica1.Models;

namespace PruebaTecnica1.Services.Abstracts
{
    public class Repository<T> : ICrud<T>
        where T : class
    {
        protected readonly tiendaBDContext db;

        public Repository(tiendaBDContext db)
        {  
            this.db = db; 
        }

        public void Add(T obj)
        {
            db.Set<T>().Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var x = GetById(id);
            if(x != null)
            {
                db.Set<T>().Remove(x);
                db.SaveChanges();
            }
        }

        public List<T> GetAll()
        {

            return db.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Update(T obj, int id)
        {
            var x = GetById(id);
            if(x!=null)
            {
                db.Entry(x).CurrentValues.SetValues(obj);
                db.SaveChanges();
            }
        }
    }
}
