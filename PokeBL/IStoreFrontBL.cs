using PokeModel;
namespace PokeBL
{
    public interface IStoreFrontBL
    {
        StoreFront AddStoreFront(StoreFront c_StoreFront);

        Inventory AddInventory(Inventory _productID);

        List<StoreFront> SearchStoreFront(string c_StoreFront);
        StoreFront SearchStoreFrontById(int storeID);

        List<StoreFront> GetAllStoreFronts();

        List<Manager> GetAllManagers();

        Manager GetManagerById(int _id);


    }
}