using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Context
{
    public class EFCoreDemoContext : DbContext
    {
        public EFCoreDemoContext(DbContextOptions<EFCoreDemoContext> options) : base(options)
        {

        }
        public DbSet<Kitap> Kitaps { get; set; }
        public DbSet<Yazar> Yazars { get; set; }
        protected virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kitap>().ToTable("Kitap");
            modelBuilder.Entity<Kitap>().ToTable("Yazar");
        }

    }
}
