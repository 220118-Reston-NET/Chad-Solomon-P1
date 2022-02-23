using PokeModel;
namespace PokeBL
{
    public interface IStoreFrontBL
    {
        public StoreFront AddStoreFront(StoreFront c_StoreFront);

        public List<StoreFront> SearchStoreFront(string c_StoreFront);
        public List<StoreFront> SearchStoreFrontById(int storeID);

        public List<StoreFront> GetAllStoreFronts();


    }
}