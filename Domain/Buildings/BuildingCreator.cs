using Microsoft.Extensions.Logging;

namespace Domain.Buildings
{
    public class BuildingCreator : IBuildingCreator
    {
        private readonly IBuildingRepository _repository;
        private readonly ILogger<BuildingCreator> _logger;

        public BuildingCreator(IBuildingRepository repository,
            ILogger<BuildingCreator> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Building> Create(BuildingRequestDto request)
        {
            try
            {
                var buildingDomain = request.ToDomain();

                await _repository.AddAsync(buildingDomain);
                _repository.Save();

                return buildingDomain;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to save an building");
                throw;
            }
        }
    }
}