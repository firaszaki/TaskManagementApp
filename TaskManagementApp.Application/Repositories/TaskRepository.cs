using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using TaskManagementApp.Domain;
using TaskManagementApp.Domain.Commons;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.Repositories;

public class TaskRepository
{
    private readonly ILogger<TaskRepository> logger;
    private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

    public TaskRepository(ILogger<TaskRepository> logger, IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        this.logger = logger;
        this.dbContextFactory = dbContextFactory;
    }

    /// <summary>
    /// Get task by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<IProcessResult<TaskEntity?>> GetAsync(long id, CancellationToken token = new())
    {
        using var context = dbContextFactory.CreateDbContext();
        var entity = await context.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, token);

        if (entity != null)
        {
            return new ProcessResult<TaskEntity?>(true, "Successfully retrieved data.", entity);
        }

        return new ProcessResult<TaskEntity?>(false, "Data not found.", null);
    }

    public async Task<IProcessResult<long>> AddAsync(TaskEntity input)
    {
        using var context = dbContextFactory.CreateDbContext();

        input.CreatedAt = DateTime.Now;

        await context.Tasks.AddAsync(input);
        await context.SaveChangesAsync();

        var insertedId = input.Id;
        return new ProcessResult<long>(true, "Successfully inserted data.", insertedId);
    }

    public async Task<IProcessResult> UpdateAsync(TaskEntity input)
    {
        try
        {
            using var context = dbContextFactory.CreateDbContext();

            if(input.Status == Domain.Entities.TaskStatus.Completed)
            {
                input.IsCompleted = true;
            }
            else
            {
                input.IsCompleted = false;
            }

            context.Entry(input).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return new ProcessResult(true, "Successfully updated task.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            logger.LogError(ex.ToString(), "Failed to update task.");
            return new ProcessResult(false, "Failed to update task.");
        }
    }

    public async Task<IProcessResult> DeleteAsync(long id)
    {
        try
        {
            using var context = dbContextFactory.CreateDbContext();

            var entity = await context.Tasks.FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null)
            {
                return new ProcessResult(false, "Task not found");
            }

            context.Entry(entity).State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return new ProcessResult(true, "Successfully deleted.");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            logger.LogError(ex.ToString());
            return new ProcessResult(false, "Failed to delete record.");
        }
    }
}
