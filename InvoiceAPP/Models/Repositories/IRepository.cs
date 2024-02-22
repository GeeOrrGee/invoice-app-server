namespace InvoiceAPP.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(string id);
        IEnumerable<T> GetList();
        IEnumerable<T> GetIList(string id);
        IEnumerable<T> GetListByStatus(string status);
        bool Create(T item);
        void Update(T item);
        void Delete(string id);
        
    }
}
