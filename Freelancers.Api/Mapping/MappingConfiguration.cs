using Freelancers.Api.Contracts.Authentication;
using Freelancers.Api.Entities;
using Mapster;

namespace Freelancers.Api.Mapping;

public class MappingConfiguration : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<SignUpRequest, ApplicationUser>()
			.Map(des => des.UserName, src => src.Email)
			.Map(des => des.NormalizedUserName, src => src.Email.ToUpper())
			.Map(des => des.NormalizedEmail, src => src.Email.ToUpper());
	}
}
