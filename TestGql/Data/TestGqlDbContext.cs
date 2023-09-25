using Microsoft.EntityFrameworkCore;
using TestGql.Model;

namespace TestGql.Data;

public class TestGqlDbContext : DbContext {
    public TestGqlDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Autore> Autori { get; set; } = null!;
    public DbSet<CasaEditrice> CaseEditrici { get; set; } = null!;
    public DbSet<Libro> Libri { get; set; } = null!;
}
