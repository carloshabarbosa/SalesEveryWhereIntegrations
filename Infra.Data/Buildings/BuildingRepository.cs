using Domain.Buildings;
using Infra.Data.Context;

namespace Infra.Data.Buildings
{
    public class BuildingRepository : RepositoryBase<Guid, Building>, IBuildingRepository
    {
        private readonly DataBaseContext _context;
        public BuildingRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }
    }
}