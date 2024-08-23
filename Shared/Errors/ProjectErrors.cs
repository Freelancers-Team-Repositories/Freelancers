using Freelancers.Shared.Abstraction;
using Microsoft.AspNetCore.Http;


namespace Freelancers.Shared.Errors;

public static class ProjectErrors
{
    public static readonly Error ProjectNotFound = new Error("User.ProjectNotFound", "this project is not exists", StatusCodes.Status404NotFound);
}
