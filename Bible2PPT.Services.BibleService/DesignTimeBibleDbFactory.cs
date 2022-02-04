using Bible2PPT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bible2PPT.Services.BibleService;

public class DesignTimeBibleDbFactory : IDesignTimeDbContextFactory<BibleContext>
{
    public BibleContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<BibleContext>()
            .UseSqlite("Data Source=:memory:")
            .Options;

        return new BibleContext(options);
    }
}
