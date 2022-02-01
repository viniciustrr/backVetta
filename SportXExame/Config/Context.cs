using Microsoft.EntityFrameworkCore;
using SportXExame.Entity;

namespace SportXExame.Config
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Telefone> telefone { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefone>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.telefones)
                .HasForeignKey(p => p.ClienteId);
        }


    }
}
