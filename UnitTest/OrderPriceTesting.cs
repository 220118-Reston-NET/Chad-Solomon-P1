using Xunit;
using PokeModel;

namespace UnitTest
{

    public class OrderPriceTesting
    {
        [Fact]
        public void SetValidPrice()
        {
            //Arrange
            Order order = new Order();
            int validPrice = 10;

            //ACT
            order.TotalPrice = validPrice;

            //Assert
            Assert.NotNull(order.TotalPrice);
            Assert.Equal(validPrice, order.TotalPrice);


        }




    }



}