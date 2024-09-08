using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancers.Core.Contracts.Users
{
    public record CreatedByResponse
   (
    string Id,
    string Email,
    string FirstName,
    string LastName
        );
}
