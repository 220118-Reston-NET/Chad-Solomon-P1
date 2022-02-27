using Xunit;
using PokeModel;
using System.Threading.Tasks;

namespace UnitTest
{

    public class OrderLocationTesting
    {
        [Fact]
        public async Task SetValidLocation()
        {
            //Arrange
            Order order = new Order();
            string validLocation = "123 Bebop Lane Maryville, TN";

            //ACT
            order.StoreLocation = validLocation;

            //Assert
            Assert.NotNull(order.StoreLocation);
            Assert.Equal(validLocation, order.StoreLocation);


        }




    }



}