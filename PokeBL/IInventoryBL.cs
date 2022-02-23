using PokeModel;
namespace PokeBL
{
    public interface IInventoryBL
    {

        public void AddInventory(int _productID);

        public List<Inventory> SearchInventory(int p_id);

        List<Inventory> GetAllInventoryByStoreID(int storeID);

        List<Inventory> GetAllInventory();
    }







}