using Xunit;
using PokeModel;

namespace UnitTest
{

    public class OrderLocationTesting
    {
        [Fact]
        public void SetValidLocation()
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