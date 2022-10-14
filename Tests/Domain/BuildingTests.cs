using Bogus;
using Domain.Buildings;
using Tests._Base;
using Xunit;

namespace Tests.Domain
{
    public class BuildingTests
    {
        private readonly Faker _faker;

        public BuildingTests()
        {
            _faker = FakerBuilder.New().Build();
        }


        [Fact]
        public void Should_Create_An_Building()
        {
            var name = _faker.Random.String2(length: 10);
            var roomAmount = _faker.Random.Int(min: 1, max: 4);
            var meters = _faker.Random.Int(min: 100, max: 200);
            var totalPrice = _faker.Random.Decimal(min: 1);

            var building = new Building(
                name, roomAmount, meters, totalPrice
            );

            Assert.Equal(name, building.Name);
            Assert.Equal(roomAmount, building.RoomAmount);
            Assert.Equal(meters, building.Meters);
            Assert.Equal(totalPrice, building.TotalPrice);
        }
    }


}