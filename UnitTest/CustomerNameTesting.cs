using Xunit;
using PokeModel;

namespace UnitTest
{

    public class CustomerNameTesting
    {
        [Fact]
        public void SetValidName()
        {
            //Arrange
            Customer cust = new Customer();
            string validName = "Rhea";

            //ACT
            cust.Name = validName;

            //Assert
            Assert.NotNull(cust.Name);
            Assert.Equal(validName, cust.Name);


        }




    }



}