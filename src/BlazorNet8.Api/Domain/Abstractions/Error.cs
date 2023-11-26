﻿namespace BlazorNet8.Api.Domain.Abstractions;

public sealed record Error(string Code, string? Description = null)
{
    public static readonly Error None = new(string.Empty);
}