using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ModelRepository : EfRepositoryBase<Model, ProjectDbContext>, IModelRepository
    {
        public ModelRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
