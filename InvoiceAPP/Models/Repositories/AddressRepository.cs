
using InvoiceAPP.Data;

namespace InvoiceAPP.Models.Repositories
{
    public class AddressRepository : IRepository<AdressEntity>
    {
        private readonly InvoiceDbContext _context;

        public AddressRepository(InvoiceDbContext context)
        {
            _context = context;
        }
        public bool Create(AdressEntity item)
        {
            try
            {
                _context.Adresses.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Delete(string id)
        {
            var entity= _context.Adresses.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _context.Adresses.Remove(entity);
            }
            throw new ArgumentNullException("Address with this id does not exist");
        }

        public AdressEntity GetById(string id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Address with this id does not exist!");
            }
            var address= _context.Adresses.FirstOrDefault(x => x.Id==id);
            return address!;
        }

         IEnumerable<AdressEntity> IRepository<AdressEntity>.GetIList(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdressEntity> GetList()
        {
            return _context.Adresses.ToList();
        }

        public void Update(AdressEntity item)
        {
            _context.Adresses.Update(item);
            _context.SaveChanges();
        }
    }
}
