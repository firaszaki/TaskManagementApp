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
}
