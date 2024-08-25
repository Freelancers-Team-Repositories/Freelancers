using Freelancers.Core.Contracts.Projects;
using Freelancers.Core.Entities;
using Freelancers.Core.Interfaces;
using Freelancers.Core.Interfaces.UnitOfWork;
using Freelancers.Shared.Abstraction;
using Freelancers.Shared.Errors;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Freelancers.Service;
public class ProjectService(IUnitOfWork _unitOfWork, IWebHostEnvironment _webHostEnvironment, UserManager<ApplicationUser> _userManager) : IProjectService
{

    public async Task<Result<ProjectResponse>> Create(ProjectRequest projectRequest, string userId)
    {
        if (projectRequest == null)
        {
            return Result.Failure<ProjectResponse>(ProjectErrors.ProjectRequestIsNotValid);
        }

        try
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            var project = new Project()
            {
                Title = projectRequest.Title,
                Description = projectRequest.Description,
                Summary = projectRequest.Summary,
                ProjectUrl = projectRequest.ProjectUrl,
                ImageUrl = await SaveCover(projectRequest.ImageFile),
                IsActive = true,
                IsAvailable = true,
                CreatedBy = user!,
                CreatedById = user!.Id,
                UpdatedBy = user,
                UpdatedById = user!.Id,
                CreatedOn = DateTime.Now,
                LastUpdatedOn = DateTime.Now,
            };

            if (projectRequest.VideoFile != null)
                project.VideoUrl = await SaveCover(projectRequest.VideoFile);

            await _unitOfWork.Repository<Project>().AddAsync(project);

            var rowsAffected1 = await _unitOfWork.CompleteAsync();

            if (rowsAffected1 <= 0)
                return Result.Failure<ProjectResponse>(ProjectErrors.ProjectCreationFailed);

            var _imageRepo = _unitOfWork.Repository<SubImage>();

            foreach (var subImage in projectRequest.SubImages!)
            {
                var subImageUrl = await SaveCover(subImage);

                var subImageEntity = new SubImage { ProjectId = project.Id, Url = subImageUrl!, Project = project };

                await _imageRepo.AddAsync(subImageEntity);

                project.SubImages.Add(subImageEntity);
            }


            var _freelancerProjectRepo = _unitOfWork.Repository<FreelancerProject>();

            foreach (var freelancerId in projectRequest.Freelancer)
            {
                var freelancer = _userManager.Users.FirstOrDefault(x => x.Id == freelancerId);

                var freelancerProject = new FreelancerProject { ProjectId = project.Id, Project = project, FreelancerId = freelancerId, Freelancer = freelancer! };

                await _freelancerProjectRepo.AddAsync(freelancerProject);

                project.FreelancerProjects.Add(freelancerProject);
            }


            var _projectTechnologyRepo = _unitOfWork.Repository<ProjectTechnology>();

            foreach (var technologyId in projectRequest.Technologies)
            {
                var technology = await _unitOfWork.Repository<Technology>().GetByIdAsync(technologyId);

                var projectTechnology = new ProjectTechnology { ProjectId = project.Id, Project = project, TechnologyId = technologyId, Technology = technology! };

                await _projectTechnologyRepo.AddAsync(projectTechnology);

                project.ProjectTechnologies.Add(projectTechnology);
            }


            _unitOfWork.Repository<Project>().UpdateAsync(project);

            var rowsAffected2 = await _unitOfWork.CompleteAsync();

            var projectResponse = project.Adapt<ProjectResponse>();

            if (rowsAffected2 > 0)
                return Result.Success(project.Adapt<ProjectResponse>());

            // If the project is not created successfully, return BadRequest
            return Result.Failure<ProjectResponse>(ProjectErrors.BadRequest);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return Result.Failure<ProjectResponse>(ProjectErrors.UnExpectedError);
        }
    }

    public Task<Result<ProjectResponse>> Update(ProjectRequest projectRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ProjectResponse>> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<ProjectResponse>> Get(int id)
    {
        if (await _unitOfWork.Repository<Project>().GetByIdAsync(id) is not { } project)
            return Result.Failure<ProjectResponse>(ProjectErrors.ProjectNotFound);


        return Result.Success(project.Adapt<ProjectResponse>());
    }

    public Task<Result<List<ProjectResponse>>> GetAll()
    {
        throw new NotImplementedException();
    }

    private async Task<string> SaveCover(IFormFile image)
    {
        var imageName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";

        var path = Path.Combine(_webHostEnvironment.WebRootPath + "/Images/Projects", imageName);

        using var stream = File.Create(path);
        await image.CopyToAsync(stream);

        return imageName;
    }
}