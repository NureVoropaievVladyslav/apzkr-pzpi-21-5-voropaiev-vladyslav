using System.Reflection;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; init; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        builder.Entity<Pond>()
            .HasOne(p => p.FeedingSchedule)
            .WithOne(fs => fs.Pond)
            .HasForeignKey<FeedingSchedule>(fs => fs.PondId);

        base.OnModelCreating(builder);
    }
}