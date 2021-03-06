using System.Linq;
using PokeDL;
using PokeModel;
namespace PokeBL
{
    public class OrderBL : IOrderBL
    {

        //Dependency Injection
        private readonly IOrderRepo _orderRepo;
        public OrderBL(IOrderRepo c_orderRepo)
        {

            _orderRepo = c_orderRepo;

        }

        //public void AddOrder(Order _custID, Order _orderLocation, LineItem _cart)
        public void AddOrder(int _orderLocation, int _custID, List<LineItems> _cart)
        {
            _orderRepo.AddOrder(_orderLocation, _custID, _cart);

        }

        public async Task<List<Order>> SearchOrder(int custID)
        {

            List<Order> listOfOrder = await GetAllOrder();

            return listOfOrder.FindAll(o => o.CustID.Equals(custID));
            // .Where(order => order.CustID == custID)
            // .ToList();
        }

        public async Task<List<Order>> SearchOrderFilter(int p_custID, string p_filter)
        {
            //OrderBL order = new OrderBL();
            List<Order> listOfOrder = await SearchOrder(p_custID);

            if (p_filter.Equals("TotalPrice"))
            {
                return listOfOrder.OrderBy(p => p.TotalPrice).ToList();
            }
            else if (p_filter.Equals("TimeStamp"))
            {
                return listOfOrder.OrderBy(p => p.TimeStamp).ToList();
            }
            return listOfOrder;

        }

        public async Task<List<Order>> GetAllOrder()
        {



            return await _orderRepo.GetAllOrder();
        }

        // public async Task<List<Order>> GetStoreOrder()
        // {



        //     return await _orderRepo.GetStoreOrder();
        // }

        public async Task<List<Order>> SearchStoreOrder(int _storeID)
        {
            List<Order> _listStoreOrder = await GetAllOrder();

            return _listStoreOrder.FindAll(o => o.StoreID.Equals(_storeID));
        }

        public async Task<List<Order>> SearchStoreOrderHistFilter(int p_storeID, string p_filter)
        {
            List<Order> _listStoreOrder = await SearchStoreOrder(p_storeID);

            if (p_filter.Equals("TotalPrice"))
            {
                return _listStoreOrder.OrderBy(p => p.TotalPrice).ToList();
            }
            else if (p_filter.Equals("TimeStamp"))
            {
                return _listStoreOrder.OrderBy(p => p.TimeStamp).ToList();
            }


            return _listStoreOrder;
        }
    }
}