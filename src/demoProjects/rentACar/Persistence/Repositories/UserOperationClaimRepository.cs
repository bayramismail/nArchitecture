using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, ProjectDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
