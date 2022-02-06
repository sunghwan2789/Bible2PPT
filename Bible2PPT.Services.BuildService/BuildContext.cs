using Bible2PPT.PPT;
using Microsoft.EntityFrameworkCore;

namespace Bible2PPT.Services.BuildService;

public class BuildContext : DbContext
{
    public BuildContext(DbContextOptions<BuildContext> options) : base(options)
    {
    }

    public DbSet<Job> Jobs => Set<Job>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Job>().OwnsMany(
            e => e.Bibles, e =>
            {
                e.WithOwner().HasForeignKey("JobId");
                e.Property<int>("Sequence").ValueGeneratedOnAdd();
                e.HasKey("Sequence");
            });
        modelBuilder.Entity<Job>().Navigation(e => e.Bibles).AutoInclude();

        modelBuilder.Entity<Job>().OwnsOne(e => e.Template);
        modelBuilder.Entity<Job>().Navigation(e => e.Template).AutoInclude();
    }
}
