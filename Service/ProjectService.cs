using Freelancers.Core.Contracts.Projects;
using Freelancers.Core.Entities;
using Freelancers.Core.Interfaces;
using Freelancers.Core.Interfaces.UnitOfWork;
using Freelancers.Shared.Abstraction;
using Freelancers.Shared.Errors;
using Mapster;

namespace Freelancers.Service;

public class ProjectService(IUnitOfWork _unitOfWork) : IProjectService
{
    public async Task<Result<ProjectResponse>> Get(int id)
    {
        if (await _unitOfWork.Repository<Project>().GetByIdAsync(id) is not { } project)
            return Result.Failure<ProjectResponse>(ProjectErrors.ProjectNotFound);


        return Result.Success(project.Adapt<ProjectResponse>());
    }
}
