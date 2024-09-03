
using Freelancers.Shared.Abstraction;
using Microsoft.AspNetCore.Http;

namespace Freelancers.Shared.Errors;

public static class TrackErrors
{
    public static readonly Error DuplicatedTrack = new("Track.DuplicatedTrack", "Another Track with the same email is already exists", StatusCodes.Status409Conflict);
    public static readonly Error TrackNotFound = new("Track.NotFound", "Track is not found ", StatusCodes.Status404NotFound);
    public static readonly Error InvalidTracks = new("User.InvalidTracks", "Invalid Tracks", StatusCodes.Status400BadRequest);
}
