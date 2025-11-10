using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementApp.Domain.Entities;

[Table("Tasks")]
public class TaskEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public TaskStatus Status { get; set; } = TaskStatus.Pending;

    [Required]
    public bool IsCompleted { get; set; }

    public DateTime? CreatedAt { get; set; }
}

public enum TaskStatus
{
    // Not started
    [Display(Name = "Pending")]
    Pending,

    // Currently being worked on
    [Display(Name = "In Progress")]
    InProgress,

    // Settled
    [Display(Name = "Completed")]
    Completed
}

public static partial class EntityConfigurationExtensions
{
    public static void ConfigureTaskEntity(this ModelBuilder builder)
    {
        builder.Entity<TaskEntity>(entity =>
        {
            entity.Property(c => c.Status)
                .HasConversion<string>()
                .IsRequired();
        });
    }
}