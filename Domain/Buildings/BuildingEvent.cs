using Infra.EventBus.Events;

namespace Domain.Buildings
{
    public record BuildingEvent : IntegrationEvent
    {
        public string Name { get; private set; }
        public int RoomAmount { get; private set; }
        public int Meters { get; private set; }
        public decimal TotalPrice { get; private set; }

        public BuildingEvent(string name, int roomAmount, int meters, decimal totalPrice)
        {
            Name = name;
            RoomAmount = roomAmount;
            Meters = meters;
            TotalPrice = totalPrice;
        }

    }
}