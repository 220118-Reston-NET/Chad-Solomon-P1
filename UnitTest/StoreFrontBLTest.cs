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
        [Fact]
        public void Should_Add_Customer()
        {
            StoreFront _expectedStore = new StoreFront()
            {
                StoreName = "Bebop",
                StoreAddress = "159 Bebop Avenue"
            };

            Mock<IStoreFrontRepo> _mockRepo = new Mock<IStoreFrontRepo>();

            _mockRepo.Setup(repo => repo.AddStoreFront(_expectedStore)).Returns(_expectedStore);

            IStoreFrontBL _storeBL = new StoreFrontBL(_mockRepo.Object);

            StoreFront _actualStore = _expectedStore;

            //Act
            _actualStore = _storeBL.AddStoreFront(_actualStore);

            //Assert
            Assert.Same(_expectedStore, _actualStore);
            Assert.Equal(_expectedStore.StoreName, _actualStore.StoreName);
            Assert.Equal(_expectedStore.StoreAddress, _actualStore.StoreAddress);
            Assert.NotNull(_actualStore);

        }

        [Fact]
        public void Should_Get_All_StoreFront()
        {
            //Arrange


            StoreFront _store = new StoreFront()
            {

                StoreID = 1,
                StoreName = "Bebop",
                StoreAddress = "456 Bebop Lane"
            };

            List<StoreFront> _expectedListStore = new List<StoreFront>();

            _expectedListStore.Add(_store);

            Mock<IStoreFrontRepo> _mockRepo = new Mock<IStoreFrontRepo>();

            _mockRepo.Setup(repo => repo.GetAllStoreFronts()).Returns(_expectedListStore);

            IStoreFrontBL _storeBL = new StoreFrontBL(_mockRepo.Object);

            List<StoreFront> _actualListOfCustomer = _storeBL.GetAllStoreFronts();

            //Assert
            Assert.Same(_expectedListStore, _actualListOfCustomer);
            Assert.Equal(_expectedListStore[0].StoreID, _actualListOfCustomer[0].StoreID);
            Assert.Equal(_expectedListStore[0].StoreName, _actualListOfCustomer[0].StoreName);
            Assert.Equal(_expectedListStore[0].StoreAddress, _actualListOfCustomer[0].StoreAddress);


        }
        [Fact]
        public void Should_Get_Store_Front_By_Id()
        {

            //Assert
            List<StoreFront> _listOfStoreFronts = new List<StoreFront>();

            StoreFront _Store = new StoreFront()
            {
                StoreID = 1,
                StoreName = "Bebop",
                StoreAddress = "123 Bebop Lane"
            };

            _listOfStoreFronts.Add(_Store);


            Mock<IStoreFrontRepo> _mockRepo = new Mock<IStoreFrontRepo>();

            _mockRepo.Setup(p => p.GetAllStoreFronts()).Returns(_listOfStoreFronts);

            IStoreFrontBL _storeBL = new StoreFrontBL(_mockRepo.Object);

            StoreFront _expectedStore = _Store;

            StoreFront _actualStore = new StoreFront();

            //Act
            _actualStore = _storeBL.SearchStoreFrontById(_Store.StoreID);

            //Assert
            Assert.Same(_expectedStore, _actualStore);
            Assert.Equal(_expectedStore.StoreID, _actualStore.StoreID);
            Assert.Equal(_expectedStore.StoreName, _actualStore.StoreName);
            Assert.Equal(_expectedStore.StoreAddress, _actualStore.StoreAddress);

        }
    }
}