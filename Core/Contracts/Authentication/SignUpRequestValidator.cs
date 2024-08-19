using FluentValidation;
using Freelancers.Shared.Abstraction.Const;

namespace Freelancers.Core.Contracts.Authentication;

public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
{
	public SignUpRequestValidator()
	{

		RuleFor(x => x.FirstName)
			.NotEmpty()
			.Length(3, 100);

		RuleFor(x => x.LastName)
			.NotEmpty()
			.Length(3, 100);


		RuleFor(x => x.Email)
			.NotEmpty()
			.EmailAddress();


		RuleFor(x => x.Password)
			.NotEmpty()
			.Matches(RegexPatterns.Password).WithMessage("Password should be at least 8 digits and should contains Lowercase, NonAlphanumeric and Uppercase");


		RuleFor(x => x.ConfirmPassword)
			.Equal(x => x.Password).WithMessage("Passwords do not match. Please make sure both password fields are identical");

	}
}
