using Bible2PPT.Bibles;
using Microsoft.EntityFrameworkCore;

namespace Bible2PPT.Data;

public class BibleContext : DbContext
{
    public BibleContext(DbContextOptions<BibleContext> options) : base(options)
    {
    }

    public DbSet<Bible> Bibles => Set<Bible>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Chapter> Chapters => Set<Chapter>();
    public DbSet<Verse> Verses => Set<Verse>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Bible>().HasIndex(e => e.SourceId);

        modelBuilder.Entity<Book>().HasIndex(e => e.SourceId);
        modelBuilder.Entity<Book>().HasIndex(e => e.BibleId);
        modelBuilder.Entity<Book>().Navigation(e => e.Bible).AutoInclude();

        modelBuilder.Entity<Chapter>().HasIndex(e => e.SourceId);
        modelBuilder.Entity<Chapter>().HasIndex(e => e.BookId);
        modelBuilder.Entity<Chapter>().Navigation(e => e.Book).AutoInclude();

        modelBuilder.Entity<Verse>().HasIndex(e => e.SourceId);
        modelBuilder.Entity<Verse>().HasIndex(e => e.ChapterId);
        modelBuilder.Entity<Verse>().Navigation(e => e.Chapter).AutoInclude();
    }
}
