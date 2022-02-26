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

            return listOfOrder.FindAll(o => o.TotalPrice.Equals(p_filter));
        }

        public async Task<List<Order>> GetAllOrder()
        {



            return await _orderRepo.GetAllOrder();
        }

    }
}