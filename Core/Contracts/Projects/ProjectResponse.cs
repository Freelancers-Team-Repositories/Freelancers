using Freelancers.Core.Contracts.Users;
using Freelancers.Core.Entities;

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
    ApplicationUser CreatedBy,
    ApplicationUser? UpdatedBy,
    List<SubImage>? SubImages,
    List<Technology> Technologies,
    List<UserProfileResponse> Freelancer
);