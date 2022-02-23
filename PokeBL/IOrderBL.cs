using PokeModel;
namespace PokeBL
{
    public interface IOrderBL
    {

        void AddOrder(int _orderLocation, int _price, int _custID, List<LineItems> _cart);

        //List<Order> GetAllOrder(int custID);

        List<Order> SearchOrder(int custID);
    }







}