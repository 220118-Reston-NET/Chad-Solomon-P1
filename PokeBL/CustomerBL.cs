using PokeModel;
using PokeDL;
namespace PokeBL
{
    /*
    The Business layer will essentially return your added custoemr i think.
    Also, we could add the function of assigning a random ID to the customer or the customers order or the products
    */
    public class CustomerBL : IPokemonBL
    {
        //Dependency Injection Pattern
        //- This is the main reason why we created interface first before the class
        //- This will save you time on re-writting code that breaks if you updated a completely separate class
        //- Main reason is to prevent us from re-writting code that already existed on (potentailly) 50 files or more without
        //the compiler helping us
        //===========================


        private IRepository _repo;
        public CustomerBL(IRepository c_repo)
        {
            _repo = c_repo;
        }

        //=========================

        public Customer AddCustomer(Customer c_customer)
        {
            return _repo.AddCustomer(c_customer);

        }

        public List<Customer> GetAllCustomer()
        {
            return _repo.GetAllCustomers();
        }

        public List<Customer> SearchCustomer(int c_id)
        {
            List<Customer> listOfCustomers = _repo.GetAllCustomers();

            //LINQ Library
            //.Where() filters a sequence of values based on a predicate
            //.ToList used with .Where or other methods from the IEnumerable class to place the out from the IEnumerable into a list.
            return listOfCustomers
                    .Where(cust => cust._custID == c_id)
                    .ToList();


        }


        public Customer UpdateCustomer(Customer p_cust)
        {
            return _repo.UpdateCustomer(p_cust);

        }
    }
}