namespace Domain.Publisher.Buildings
{
    public interface IBuildingPublisher
    {
        void Publish(BuildingRequestDto building);
    }
}