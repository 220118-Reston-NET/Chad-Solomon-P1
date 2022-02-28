using PokeModel;
namespace PokeBL
{
    public interface IOrderBL
    {

        void AddOrder(int _orderLocation, int _custID, List<LineItems> _cart);

        Task<List<Order>> GetAllOrder();

        Task<List<Order>> SearchOrder(int custID);

        // Task<List<Order>> GetStoreOrder();
        Task<List<Order>> SearchStoreOrder(int _storeID);
        Task<List<Order>> SearchStoreOrderHistFilter(int p_storeID, string p_filter);

        Task<List<Order>> SearchOrderFilter(int p_custID, string p_filter);


    }







}