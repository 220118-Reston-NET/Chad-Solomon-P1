using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using PokeBL;
using PokeDL;
using PokeModel;
using Xunit;

namespace CustomerTest
{
    public class CustomerBLTest
    {
        [Fact]
        public async Task should_Get_All_Customer()
        {
            //Arrange
            int customerID = 1;
            string custName = "Rhea";
            string custAddress = "123 Fetch Alot Lane";
            string custEmail = "rhea@dogmail.com";
            string custpassword = "FetchOne";
            Customer cust = new Customer()
            {

                CustID = customerID,
                Name = custName,
                Address = custAddress,
                Email = custEmail,
                Password = custpassword

            };

            List<Customer> expectedListOfCustomer = new List<Customer>();

            expectedListOfCustomer.Add(cust);
            //We are mocking one of the required dependencies of CustomerBL which is Irepository
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            //We change that if our IRepository.GetAllCustomer() is called, it will always return our expectedListOfPoke
            // In thes way, we guaranteed that our dependency will always work so if something goes wrong it is the business layer's fault
            mockRepo.Setup(repo => repo.GetAllCustomers()).ReturnsAsync(expectedListOfCustomer);

            IPokemonBL _custBL = new CustomerBL(mockRepo.Object);

            //Act
            List<Customer> actualListOfCustomer = await _custBL.GetAllCustomer();


            //Assert
            Assert.Same(expectedListOfCustomer, actualListOfCustomer);
            Assert.Equal(customerID, actualListOfCustomer[0].CustID);
            Assert.Equal(custName, actualListOfCustomer[0].Name);
            Assert.Equal(custAddress, actualListOfCustomer[0].Address);
            Assert.Equal(custEmail, actualListOfCustomer[0].Email);
            Assert.Equal(custpassword, actualListOfCustomer[0].Password);
        }


        [Fact]
        public async Task Should_Search_Customer_By_ID()
        {
            List<Customer> _listOfCustomers = new List<Customer>();


            //Arrange
            // int customerID = 1;
            // string custName = "Rhea";
            // string custAddress = "123 Fetch Alot Lane";
            // string custEmail = "rhea@dogmail.com";
            // string custpassword = "FetchOne";

            // int customer2ID = 2;
            // string cust2Name = "Ldog";
            // string cust2Address = "123 Nap Alot Lane";
            // string cust2Email = "ldog@dogmail.com";
            // string cust2password = "NapOne";



            Customer _cust = new Customer()
            {

                CustID = 1,
                Name = "Rhea",
                Address = "123 Fetch Alot Lane",
                Email = "rhea@dogmail.com",
                Password = "FetchOne"
            };

            // Customer _cust2 = new Customer()
            // {

            //     CustID = customerID,
            //     Name = custName,
            //     Address = custAddress,
            //     Email = custEmail,
            //     Password = custpassword
            // };
            _listOfCustomers.Add(_cust);



            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(p => p.GetAllCustomers()).ReturnsAsync(_listOfCustomers);

            IPokemonBL _custBL = new CustomerBL(mockRepo.Object);

            Customer _expectedCust = _cust;

            Customer _actualCustomer = new Customer();

            //Act
            _actualCustomer = await _custBL.SearchCustomer(_cust.CustID);

            //Assert
            Assert.Same(_expectedCust, _actualCustomer);
            Assert.Equal(_expectedCust.CustID, _actualCustomer.CustID);
            Assert.Equal(_expectedCust.Name, _actualCustomer.Name);
            Assert.Equal(_expectedCust.Address, _actualCustomer.Address);
            Assert.Equal(_expectedCust.Email, _actualCustomer.Email);
            Assert.Equal(_expectedCust.Password, _actualCustomer.Password);
        }

        // public async Task Should_update_Customer()
        // {

        // }
    }

}