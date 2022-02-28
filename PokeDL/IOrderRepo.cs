using PokeModel;

namespace PokeDL
{
    public interface IOrderRepo
    {

        void AddOrder(int _orderLocation, int _custID, List<LineItems> _cart);

        Task<List<Order>> GetAllOrder();
        Task<List<Order>> GetStoreOrder();

        // List<Order> SearchOrder(int custID);

        // public List<Order> GetAllOrder();
        List<LineItems> GetShoppingCartByOrderID(int p_orderID);
    }
}