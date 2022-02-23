using PokeModel;

namespace PokeBL
{
    public interface IStoreHistory
    {
        public List<StoreOrder> SearchStoreHistory(int storeID);
    }
}