using Microsoft.EntityFrameworkCore;

namespace Bible2PPT.Services.BibleIndexService;

public class BibleIndexContext : DbContext
{
    public BibleIndexContext(DbContextOptions<BibleIndexContext> options)
        : base(options)
    {
    }

    public DbSet<BookInfo> BookInfos => Set<BookInfo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookInfo>().HasKey(x => new { x.Key, x.Kind, x.LanguageCode, x.Version });
        modelBuilder.Entity<BookInfo>().HasData(new[]
            {
                BibleIndexSeed.SeedKoreanV1(),
                BibleIndexSeed.SeedKoreanV2(),
            }
            .SelectMany(x => x));
    }
}
