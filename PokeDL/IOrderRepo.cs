using PokeModel;

namespace PokeDL
{
    public interface IOrderRepo
    {

        public void AddOrder(int _orderLocation, int _price, int _custID, List<LineItems> _cart);

        public List<Order> GetAllOrder(int custID);

        // public List<Order> GetAllOrder();
    }
}