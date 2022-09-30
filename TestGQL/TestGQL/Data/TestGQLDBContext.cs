using Microsoft.EntityFrameworkCore;
using TestGQL.Model;

namespace TestGQL.Data {
    public class TestGQLDBContext : DbContext {
        public TestGQLDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Autore> Autori { get; set; } = null!;
        public DbSet<CasaEditrice> CaseEditrici { get; set; } = null!;
        public DbSet<Libro> Libri { get; set; } = null!;
    }
}
