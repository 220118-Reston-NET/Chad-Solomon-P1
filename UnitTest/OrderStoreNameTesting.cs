using Xunit;
using PokeModel;
using System.Threading.Tasks;

namespace UnitTest
{

    public class OrderStoreNameTesting
    {
        [Fact]
        public async Task SetValidStoreName()
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