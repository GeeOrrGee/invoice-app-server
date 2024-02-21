using InvoiceAPP.Data;

namespace InvoiceAPP.Models.Repositories
{
    public class ItemRepository : IRepository<ItemEntity>
    {
        private readonly InvoiceDbContext _context;

        public ItemRepository(InvoiceDbContext context)
        {
            _context = context;
        }

        public bool Create(ItemEntity item)
        {
            try
            {
                _context.Items.Add(item);
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
            var entity = _context.Items.FirstOrDefault(x => x.ID == id);
            if (entity != null)
            {
                _context.Items.Remove(entity);
            }
            throw new ArgumentNullException("Item with this Id does not exist");
        }

        public ItemEntity GetById(string id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Item with this Id does noe exist!");
            }
            var item = _context.Items.FirstOrDefault(x => x.ID == id);
            return item!;
        }

        public IEnumerable<ItemEntity> GetIList(string invoiceid)
        {
            var items = _context.Items.Where(x => x.invoiceID == invoiceid);
            if (items.Any())
            {
                return items.ToList();
            }
            throw new ArgumentNullException("Item with this id does not exist!");
        }

        public IEnumerable<ItemEntity> GetList()
        {
            return _context.Items.ToList();
        }

        public void Update(ItemEntity item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }
    }
}
