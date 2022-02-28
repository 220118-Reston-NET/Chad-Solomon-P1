using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using PokeBL;
using PokeDL;
using PokeModel;
using Xunit;

namespace InventoryTest
{
    public class InventoryTest
    {
        public void Should_Get_All_Inventory()
        {
            //Arrange
            int storeForntID = 1;
            int productID = 1;
            int productQuantity = 1;

            Inventory _inventory = new Inventory()
            {

                StoreID = storeForntID,
                ProductID = productID,
                Quantity = productQuantity

            };

            List<Inventory> _expectedListInventory = new List<Inventory>();

            _expectedListInventory.Add(_inventory);

            Mock<IInventoryRepo> _mockRepo = new Mock<IInventoryRepo>();

            _mockRepo.Setup(repo => repo.GetAllInventory()).Returns(_expectedListInventory);

            IInventoryBL _prodBL = new InventoryBL(_mockRepo.Object);

            List<Inventory> _actualListOfInventory = _prodBL.GetAllInventory();

            //Assert
            Assert.Same(_expectedListInventory, _actualListOfInventory);
            Assert.Equal(storeForntID, _actualListOfInventory[0].StoreID);
            Assert.Equal(productID, _actualListOfInventory[0].ProductID);
            Assert.Equal(productQuantity, _actualListOfInventory[0].Quantity);


        }
    }
}