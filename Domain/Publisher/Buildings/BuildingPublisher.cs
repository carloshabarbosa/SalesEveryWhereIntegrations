using Infra.EventBus.Abstractions;
using Microsoft.Extensions.Logging;

namespace Domain.Publisher.Buildings
{
    public class BuildingPublisher : IBuildingPublisher
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<BuildingPublisher> _logger;

        public BuildingPublisher(IEventBus eventBus,
            ILogger<BuildingPublisher> logger)
        {
            _eventBus = eventBus;
            _logger = logger;
        }

        public void Publish(BuildingRequestDto buildingRequest)
        {
            var buildingEvent = buildingRequest.ToEvent();
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