using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bible2PPT.Services.BuildService;

public class DesigmTimeBuildContextFactory : IDesignTimeDbContextFactory<BuildContext>
{
    public BuildContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<BuildContext>()
            .UseSqlite("Data Source=:memory:")
            .Options;

        return new BuildContext(options);
    }
}
