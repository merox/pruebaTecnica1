namespace PruebaTecnica1.Services.Abstracts
{
    public interface ICrud<T>
        where T : class
    {
        void Add(T obj);
        void Update(T obj, int id);
        void Delete(int id);
        T? GetById(int id);
        List<T> GetAll();
    }
}
