﻿using Microsoft.AspNetCore.Identity;

namespace Freelancers.Core.Entities;
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}