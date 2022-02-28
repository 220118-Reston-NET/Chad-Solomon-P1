// using PokeDL;
// using PokeModel;

// namespace PokeBL
// {


//     public class OrderHistoryBL : IOrderHistoryBL
//     {

//         private IOrderHistRepo _orderrepo;
//         public OrderHistoryBL(IOrderHistRepo o_orderrepo)
//         {

//             _orderrepo = o_orderrepo;
//         }


//         public async Task<List<Order>> SearchOrderHist(int storeID)
//         {

//             List<Order> listOfOrders = await _orderrepo.GetStoreOrder();

//             return listOfOrders
//                 .Where(order => order.StoreID == storeID)
//                 .ToList();


//         }

//         public async Task<List<Order>> SearchStoreOrderHistFilter(int p_storeID, string p_filter)
//         {
//             List<Order> _listStoreOrder = await SearchOrderHist(p_storeID);

//             if (p_filter.Equals("TotalPrice"))
//             {

//                 _listStoreOrder.OrderBy(o => o.TotalPrice.Equals(p_filter)).ToList();
//             }
//             else if (p_filter.Equals("TimeStamp"))
//             {

//                 _listStoreOrder.OrderBy(o => o.TimeStamp.Equals(p_filter)).ToList();
//             }


//             return _listStoreOrder;
//         }

//         // public List<Order> SearchCustomer(StoreFront s_name)
//         // {

//         //     List<Order> listOfOrders = _orderrepo.GetAllOrders();

//         //     return listOfOrders
//         //         .Where(order => order._storeName.Contains(s_name))
//         //         .ToList();


//         // }
//     }

// }