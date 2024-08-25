using Freelancers.Shared.Abstraction;
using Microsoft.AspNetCore.Http;


namespace Freelancers.Shared.Errors;

public static class ProjectErrors
{
    public static readonly Error ProjectNotFound = new Error("User.ProjectNotFound", "this project is not exists", StatusCodes.Status404NotFound);
    public static readonly Error ProjectRequestIsNotValid = new Error("User.ProjectRequestIsNotValid", "Project request is not valid", StatusCodes.Status400BadRequest);
    public static readonly Error BadRequest = new Error("User.BadRequest", "Bad Request", StatusCodes.Status400BadRequest);
    public static readonly Error UnExpectedError = new Error("User.UnExpectedError", "An unexpected error occurred", StatusCodes.Status500InternalServerError);
    public static readonly Error ProjectCreationFailed = new Error("User.ProjectCreationFailed", "Project creation failed", StatusCodes.Status500InternalServerError);

}
