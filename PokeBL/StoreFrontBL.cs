using PokeModel;
using PokeDL;
namespace PokeBL
{
    /*
    The Business layer will essentially return your added custoemr i think.
    Also, we could add the function of assigning a random ID to the StoreFront or the StoreFronts order or the products
    */
    public class StoreFrontBL : IStoreFrontBL  //SQLStoreFrontRepo
    {
        //Dependency Injection Pattern
        //- This is the main reason why we created interface first before the class
        //- This will save you time on re-writting code that breaks if you updated a completely separate class
        //- Main reason is to prevent us from re-writting code that already existed on (potentailly) 50 files or more without
        //the compiler helping us
        //===========================


        private IStoreFrontRepo _srepo;


        public StoreFrontBL(IStoreFrontRepo s_repo)
        {
            _srepo = s_repo;

        }

        //=========================

        public StoreFront AddStoreFront(StoreFront s_name)
        {
            return _srepo.AddStoreFront(s_name);

        }

        public List<StoreFront> SearchStoreFrontById(int storeID)
        {

            List<StoreFront> listOfStoreFront = _srepo.GetAllStoreFronts();

            return listOfStoreFront
                .Where(store => store._storeID == storeID)
                .ToList();
        }

        public List<StoreFront> SearchStoreFront(string s_name)
        {
            List<StoreFront> listOfStoreFronts = _srepo.GetAllStoreFronts();

            //LINQ Library
            //.Where() filters a sequence of values based on a predicate
            //.ToList used with .Where or other methods from the IEnumerable class to place the out from the IEnumerable into a list.
            return listOfStoreFronts
                    .Where(store => store.StoreName.Contains(s_name))
                    .ToList();


        }

        public List<StoreFront> GetAllStoreFronts()
        {
            List<StoreFront> listOfStoreFronts = new List<StoreFront>();

            return _srepo.GetAllStoreFronts();
        }
    }
}