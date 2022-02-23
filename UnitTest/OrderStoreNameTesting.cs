using Xunit;
using PokeModel;

namespace UnitTest
{

    public class OrderStoreNameTesting
    {
        [Fact]
        public void SetValidStoreName()
        {
            //Arrange
            Order order = new Order();
            string validStoreName = "Bebop";

            //ACT
            order.StoreName = validStoreName;

            //Assert
            Assert.NotNull(order.StoreName);
            Assert.Equal(validStoreName, order.StoreName);


        }




    }



}