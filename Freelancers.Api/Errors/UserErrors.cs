namespace Freelancers.Api.Errors;

public static class UserErrors
{
	public static readonly string WeakPassword = "Passwords contain an uppercase character, lowercase character, a digit, and a non-alphanumeric character. Passwords must be at least 8 characters long.";
	public static readonly string ConfirmPasswordNotMatch = "The password and confirmation password do not match.";
	public static readonly Error InvalidCredentials = new("User.InvalidCredentials", "Invalid email/password");
	public static readonly Error EmailNotConfirmed = new("User.EmailNotConfirmed", "Please confirm your email, check your email");
}
