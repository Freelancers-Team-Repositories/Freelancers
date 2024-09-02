using Freelancers.Core.Contracts.Authentication;
using Freelancers.Core.Contracts.Users;
using Freelancers.Core.Entities;

namespace Freelancers.Api.Mapping;
public class MappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Users
        config.NewConfig<SignUpRequest, ApplicationUser>()
            .Map(des => des.UserName, src => src.Email)
            .Map(des => des.NormalizedUserName, src => src.Email.ToUpper())
            .Map(des => des.NormalizedEmail, src => src.Email.ToUpper());


        config.NewConfig<CreateUserRequest, ApplicationUser>()
            .Map(des => des.UserName, src => src.Email)
            .Map(des => des.NormalizedUserName, src => src.Email.ToUpper())
            .Map(des => des.NormalizedEmail, src => src.Email.ToUpper());

        config.NewConfig<(ApplicationUser user, IList<string> roles), UserResponse>()
            .Map(des => des, src => src.user)
            .Map(des => des.Roles, src => src.roles);





    }
}
