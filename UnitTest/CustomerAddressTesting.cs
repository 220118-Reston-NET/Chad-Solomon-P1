using Xunit;
using PokeModel;

namespace UnitTest
{

    public class CustomerAddressTesting
    {
        [Fact]


        public void SetValidAddress()
        {

            //Arrange
            Customer cust1 = new Customer();
            string validAddress = "123 Sleepy Dog Hollow";

            //ACT
            cust1.Address = validAddress;

            //Assert
            Assert.NotNull(cust1.Address);
            Assert.Equal(validAddress, cust1.Address);
        }


    }



}