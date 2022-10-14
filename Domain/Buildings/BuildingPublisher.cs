using Infra.EventBus.Abstractions;
using Microsoft.Extensions.Logging;

namespace Domain.Buildings
{
    public class BuildingPublisher : IBuildingPublisher
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger _logger;

        public BuildingPublisher(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Publish(BuildingRequestDto buildingRequest)
        {
            var building = buildingRequest.ToDomain();
            var buildingEvent = building.ToEvent();
            try
            {
                _eventBus.Publish(buildingEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Publishing integration event: {IntegrationEventId} from {AppName}", buildingEvent.Id, nameof(BuildingPublisher));
                throw;
            }
        }
    }
}