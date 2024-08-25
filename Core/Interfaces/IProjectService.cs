using Freelancers.Core.Contracts.Projects;
using Freelancers.Shared.Abstraction;

namespace Freelancers.Core.Interfaces;
public interface IProjectService
{
    Task<Result<ProjectResponse>> Create(ProjectRequest projectRequest, string userId);
    Task<Result<ProjectResponse>> Update(ProjectRequest projectRequest);
    Task<Result<ProjectResponse>> Delete(int id);
    Task<Result<List<ProjectResponse>>> GetAll();
    Task<Result<ProjectResponse>> Get(int id);
}