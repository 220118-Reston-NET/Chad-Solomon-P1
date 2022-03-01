using PokeModel;
namespace PokeDL
{

    /*


    */
    public interface IStoreFrontRepo
    {
        public StoreFront AddStoreFront(StoreFront s_name);
        public Inventory AddInventory(Inventory _productID);


        public List<StoreFront> GetAllStoreFronts();
        public List<Manager> GetAllManagers();




    }
}