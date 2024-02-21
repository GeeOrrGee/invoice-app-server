using InvoiceAPP.Data;

namespace InvoiceAPP.Models.Repositories
{
    public class InvoiceRepository : IRepository<InvoiceEntity>
    {
        private readonly InvoiceDbContext _context;

        public InvoiceRepository(InvoiceDbContext context)
        {
            _context = context;
        }

        public bool Create(InvoiceEntity item)
        {
            try
            {
                _context.Invoices.Add(item);
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
            var entity = _context.Invoices.FirstOrDefault(x => x.ID == id);
            if (entity != null)
            {
                _context.Invoices.Remove(entity);
                _context.SaveChanges();
            }
            throw new ArgumentException("Invoice with this id does not exist!");
        }

        public void Update(InvoiceEntity item)
        {
            _context.Invoices.Update(item);
            _context.SaveChanges();
        }

        public InvoiceEntity GetById(string id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Invoice with this id does not exist!");
            }
            var invoice = _context.Invoices.FirstOrDefault(x => x.ID == id);
            return invoice!;
        }

        IEnumerable<InvoiceEntity> IRepository<InvoiceEntity>.GetIList(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InvoiceEntity> GetList()
        {
            return _context.Invoices.ToList();
        }
    }
}
