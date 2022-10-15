namespace Domain.Buildings
{
    public interface IBuildingCreator
    {
        Task<Building> Create(BuildingRequestDto request);
    }
}