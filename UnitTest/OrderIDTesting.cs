using Xunit;
using PokeModel;

namespace UnitTest
{

    public class OrderIDTesting
    {
        [Fact]
        public void SetValidID()
        {
            //Arrange
            Order order = new Order();
            int validID = 1;

            //ACT
            order.OrderID = validID;

            //Assert
            Assert.NotNull(order.OrderID);
            Assert.Equal(validID, order.OrderID);


        }




    }



}