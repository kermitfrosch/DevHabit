// ----------------------------------------
// DevHabit
// DevHabit.Api
// Habit.cs
// Created: 28.01.2026
// Author: Jens Büchert
// ------------------------------------------
// Company: August Gerstner GmbH
// ------------------------------------------

namespace DevHabit.Api.Entities;

public sealed class Habit
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public HabitType Type { get; set; }
    public Frequency Frequency { get; set; }

}

public enum HabitType
{
    None = 0,
    Binary = 1,
    Measurable = 2
}

public sealed class Frequency
{
    public FrequencyType Type { get; set; }
    public int TimesPerPeriod { get; set; }
}

public enum FrequencyType
{
    Daily = 0,
    Weekly = 1,
    Monthly = 2
}   
