using Freelancers.Core.Contracts.Tracks;
using Freelancers.Shared.Abstraction;

namespace Freelancers.Core.Interfaces;
public interface ITrackService
{
    Task<Result<IEnumerable<TrackResponse>>> GetAllAsync();
    Task<Result<TrackResponse>> GetAsync(int id);
    Task<Result<TrackResponse>> CreateAsync(CreateTrackRequest request);
    Task<Result> UpdateAsync(int id, UpdateTrackRequest request);
    Task<Result> DeleteAsync(int id);
}
