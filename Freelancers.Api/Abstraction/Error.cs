﻿namespace Freelancers.Api.Abstraction;

public record Error(string Code, string Description)
{
	public static readonly Error None = new(string.Empty, string.Empty);
}
