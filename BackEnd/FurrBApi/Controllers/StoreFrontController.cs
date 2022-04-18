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
    [Route("api/[controller]")]
    [ApiController]
    public class StoreFrontController : ControllerBase
    {

        private IStoreFrontBL _storeBL;
        private IInventoryBL _irepo;
        private IOrderBL _orderBL;

        public StoreFrontController(IStoreFrontBL p_storeBL, IInventoryBL p_irepo, IOrderBL orderBL)
        {
            _storeBL = p_storeBL;
            _irepo = p_irepo;
            _orderBL = orderBL;
        }

        /// <summary>
        /// Gets All Customers StoreFronts
        /// </summary>
        /// <returns>List of StoreFronts</returns>

        // GET: api/StoreFront
        [HttpGet("GetStoreInfo")]
        public IActionResult GetAllStoreFronts()
        {
            try
            {
                Log.Information("List of Stores Retrieved Successfully");
                return Ok(_storeBL.GetAllStoreFronts());
            }
            catch (SqlException)
            {
                Log.Information("Error in Retrieving List of Stores");
                return NotFound();
            }
        }

        [HttpGet("GetAllInventory")]
        public IActionResult GetAllInventory()
        {
            try
            {
                Log.Information("Inventory successfully retrieved");
                return Ok(_irepo.GetAllInventory());
            }
            catch (SqlException)
            {
                Log.Information("Error in retrieving store infor");
                return NotFound();
            }
        }

        /// <summary>
        /// Gets a storeFront by the store ID
        /// </summary>
        /// <returns>JSON SIngle StoreFront</returns>
        // GET: api/StoreFront/5
        [HttpGet("GetInventoryByStoreID")]
        public IActionResult GetAllInventoryByStoreID([FromQuery] int id)
        {
            try
            {
                Log.Information("Store Information successfully retrieved");
                return Ok(_irepo.GetAllInventoryByStoreID(id));
            }
            catch (SqlException)
            {
                Log.Information("Error in retrieving store infor");
                return NotFound();
            }
        }

        /// <summary>
        /// Searches Store order history
        /// </summary>
        /// <param name="_storeID"></param>
        /// <returns>List of Store Order History</returns>

        [HttpGet("StoreOrderHistory")]
        public async Task<IActionResult> SearchStoreOrder([FromQuery] int _storeID)
        {
            try
            {
                Log.Information("Store order History retrieved");
                return Ok(await _orderBL.SearchStoreOrder(_storeID));
            }
            catch (System.Exception e)
            {

                //will return an appropriate status code:
                Log.Information("Error in retrieving store order history");
                return NotFound(new { Result = e.Message });
            }
        }

        /// <summary>
        /// Gets Store order history by Id and Filter
        /// </summary>
        /// <returns>List of Store Order history by filter and id</returns>
        // POST: api/StoreFront
        [HttpGet("StoreOrderHistoryFilter")]
        public async Task<IActionResult> SearchStoreOrderHistFilter(int p_storeID, string p_filter)
        {
            try
            {
                Log.Information("Store order history by filter retrieved");
                return Ok(await _orderBL.SearchStoreOrderHistFilter(p_storeID, p_filter));
            }
            catch (System.Exception)
            {

                //will return an appropriate status code:
                Log.Information("error in retrieving store order history");
                return NotFound();
            }
        }

        /// <summary>
        /// Gets all manager information
        /// </summary>
        /// <returns>list of manager info</returns>

        [HttpGet("GetManagerInfo")]
        public IActionResult GetAllManagers()
        {
            try
            {
                Log.Information("Managers info retrieved");
                return Ok(_storeBL.GetAllManagers());
            }
            catch (SqlException)
            {
                Log.Information("error in retrieving manager info");
                return NotFound();
            }
        }

        /// <summary>
        /// Gets a managers info based on their id
        /// </summary>
        /// <param name="_id"></param>
        /// <returns>a single managers info</returns>

        [HttpGet("GetManagerById")]
        public IActionResult GetManagerById([FromQuery] int _id)
        {
            try
            {
                Log.Information("Manager's info retrieved");
                return Ok(_storeBL.GetManagerById(_id));
            }
            catch (SqlException)
            {
                Log.Information("errory in retrieving manager info");
                return NotFound();
            }
        }


        /// <summary>
        /// Updates inventory with manager credintials
        /// </summary>
        /// <returns>returns updated inventory item and new quantity</returns>

        [HttpPut("UpdateInventory")] //PUT creates a new resource or replaces a representation of the target resource with 
                                     //the target payload.
        public IActionResult Put([FromQuery] Inventory _inv, string _email, string _managerPassword)
        {

            if (_storeBL.IsManager(_email, _managerPassword))
            {
                try
                {
                    Log.Information("Manager updated inventory");
                    return Ok(_storeBL.AddInventory(_inv, _email, _managerPassword));
                }
                catch (System.Exception)
                {
                    Log.Information("Error in updating inventory");
                    return BadRequest();
                }
            }
            else
            {
                Log.Information("Cedintials were not correct");
                return StatusCode(401, "Access Denied");
            }



        }

        // PUT: api/StoreFront/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/StoreFront/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
