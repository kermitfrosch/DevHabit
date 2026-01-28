// ----------------------------------------
// DevHabit
// DevHabit.Api
// HabitsController.cs
// Created: 28.01.2026
// Author: Jens Büchert
// ------------------------------------------
// Company: August Gerstner GmbH
// ------------------------------------------
using System.Threading;
using DevHabit.Api.Database;
using DevHabit.Api.DTOs.Habits;
using DevHabit.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHabit.Api.Controllers;

[ApiController]
[Route("habits")]
public sealed class HabitsController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<HabitCollectionDto>> GetHabitsAsync(CancellationToken cancellationToken)
    {
        List<HabitDto> habits = await dbContext.Habits
            .Select(h => new HabitDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                Type = h.Type,
                Frequency = new FrequencyDto
                {
                    TimesPerPeriod = h.Frequency.TimesPerPeriod,
                    Type = h.Frequency.Type
                },
                Target = new TargetDto
                {
                    Value = h.Target.Value,
                    Unit = h.Target.Unit
                },
                Status = h.Status,
                IsArchived = h.IsArchived,
                EndDate = h.EndDate,
                Milestone = h.MileStone == null ? null : new MilestoneDto
                {
                    Current = h.MileStone.Current,
                    Target = h.MileStone.Target
                },
                CreatedAtUtc = h.CreatedAtUtc,
                UpdatedAtUtc = h.UpdatedAtUtc,
                LastCompletedAtUtc = h.LastCompletedAtUtc
            })
            .ToListAsync(cancellationToken);

        return Ok(new HabitCollectionDto
        {
            Data = habits
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HabitDto>> GetHabitAsync(string id, CancellationToken cancellationToken)
    {
        HabitDto? habit = await dbContext.Habits
            .Where(h => h.Id == id)
            .Select(h => new HabitDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                Type = h.Type,
                Frequency = new FrequencyDto
                {
                    TimesPerPeriod = h.Frequency.TimesPerPeriod,
                    Type = h.Frequency.Type
                },
                Target = new TargetDto
                {
                    Value = h.Target.Value,
                    Unit = h.Target.Unit
                },
                Status = h.Status,
                IsArchived = h.IsArchived,
                EndDate = h.EndDate,
                Milestone = h.MileStone == null ? null : new MilestoneDto
                {
                    Current = h.MileStone.Current,
                    Target = h.MileStone.Target
                },
                CreatedAtUtc = h.CreatedAtUtc,
                UpdatedAtUtc = h.UpdatedAtUtc,
                LastCompletedAtUtc = h.LastCompletedAtUtc
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (habit == null)
        {
            return NotFound();
        }

        return Ok(habit);
    }

    [HttpPost]
    public async Task<ActionResult<HabitDto>> CreateHabitAsync(CreateHabitDto createHabitRequest)
    {
        Habit habit = createHabitRequest.ToEntity();
        dbContext.Habits.Add(habit);
        await dbContext.SaveChangesAsync();
        return Ok();


    }
}
