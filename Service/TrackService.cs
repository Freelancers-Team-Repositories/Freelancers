using Freelancers.Core.Contracts.Tracks;
using Freelancers.Core.Entities;
using Freelancers.Core.Interfaces;
using Freelancers.Core.Interfaces.UnitOfWork;
using Freelancers.Shared.Abstraction;
using Freelancers.Shared.Errors;
using Mapster;

namespace Freelancers.Service;
public class TrackService(IUnitOfWork unitOfWork) : ITrackService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<IEnumerable<TrackResponse>>> GetAllAsync()
    {
        var tracks = await _unitOfWork.Repository<Track>().GetAllAsync();

        return Result.Success(tracks.Adapt<IEnumerable<TrackResponse>>());
    }

    public async Task<Result<TrackResponse>> GetAsync(int id)
    {
        if (await _unitOfWork.Repository<Track>().GetByIdAsync(id) is not { } track)
            return Result.Failure<TrackResponse>(TrackErrors.TrackNotFound);

        return Result.Success(track.Adapt<TrackResponse>());
    }


    public async Task<Result<TrackResponse>> CreateAsync(CreateTrackRequest request)
    {
        var trackIsExists = await _unitOfWork.Repository<Track>().IsExists(x => x.Name == request.Name);
        if (trackIsExists)
            return Result.Failure<TrackResponse>(TrackErrors.DuplicatedTrack);


        var track = new Track { Name = request.Name };
        await _unitOfWork.Repository<Track>().AddAsync(track);
        await _unitOfWork.CompleteAsync();


        return Result.Success(track.Adapt<TrackResponse>());
    }


    public async Task<Result> UpdateAsync(int id, UpdateTrackRequest request)
    {
        var trackIsExists = await _unitOfWork.Repository<Track>().IsExists(x => x.Name == request.Name && x.Id != id);
        if (trackIsExists)
            return Result.Failure(TrackErrors.DuplicatedTrack);

        if (await _unitOfWork.Repository<Track>().GetByIdAsync(id) is not { } track)
            return Result.Failure(TrackErrors.TrackNotFound);

        track.Name = request.Name;

        _unitOfWork.Repository<Track>().Update(track);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }



    public async Task<Result> DeleteAsync(int id)
    {
        if (await _unitOfWork.Repository<Track>().GetByIdAsync(id) is not { } track)
            return Result.Failure<TrackResponse>(TrackErrors.TrackNotFound);

        _unitOfWork.Repository<Track>().Delete(track);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }





}
