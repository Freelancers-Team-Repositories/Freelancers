using Microsoft.AspNetCore.Http;

namespace Freelancers.Core.Contracts.Projects;
public record ProjectRequest(
    string Title,
    string Description,
    string Summary,
    string ProjectUrl,
    IFormFile ImageFile,
    IFormFile? VideoFile,
    List<IFormFile>? SubImages,
    List<int> Technologies,
    List<string> Freelancer
);