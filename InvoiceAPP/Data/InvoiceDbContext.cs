using InvoiceAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPP.Data
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
        {

        }

        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<AdressEntity> Adresses { get; set; }
        public DbSet<ItemEntity> Items { get; set; }
    }
}
