using Freelancers.Core.Contracts.Users;

namespace Freelancers.Core.Contracts.Projects;
public record ProjectResponse(
    int Id,
    string Title,
    string Description,
    string Summary,
    string ProjectUrl,
    string ImageUrl,
    string? VideoUrl,
    bool IsAvailable,
    DateTime CreatedOn,
    DateTime? LastUpdatedOn,
    UserProfileResponse CreatedBy,
    UserProfileResponse? UpdatedBy,
    List<string>? ImagesUrl,
    List<string> Technologies,
    List<UserProfileResponse> Freelancers
);