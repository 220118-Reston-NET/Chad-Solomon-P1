using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using PokeBL;
using PokeDL;
using PokeModel;
using Xunit;

namespace StoreFrontTest
{
    public class StoreFrontTest
    {
        public void Should_Get_All_StoreFront()
        {
            //Arrange
            int storeFrontID = 1;
            string storeFrontName = "Bebop";
            string storeFrontAddress = "456 place street";

            StoreFront _store = new StoreFront()
            {

                StoreID = storeFrontID,
                StoreName = storeFrontAddress,
                StoreAddress = storeFrontAddress
            };

            List<StoreFront> _expectedListStore = new List<StoreFront>();

            _expectedListStore.Add(_store);

            Mock<IStoreFrontRepo> _mockRepo = new Mock<IStoreFrontRepo>();

            _mockRepo.Setup(repo => repo.GetAllStoreFronts()).Returns(_expectedListStore);

            IStoreFrontBL _storeBL = new StoreFrontBL(_mockRepo.Object);

            List<StoreFront> _actualListOfCustomer = _storeBL.GetAllStoreFronts();

            //Assert
            Assert.Same(_expectedListStore, _actualListOfCustomer);
            Assert.Equal(storeFrontID, _actualListOfCustomer[0].StoreID);
            Assert.Equal(storeFrontName, _actualListOfCustomer[0].StoreName);
            Assert.Equal(storeFrontAddress, _actualListOfCustomer[0].StoreAddress);


        }
    }
}