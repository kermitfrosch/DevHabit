// ----------------------------------------
// DevHabit
// DevHabit.Api
// DatabaseExtensions.cs
// Created: 27.01.2026
// Author: Jens Büchert
// ------------------------------------------
// Company: August Gerstner GmbH
// ------------------------------------------

using DevHabit.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace DevHabit.Api.Extensions;

public static class DatabaseExtensions
{
    public static async Task ApplyMigrationsAsync(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        await using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        try
        {
            await dbContext.Database.MigrateAsync();
            app.Logger.LogInformation("Database migrations applied succesfully");
        }
        catch (Exception e)
        {
            app.Logger.LogError(e, "An error occured while applying database migrations.");
            throw;
        }
    }
}
