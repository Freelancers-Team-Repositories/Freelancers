namespace Freelancers.Core.Contracts.Users;

public record ChangePasswordRequest(
    string CurrentPassword,
    string NewPassword
);