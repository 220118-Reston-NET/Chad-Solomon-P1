using Xunit;
using PokeModel;
namespace UnitTest
{
    public class LineItemsModelTesting
    {

        [Fact]
        public void SetValidStoreID()
        {
            //Arrange
            LineItems _line = new LineItems();
            int validStoreID = 1;

            //Act
            _line.StoreID = validStoreID;

            //Assert
            Assert.NotNull(_line.StoreID);
            Assert.Equal(validStoreID, _line.StoreID);
        }

        [Fact]
        public void SetValidProductID()
        {
            //Arrange
            LineItems _line1 = new LineItems();
            int validProductID = 1;

            //Act
            _line1.Product = validProductID;

            //Assert
            Assert.NotNull(_line1.Product);
            Assert.Equal(validProductID, _line1.Product);
        }

        [Fact]
        public void SetValidQuantity()
        {
            //Arrange
            LineItems _line2 = new LineItems();
            int validQuantity = 1;

            //Act
            _line2.Quantity = validQuantity;

            //Assert
            Assert.NotNull(_line2.Quantity);
            Assert.Equal(validQuantity, _line2.Quantity);
        }
    }

}