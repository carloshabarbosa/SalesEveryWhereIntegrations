using Domain.Buildings;

namespace Domain;

public class BuildingRequestDto
{
    public string Name { get; set; }
    public int RoomAmount { get; set; }
    public int Meters { get; set; }
    public decimal TotalPrice { get; set; }

    public Building ToDomain()
    {
        return new Building(Name, RoomAmount, Meters, TotalPrice);
    }
}