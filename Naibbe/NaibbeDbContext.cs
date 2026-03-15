using Microsoft.EntityFrameworkCore;

namespace Naibbe;

internal class NaibbeDbContext : DbContext
{
    public DbSet<TranslationTable> TranslationTables { get; set; }
    public string DbPath { get; init; }
        = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"naibbe.db");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}
