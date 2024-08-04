using FluentValidation;
using Freelancers.Api.Contracts.Const;
using Freelancers.Api.Errors;

namespace Freelancers.Api.Contracts.Authentication;

public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
{
	public SignUpRequestValidator()
	{

		RuleFor(x => x.FirstName)
			.NotEmpty();

		RuleFor(x => x.LastName)
			.NotEmpty();


		RuleFor(x => x.Email)
			.NotEmpty()
			.EmailAddress();


		RuleFor(x => x.Password)
			.NotEmpty()
			.MinimumLength(8)
			.Matches(RegexPatterns.Password).WithMessage(UserErrors.WeakPassword);


		RuleFor(x => x.ConfirmPassword)
			.Equal(x => x.Password).WithMessage(UserErrors.ConfirmPasswordNotMatch);

	}
}
