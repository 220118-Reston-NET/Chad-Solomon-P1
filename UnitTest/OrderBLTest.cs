using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using PokeBL;
using PokeDL;
using PokeModel;
using Xunit;

namespace OrderTest
{
    public class CustomerBLTest
    {
        [Fact]
        public async Task should_Get_All_Orders()
        {
            //Arrange
            int ID = 1;
            int orderLocation = 1;
            int orderPrice = 20;
            int customerID = 1;


            Order _order = new Order()
            {
                OrderID = ID,
                StoreID = orderLocation,
                TotalPrice = orderPrice,
                CustID = customerID


            };

            List<Order> _expectedListOfOrder = new List<Order>();

            _expectedListOfOrder.Add(_order);
            //We are mocking one of the required dependencies of CustomerBL which is Irepository
            Mock<IOrderRepo> _mockRepo = new Mock<IOrderRepo>();

            //We change that if our IRepository.GetAllCustomer() is called, it will always return our expectedListOfPoke
            // In thes way, we guaranteed that our dependency will always work so if something goes wrong it is the business layer's fault
            _mockRepo.Setup(repo => repo.GetAllOrder()).ReturnsAsync(_expectedListOfOrder);

            IOrderBL _orderBL = new OrderBL(_mockRepo.Object);

            //Act
            List<Order> _actualListOfOrder = await _orderBL.GetAllOrder();


            //Assert
            Assert.Same(_expectedListOfOrder, _actualListOfOrder);
            Assert.Equal(ID, _actualListOfOrder[0].OrderID);
            Assert.Equal(orderLocation, _actualListOfOrder[0].StoreID);
            Assert.Equal(orderPrice, _actualListOfOrder[0].TotalPrice);
            Assert.Equal(customerID, _actualListOfOrder[0].CustID);

        }

        public async Task Should_Get_All_Orders_By_Cust_ID()
        {

            //Arrange 
            List<Order> _listOfCustOrders = new List<Order>();

            Order _newOrder = new Order()
            {

                OrderID = 1,
                StoreID = 1,
                TotalPrice = 20,
                CustID = 1
            };

            _listOfCustOrders.Add(_newOrder);

            Mock<IOrderRepo> _mockRepo = new Mock<IOrderRepo>();
            _mockRepo.Setup(p => p.GetAllOrder()).ReturnsAsync(_listOfCustOrders);

            IOrderBL _orderBL = new OrderBL(_mockRepo.Object);

            List<Order> _expectedListOrder = new List<Order>();
            _expectedListOrder.Add(_newOrder);

            List<Order> _actualListOrder = new List<Order>();

            //Act
            _actualListOrder = await _orderBL.SearchOrder(_newOrder.CustID);

            //Assert
            Assert.Same(_expectedListOrder, _actualListOrder);
            Assert.Same(_expectedListOrder[0].OrderID, _actualListOrder[0].OrderID);
            Assert.Same(_expectedListOrder[1].StoreID, _actualListOrder[1].StoreID);
            Assert.Same(_expectedListOrder[2].TotalPrice, _actualListOrder[2].TotalPrice);
            Assert.Same(_expectedListOrder[3].CustID, _actualListOrder[3].CustID);

        }
    }
}