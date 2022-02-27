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

            IPokemonBL custBL = new CustomerBL(mockRepo.Object);

            //Act
            List<Customer> actualListOfCustomer = await custBL.GetAllCustomer();


            //Assert
            Assert.Same(expectedListOfCustomer, actualListOfCustomer);
            Assert.Equal(customerID, actualListOfCustomer[0].CustID);
            Assert.Equal(custName, actualListOfCustomer[0].Name);
            Assert.Equal(custAddress, actualListOfCustomer[0].Address);
            Assert.Equal(custEmail, actualListOfCustomer[0].Email);
            Assert.Equal(custpassword, actualListOfCustomer[0].Password);
        }


        [Fact]
        public void Should_Add_Customer()
        {

            //Arrange
            int customerID = 1;
            string custName = "Rhea";
            string custAddress = "123 Fetch Alot Lane";
            string custEmail = "rhea@dogmail.com";
            string custpassword = "FetchOne";



            Customer expectedCust = new Customer()
            {

                CustID = customerID,
                Name = custName,
                Address = custAddress,
                Email = custEmail,
                Password = custpassword
            };

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(p => p.AddCustomer(expectedCust)).ReturnsAsync(expectedCust);

            IPokemonBL custBL = new CustomerBL(mockRepo.Object);

            Customer actualCustomer = new Customer();

            //Act
            actualCustomer = custBL.AddCustomer(actualCustomer);

            //Assert
            Assert.Same(expectedCust, actualCustomer);
            Assert.Equal(customerID, actualCustomer.CustID);
            Assert.Equal(custName, actualCustomer.Name);
            Assert.Equal(custAddress, actualCustomer.Address);
            Assert.Equal(custEmail, actualCustomer.Email);
            Assert.Equal(custpassword, actualCustomer.Password);
        }
    }

}