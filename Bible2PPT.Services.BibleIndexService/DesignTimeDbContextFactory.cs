using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bible2PPT.Services.BibleIndexService;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BibleIndexContext>
{
    public BibleIndexContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<BibleIndexContext>()
            .UseSqlite("Data Source=:memory:")
            .Options;

        return new BibleIndexContext(options);
    }
}
