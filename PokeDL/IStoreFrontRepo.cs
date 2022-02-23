using PokeModel;
namespace PokeDL
{

    /*


    */
    public interface IStoreFrontRepo
    {
        public StoreFront AddStoreFront(StoreFront s_name);


        public List<StoreFront> GetAllStoreFronts();




    }
}