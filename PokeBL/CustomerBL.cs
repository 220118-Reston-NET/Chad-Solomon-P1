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

        /// <summary>
        /// 
        /// </summary>


        private IRepository _repo;
        public CustomerBL(IRepository c_repo)
        {
            _repo = c_repo;
        }

        //=========================

        public async Task<Customer> AddCustomer(Customer c_customer)
        {
            return await _repo.AddCustomer(c_customer);

        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            return await _repo.GetAllCustomers();
        }

        public async Task<Customer> SearchCustomer(int c_id)
        {
            List<Customer> listOfCustomers = await _repo.GetAllCustomers();

            //LINQ Library
            //.Where() filters a sequence of values based on a predicate
            //.ToList used with .Where or other methods from the IEnumerable class to place the out from the IEnumerable into a list.
            return listOfCustomers.Find(o => o.CustID.Equals(c_id));
            // .Where(p => p.CustID.Equals(c_id)).ToList();




        }


        public async Task<Customer> UpdateCustomer(Customer p_cust)
        {
            return await _repo.UpdateCustomer(p_cust);

        }

        public async Task<List<Customer>> VerifyCustomer(string p_email, string p_password)
        {

            List<Customer> listOfCust = await _repo.GetAllCustomers();


            return listOfCust
                .Where(c => c.Email.Equals(p_email) && c.Password.Equals(p_password))
                .ToList();



        }


    }
}