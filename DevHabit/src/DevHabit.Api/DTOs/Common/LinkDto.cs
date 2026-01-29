// ----------------------------------------
// DevHabit
// DevHabit.Api
// LinkDto.cs
// Created: 29.01.2026
// Author: Jens Büchert
// ------------------------------------------
// Company: August Gerstner GmbH
// ------------------------------------------

namespace DevHabit.Api.DTOs.Common;

public sealed class LinkDto
{
    public required string Href { get; init; }
    public required string Rel { get; init; }
    public required string Method { get; init; }
}
