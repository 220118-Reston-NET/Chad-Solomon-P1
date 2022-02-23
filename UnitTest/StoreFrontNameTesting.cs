using Xunit;
using PokeModel;

namespace UnitTest
{

    public class StoreFrontNameTesting
    {
        [Fact]
        public void SetValidStoreName()
        {
            //Arrange
            StoreFront store = new StoreFront();
            string validStoreName = "Swordfish";

            //ACT
            store.StoreName = validStoreName;

            //Assert
            Assert.NotNull(store.StoreName);
            Assert.Equal(validStoreName, store.StoreName);


        }




    }



}