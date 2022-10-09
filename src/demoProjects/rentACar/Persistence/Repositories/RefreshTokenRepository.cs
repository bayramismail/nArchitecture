using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, ProjectDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
