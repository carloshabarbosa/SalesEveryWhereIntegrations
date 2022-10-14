namespace Domain.Buildings
{
    public interface IBuildingPublisher
    {
        void Publish(BuildingRequestDto building);
    }
}