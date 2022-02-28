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
        public async Task should_Get_All_Customer()
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
    }
}