using PokeModel;

namespace PokeBL
{
    public interface IOrderHistoryBL
    {
        // public Customer AddCustomer(Customer c_name);

        public List<Order> SearchOrderHist(int custID);

        // public List<Order> SearchCustomer(string s_name);
    }

}