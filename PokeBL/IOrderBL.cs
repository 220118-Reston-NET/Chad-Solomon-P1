using PokeModel;
namespace PokeBL
{
    public interface IOrderBL
    {

        void AddOrder(int _orderLocation, int _price, int _custID, List<LineItems> _cart);

        //List<Order> GetAllOrder(int custID);

        Task<List<Order>> SearchOrder(int custID);

        Task<List<Order>> SearchOrderFilter(int p_custID, string p_filter);
    }







}