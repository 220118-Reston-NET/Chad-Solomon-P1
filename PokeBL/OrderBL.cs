using System.Linq;
using PokeDL;
using PokeModel;
namespace PokeBL
{
    public class OrderBL : IOrderBL
    {

        //Dependency Injection
        private IOrderRepo _orderRepo;
        public OrderBL(IOrderRepo c_orderRepo)
        {

            _orderRepo = c_orderRepo;
        }

        //public void AddOrder(Order _custID, Order _orderLocation, LineItem _cart)
        public void AddOrder(int _orderLocation, int _price, int _custID, List<LineItems> _cart)
        {
            _orderRepo.AddOrder(_orderLocation, _price, _custID, _cart);

        }

        public List<Order> SearchOrder(int custID)
        {

            List<Order> listOfOrder = _orderRepo.GetAllOrder(custID);

            return listOfOrder
                .Where(order => order.CustID == custID)
                .ToList();
        }

        public List<Order> SearchOrderFilter(int p_custID, string p_filter)
        {

            List<Order> listOfOrder = SearchOrder(p_custID);

            return listOfOrder.FindAll(o => o.TotalPrice.Equals(p_filter));
        }

        // public List<Order> GetAllOrder(int custID)
        // {

        //     List<Order> listOrders = new List<Order>();

        //     return listOrders;
        // }

    }
}