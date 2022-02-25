﻿using PokeModel;

namespace PokeBL
{
    public interface IPokemonBL
    {
        Customer AddCustomer(Customer c_name);

        List<Customer> SearchCustomer(int c_id);

        List<Customer> GetAllCustomer();
        Customer UpdateCustomer(Customer p_cust);
        List<Customer> VerifyCustomer(string p_email, string p_password);
    }

}
