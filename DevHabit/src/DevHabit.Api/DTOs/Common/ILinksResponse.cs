// ----------------------------------------
// DevHabit
// DevHabit.Api
// ILinksResponse.cs
// Created: 29.01.2026
// Author: Jens Büchert
// ------------------------------------------
// Company: August Gerstner GmbH
// ------------------------------------------

namespace DevHabit.Api.DTOs.Common;

public interface ILinksResponse
{
    List<LinkDto> Links { get; set; }
}
