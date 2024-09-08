using Freelancers.Core.Interfaces.UnitOfWork;
using Freelancers.Core.Interfaces;
using Freelancers.Repository.Implementations;
namespace Freelancers.Service
{
  
    class TaskService(IUnitOfWork unitOfWork) : ITaskService
    {

        private readonly IUnitOfWork _unitOfWork = unitOfWork;

    }
}
