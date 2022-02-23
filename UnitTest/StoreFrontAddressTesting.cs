using Xunit;
using PokeModel;

namespace UnitTest
{

    public class StoreFrontAddressTesting
    {
        [Fact]
        public void SetValidStoreAddress()
        {
            //Arrange
            StoreFront store = new StoreFront();
            string validAddress = "123 Swordfish Lane Texas, TX";

            //ACT
            store.StoreAddress = validAddress;

            //Assert
            Assert.NotNull(store.StoreAddress);
            Assert.Equal(validAddress, store.StoreAddress);


        }




    }



}