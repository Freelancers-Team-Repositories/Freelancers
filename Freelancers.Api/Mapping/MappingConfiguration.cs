using Freelancers.Core.Contracts.Authentication;
using Freelancers.Core.Contracts.Projects;
using Freelancers.Core.Contracts.Users;
using Freelancers.Core.Entities;
using Freelancers.Shared.Abstraction.Const;

namespace Freelancers.Api.Mapping;
public class MappingConfiguration : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<SignUpRequest, ApplicationUser>()
			.Map(des => des.UserName, src => src.Email)
			.Map(des => des.NormalizedUserName, src => src.Email.ToUpper())
			.Map(des => des.NormalizedEmail, src => src.Email.ToUpper());

		config.NewConfig<ApplicationUser, UserProfileResponse>()
			.Map(des => des.Email, src => src.Email)
			.Map(des => des.FirstName, src => src.FirstName)
			.Map(des => des.LastName, src => src.LastName);

		config.NewConfig<Project, ProjectResponse>()
			.Map(des => des.ImageUrl, src => "https://localhost:7189/" + ImagesData.ProjectImagesPath + src.ImageUrl)
			.Map(des => des.VideoUrl, src => "https://localhost:7189/" + ImagesData.ProjectImagesPath + src.VideoUrl)
            .Map(des => des.CreatedBy, src => src.CreatedBy.Adapt<UserProfileResponse>())
            .Map(des => des.UpdatedBy, src => src.UpdatedBy.Adapt<UserProfileResponse>())
            .Map(des => des.ImagesUrl, src => src.SubImages.Select(x => "https://localhost:7189/" + ImagesData.ProjectImagesPath + x.Url).ToList())
            .Map(des => des.Technologies, src => src.ProjectTechnologies.Select(x => x.Technology.Name).ToList())
            .Map(des => des.Freelancers, src => src.FreelancerProjects.Select(x => x.Freelancer.Adapt<UserProfileResponse>()).ToList());
	}
}