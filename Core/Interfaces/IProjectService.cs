using Freelancers.Core.Contracts.Projects;
using Freelancers.Shared.Abstraction;

namespace Freelancers.Core.Interfaces;

public interface IProjectService
{
    Task<Result<ProjectResponse>> Get(int id);
}
