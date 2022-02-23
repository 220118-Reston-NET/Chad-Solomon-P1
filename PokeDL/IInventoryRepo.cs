using PokeModel;
namespace PokeDL
{
    public interface IInventoryRepo
    {
        public void AddInventory(int _productID);
        public List<Inventory> GetAllInventory();

    }


}