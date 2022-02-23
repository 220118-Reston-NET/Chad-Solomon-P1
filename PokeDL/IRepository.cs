using PokeModel;
namespace PokeDL
{

    /*


    */
    public interface IRepository
    {
        Customer AddCustomer(Customer c_name);


        List<Customer> GetAllCustomers();

        Customer UpdateCustomer(Customer p_cust);





    }
}
