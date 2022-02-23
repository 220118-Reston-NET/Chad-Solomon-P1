using Xunit;
using PokeModel;

namespace UnitTest
{

    public class StoreFrontIDTesting
    {
        [Fact]
        public void SetValidStoreID()
        {
            //Arrange
            StoreFront store = new StoreFront();
            int validStoreID = 1;

            //ACT
            store._storeID = validStoreID;

            //Assert
            Assert.NotNull(store._storeID);
            Assert.Equal(validStoreID, store._storeID);


        }




    }



}