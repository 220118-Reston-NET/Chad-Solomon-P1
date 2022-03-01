using Xunit;
using PokeModel;

namespace UnitTest
{

    public class InventoryModelTesting
    {
        [Fact]


        public void SetValidStoreID()
        {

            //Arrange
            Inventory _inventory = new Inventory();
            int validStoreID = 1;

            //ACT
            _inventory.StoreID = validStoreID;

            //Assert
            Assert.NotNull(_inventory.StoreID);
            Assert.Equal(validStoreID, _inventory.StoreID);
        }

        [Fact]
        public void SetValidProductID()
        {
            //Arrange
            Inventory _inventory1 = new Inventory();
            int validProductID = 1;

            //Act
            _inventory1.ProductID = validProductID;

            //Assert
            Assert.NotNull(_inventory1.ProductID);
            Assert.Equal(validProductID, _inventory1.ProductID);
        }

        [Fact]
        public void SetValidProductQuantity()
        {
            //Arrange
            Inventory _inventory2 = new Inventory();
            int validQuantity = 1;

            //Act
            _inventory2.Quantity = validQuantity;

            //Assert
            Assert.NotNull(_inventory2.Quantity);
            Assert.Equal(validQuantity, _inventory2.Quantity);
        }


    }



}