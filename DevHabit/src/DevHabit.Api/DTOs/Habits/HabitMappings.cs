// ----------------------------------------
// DevHabit
// DevHabit.Api
// HabitMappings.cs
// Created: 28.01.2026
// Author: Jens Büchert
// ------------------------------------------
// Company: August Gerstner GmbH
// ------------------------------------------

using DevHabit.Api.Entities;

namespace DevHabit.Api.DTOs.Habits;

public static class HabitMappings
{
    public static Habit ToEntity(this CreateHabitDto dto)
    {
        Habit habit = new()
        {
            Id = $"h_{Guid.CreateVersion7()}",
            Name = dto.Name,
            Description = dto.Description,
            Type = dto.Type,
            Frequency = new Frequency
            {
                Type = dto.Frequency.Type,
                TimesPerPeriod = dto.Frequency.TimesPerPeriod
            },
            Target = new Target
            {
                Value = dto.Target.Value,
                Unit = dto.Target.Unit
            },
            Status = HabitStatus.Ongoing,
            IsArchived = false,
            EndDate = dto.EndDate,
            CreatedAtUtc = DateTime.UtcNow,
            MileStone = new MileStone
            {
                Current = dto.Milestone.Current,
                Target = dto.Milestone.Target
            }
        };

        return habit;
    }
}
