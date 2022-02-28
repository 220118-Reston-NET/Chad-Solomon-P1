using PokeModel;

namespace PokeBL
{
    public interface IPokemonBL
    {
        Task<Customer> AddCustomer(Customer c_name);

        Task<Customer> SearchCustomer(int c_id);

        Task<List<Customer>> GetAllCustomer();
        Task<Customer> UpdateCustomer(Customer p_cust);
        Task<List<Customer>> VerifyCustomer(string p_email, string p_password);
    }

}
