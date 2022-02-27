using PokeModel;
namespace PokeDL
{

    /*


    */
    public interface IRepository
    {
        Task<Customer> AddCustomer(Customer c_name);


        Task<List<Customer>> GetAllCustomers();

        Task<Customer> UpdateCustomer(Customer p_cust);





    }
}
