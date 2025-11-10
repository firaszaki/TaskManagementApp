using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Domain;

public class ApplicationDbContext : DbContext
{
    private readonly IServiceProvider serviceProvider;

    public ApplicationDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options)
    {
        this.serviceProvider = serviceProvider;
    }

    public DbSet<TaskEntity> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureTaskEntity();
    }
}
