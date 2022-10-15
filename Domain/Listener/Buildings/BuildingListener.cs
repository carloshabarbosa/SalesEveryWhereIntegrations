using Domain.Buildings;
using Domain.Publisher.Buildings;
using Infra.EventBus.Abstractions;

namespace Domain.Listener.Buildings
{
    public class BuildingListener : IIntegrationEventHandler<BuildingEvent>
    {
        private readonly IBuildingCreator _discountCreator;

        public BuildingListener(IBuildingCreator discountCreator)
        {
            _discountCreator = discountCreator;
        }

        public async Task Handle(BuildingEvent @event)
        {
            try
            {
                var request = @event.ToRequest();
                await _discountCreator.Create(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}