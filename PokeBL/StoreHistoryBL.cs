using PokeDL;
using PokeModel;

namespace PokeBL
{
    public class StoreHistoryBL : IStoreHistory
    {
        private ISQLStoreHistory _storehist;
        public StoreHistoryBL(ISQLStoreHistory s_storehsit)
        {

            _storehist = s_storehsit;
        }

        public List<StoreOrder> SearchStoreHistory(int storeID)
        {

            List<StoreOrder> listStoreOrder = _storehist.GetStoreOrder(storeID);

            return listStoreOrder
                .Where(order => order._storeID == storeID)
                .ToList();
        }




    }


}