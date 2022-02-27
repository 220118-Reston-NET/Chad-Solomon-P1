using PokeModel;

namespace PokeDL
{
    public interface IOrderRepo
    {

        public void AddOrder(int _orderLocation, int _custID, List<LineItems> _cart);

        public Task<List<Order>> GetAllOrder();

        // List<Order> SearchOrder(int custID);

        // public List<Order> GetAllOrder();
        List<LineItems> GetShoppingCartByOrderID(int p_orderID);
    }
}