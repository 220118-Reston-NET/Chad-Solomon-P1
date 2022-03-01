using PokeModel;
namespace PokeDL
{

    /*


    */
    public interface IStoreFrontRepo
    {
        public StoreFront AddStoreFront(StoreFront s_name);
        public Inventory AddInventory(Inventory _inv, string _email, string _managerPassword);

        // bool IsManager(string _email, string _password);


        public List<StoreFront> GetAllStoreFronts();
        public List<Manager> GetAllManagers();




    }
}