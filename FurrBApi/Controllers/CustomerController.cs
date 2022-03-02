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
        private IOrderBL _orderBL;
        private readonly IStoreFrontBL _storeBL;
        private readonly IProductBL _prodBL;
        private readonly IInventoryBL _invBL;
        public CustomerController(IPokemonBL p_custBL, IOrderBL p_orderBL, IStoreFrontBL storeBL, IProductBL prodBL, IInventoryBL invBL)
        {

            _custBL = p_custBL;
            _orderBL = p_orderBL;
            _storeBL = storeBL;
            _prodBL = prodBL;
            _invBL = invBL;
        }


        /// // GET: api/Customer
        [HttpGet("GetAllCustomers")] //the ("GetAllCustomers") is changing the endpoint of this method/action

        //The IActionResult needs to be there to return a response essentially sying whether the action/method was succesful.

        /// <summary>
        /// Gets All Customers
        /// </summary>
        /// <returns>List of Customers</returns>
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                Log.Information("Getting all customers");
                return Ok(await _custBL.GetAllCustomer());
            }
            catch (SqlException)
            {
                //will return an appropriate status code:
                Log.Warning("error occurred in getting customer info");
                return NotFound();
            }
        }

        /*
            How would we get user input using this controller?
            > so we will use the {what you want for input} at the end of end point and it must
                match the parameter of the action. ***see below for***

            >We call this paramaterized Action (An action is essentially a method)
        */


        /// <summary>
        /// Gets All Customers by Customer ID
        /// </summary>
        /// <returns>JSON SIngle Customer</returns>

        // GET: api/Customer/5
        [HttpGet("GetCustomerByID")]
        public async Task<IActionResult> SearchCustomer([FromQuery] int id)
        {
            try
            {
                Log.Information("Retrieve Customer info Based on ID");
                return Ok(await _custBL.SearchCustomer(id));
            }
            catch (System.Exception)
            {

                //will return an appropriate status code:
                Log.Warning("Error in retrieving Customer inof by id");
                return NotFound();
            }
        }

        /// <summary>
        /// Verifies Customer Information by Email and password in Database
        /// </summary>
        /// <param name="p_email"></param>
        /// <param name="p_password"></param>
        /// <returns>Returns JSON of Customer whos info was entered</returns>

        [HttpGet("VerifyCustomer")]
        public async Task<IActionResult> VerifyCustomer([FromQuery] string p_email, string p_password)
        {
            try
            {
                Log.Information("Customer info was varified");
                return Ok(await _custBL.VerifyCustomer(p_email, p_password));
            }
            catch (System.Exception)
            {

                //will return an appropriate status code:
                Log.Warning("Error in Customer Verification");
                return NotFound();
            }
        }

        /// <summary>
        /// Searches Customer's Order History       
        /// </summary>
        /// <param name="custID"></param>
        /// <returns>A List of Customer Order From database</returns>

        [HttpGet("CustomerOrderHistory")]
        public async Task<IActionResult> SearchOrder([FromQuery] int custID)
        {
            try
            {
                Log.Information("Successfully Retrieve Customer's orders");
                return Ok(await _orderBL.SearchOrder(custID));
            }
            catch (System.Exception e)
            {

                //will return an appropriate status code:
                Log.Warning("error in retrieving customer orders");
                return NotFound(new { Result = e.Message });
            }
        }

        /// <summary>
        /// Filters Customer order search by Order pRice or date of order
        /// </summary>
        /// <param name="p_custID"></param>
        /// <param name="p_filter"></param>
        /// <returns>List Of Customer Orders in ascending order</returns>

        [HttpGet("CustomerOrderHistoryFilter")]
        public async Task<IActionResult> SearchOrderFilter([FromQuery] int p_custID, string p_filter)
        {
            try
            {
                Log.Information("Successfully retrieved Custoemr Order History");
                return Ok(await _orderBL.SearchOrderFilter(p_custID, p_filter));
            }
            catch (System.Exception)
            {

                //will return an appropriate status code:
                Log.Information("Error in retrieving Customers order history");
                return NotFound();
            }
        }

        /// <summary>
        /// Displays the details of the order
        /// </summary>
        /// <param name="p_orderID"></param>
        /// <returns>Order Details Based on order ID</returns>

        [HttpGet("OrderDetails")]
        public async Task<IActionResult> GetOrderDetailByOrderID([FromQuery] int p_orderID)
        {

            List<Order> _listOfOrder = await _orderBL.GetAllOrder();
            Order _order = _listOfOrder.Find(p => p.OrderID.Equals(p_orderID));

            if (_order != null)
            {
                OrderDetails _orderDetails = new OrderDetails();

                List<Customer> _listOfCust = await _custBL.GetAllCustomer();

                List<StoreFront> _listOfStore = _storeBL.GetAllStoreFronts();



                _orderDetails.OrderID = p_orderID;
                _orderDetails.CustName = _listOfCust.Find(p => p.CustID.Equals(_order.CustID)).Name;
                _orderDetails.StoreName = _listOfStore.Find(p => p.StoreID.Equals(_order.StoreID)).StoreName;
                foreach (var item in _order.ShoppingCart)
                {
                    _orderDetails.ShoppingCart.Add(new ProductDetails()
                    {

                        ProductName = _prodBL.GetProductByID(item.Product).Name,
                        ProductPrice = _prodBL.GetProductByID(item.Product).Price,
                        Quantity = item.Quantity

                    });
                }
                _orderDetails.TotalPrice = _order.TotalPrice;
                _orderDetails.OrderTime = _order.TimeStamp;
                Log.Information("Order details retrieved");
                return Ok(_orderDetails);


            }
            Log.Information("Order was not found");
            return NotFound(new { Result = "Order not found" });

        }

        /*
            [From Body] means that the action will look inside of the Http request body for information it needs. Similar to above where we are asking the user for an ID #.

            IF you need a bunch of information though like for when a customer might be creating an account, YOu would use this format B/C otherwise we would need to specifiy each element needed from the customer {elem}/{elem}/{elem}/ which would take a lot of time.
        */

        /// <summary>
        /// Adds a customer to the customer table in the database
        /// </summary>
        /// <returns>Customer info that will be in database</returns>

        // POST: api/Customer
        [HttpPost("AddCustomer")] //Post sends data to the server. So here we are sending customer information to the server.
                                  //we are obtaining the customer info via a form body.
        public async Task<IActionResult> Post([FromQuery] Customer p_cust)
        {

            try
            {
                Log.Information("Successfully added Customer");
                return Ok(await _custBL.AddCustomer(p_cust));
            }
            catch (System.Exception)
            {
                Log.Information("Error in adding Customer");
                return Conflict();
            }
        }


        /// <summary>
        /// Places and order to the order table in the database
        /// </summary>
        /// <param name="_orderLocation"></param>
        /// <param name="_custID"></param>
        /// <param name="_cart"></param>
        /// <returns>Returns whether order was placed successfully</returns>

        [HttpPost("PlaceOrder")]

        public IActionResult Post([FromQuery] int _orderLocation, int _custID, List<LineItems> _cart)
        {
            List<Inventory> _listOfInventory = new List<Inventory>();
            Inventory _inventory = new Inventory();

            _listOfInventory = _invBL.GetAllInventoryByStoreID(_orderLocation);
            //_listOfInventory.Find(p => p.ProductID == _cart[0].Product).Quantity < _cart[0].Quantity

            if (_listOfInventory.Find(p => p.ProductID == _cart[0].Product).Quantity < _cart[0].Quantity)
            {

                return NotFound();
            }




            try
            {
                Log.Information("Order was successful");
                _orderBL.AddOrder(_orderLocation, _custID, _cart);
                return Ok(new { Result = "Place order Successful" });
            }
            catch (System.Exception)
            {
                Log.Information("Error in placing order");
                return Conflict();
            }
        }



        /// <summary>
        /// Updates Customer info in database
        /// </summary>
        /// <returns>Returns updated info</returns> 
        // PUT: api/Customer/5
        [HttpPut("UpdateCustomer")] //PUT creates a new resource or replaces a representation of the target resource with 
                                    //the target payload.
        public async Task<IActionResult> Put([FromQuery] Customer p_cust)
        {


            try
            {
                Log.Information("Customer info was updated");
                return Ok(await _custBL.UpdateCustomer(p_cust));
            }
            catch (System.Exception exc)
            {
                Log.Information("Error in updating Customer Info");
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
