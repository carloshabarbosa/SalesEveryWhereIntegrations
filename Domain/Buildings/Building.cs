using Domain._Base;

namespace Domain.Buildings
{
    public class Building : Entity<Guid, Building>
    {
        public string Name { get; private set; }
        public int RoomAmount { get; private set; }
        public int Meters { get; private set; }
        public decimal TotalPrice { get; private set; }

        public Building(string name, int roomAmount, int meters, decimal totalPrice)
        {
            Name = name;
            RoomAmount = roomAmount;
            Meters = meters;
            TotalPrice = totalPrice;
        }
    }
}