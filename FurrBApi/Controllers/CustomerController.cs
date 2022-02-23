using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeBL;
using PokeModel;

namespace FurrBApi.Controllers
{

    //dotnet add package Microsoft.Extensions.Caching.Memory --version 6.0.1



    [Route("api/[controller]")] //this will signify that every controller in this api will be named api/nameofthecontroller
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private IPokemonBL _custBL;
        public CustomerController(IPokemonBL p_custBL)
        {

            _custBL = p_custBL;
        }

        //

        // GET: api/Customer
        [HttpGet("GetAllCustomers")] //the ("GetAllCustomers") is changing the endpoint of this method/action

        //The IActionResult needs to be there to return a response essentially sying whether the action/method was succesful.
        public IActionResult GetAllCustomer()
        {
            try
            {
                return Ok(_custBL.GetAllCustomer());
            }
            catch (SqlException)
            {
                //will return an appropriate status code:
                return NotFound();
            }
        }

        /*
            How would we get user input using this controller?
            > so we will use the {what you want for input} at the end of end point and it must
                match the parameter of the action. ***see below for***

            >We call this paramaterized Action (An action is essentially a method)
        */

        // GET: api/Customer/5
        [HttpGet("GetCustomerByID{id}")]
        public IActionResult SearchCustomer(int id)
        {
            try
            {

                return Ok(_custBL.SearchCustomer(id));
            }
            catch (System.Exception)
            {

                //will return an appropriate status code:
                return NotFound();
            }
        }

        /*
            [From Body] means that the action will look inside of the Http request body for information it needs. Similar to above where we are asking the user for an ID #.

            IF you need a bunch of information though like for when a customer might be creating an account, YOu would use this format B/C otherwise we would need to specifiy each element needed from the customer {elem}/{elem}/{elem}/ which would take a lot of time.
        */

        // POST: api/Customer
        [HttpPost("Add")] //Post sends data to the server. So here we are sending customer information to the server.
                          //we are obtaining the customer info via a form body.
        public IActionResult Post([FromBody] Customer p_cust)
        {

            try
            {
                return Ok(_custBL.AddCustomer(p_cust));
            }
            catch (System.Exception)
            {

                return Conflict();
            }
        }

        // PUT: api/Customer/5
        [HttpPut("updateby/{id}")] //PUT creates a new resource or replaces a representation of the target resource with 
                                   //the target payload.
        public IActionResult Put(int id, [FromBody] Customer p_cust)
        {
            p_cust._custID = id;

            try
            {
                return Ok(_custBL.UpdateCustomer(p_cust));
            }
            catch (System.Exception exc)
            {

                return Conflict(exc.Message);
            }

        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
