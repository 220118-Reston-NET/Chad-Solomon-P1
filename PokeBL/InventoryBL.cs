using PokeModel;
using PokeDL;

namespace PokeBL
{
    public class InventoryBL : IInventoryBL
    {

        private IInventoryRepo _irepo;
        public InventoryBL(IInventoryRepo s_inv)
        {

            _irepo = s_inv;
        }

        public void AddInventory(int _productID)
        {

            _irepo.AddInventory(_productID);
        }

        public List<Inventory> GetAllInventory()
        {

            return _irepo.GetAllInventory();
        }

        public List<Inventory> GetAllInventoryByStoreID(int storeID)
        {
            return GetAllInventory().FindAll(p => p.StoreID == storeID);
        }

        // public List<Inventory> GetAllInventory()
        // {

        //     List<Inventory> listOfInventory = new List<Inventory>();

        //     return listOfInventory;
        // }


        public List<Inventory> SearchInventory(int p_id)
        {

            List<Inventory> _inventory = _irepo.GetAllInventory();

            return _inventory
                .Where(store => store.ProductID == p_id)
                .ToList();
        }

    }
}