using Domain.Buildings;
using Domain.Publisher.Buildings;

namespace Domain;

public class BuildingRequestDto
{
    public string Name { get; private set; }
    public int RoomAmount { get; private set; }
    public int Meters { get; private set; }
    public decimal TotalPrice { get; private set; }

    public BuildingRequestDto(string name, int roomAmount, int meters, decimal totalPrice)
    {
        Name = name;
        RoomAmount = roomAmount;
        Meters = meters;
        TotalPrice = totalPrice;
    }

    public BuildingEvent ToEvent()
    {
        return new BuildingEvent(Name, RoomAmount, Meters, TotalPrice);
    }

    public Building ToDomain()
    {
        return new Building(Name, RoomAmount, Meters, TotalPrice);
    }
}