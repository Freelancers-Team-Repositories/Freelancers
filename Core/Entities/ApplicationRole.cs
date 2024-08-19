using Microsoft.AspNetCore.Identity;

namespace Freelancers.Core.Entities;
public class ApplicationRole : IdentityRole
{
    public bool IsDefault { get; set; }
}