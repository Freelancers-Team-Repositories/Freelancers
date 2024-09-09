using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancers.Core.Contracts.Users
{
    public record UserBasicInfoResponse
   (
    string Id,
    string Email,
    string FirstName,
    string LastName
        );
}
