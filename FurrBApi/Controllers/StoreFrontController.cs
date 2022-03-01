using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeBL;


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
        // GET: api/StoreFront
        [HttpGet("GetStoreInfo")]
        public IActionResult GetAllStoreFronts()
        {
            try
            {
                return Ok(_storeBL.GetAllStoreFronts());
            }
            catch (SqlException)
            {
                return NotFound();
            }
        }

        // GET: api/StoreFront/5
        [HttpGet("GetInventoryByStoreID")]
        public IActionResult GetInventoryByStoreID([FromQuery] int id)
        {
            try
            {
                return Ok(_irepo.GetAllInventoryByStoreID(id));
            }
            catch (SqlException)
            {

                return NotFound();
            }
        }

        [HttpGet("StoreOrderHistory")]
        public async Task<IActionResult> SearchStoreOrder([FromQuery] int _storeID)
        {
            try
            {

                return Ok(await _orderBL.SearchStoreOrder(_storeID));
            }
            catch (System.Exception e)
            {

                //will return an appropriate status code:
                return NotFound(new { Result = e.Message });
            }
        }

        // POST: api/StoreFront
        [HttpGet("StoreOrderHistoryFilter")]
        public async Task<IActionResult> SearchStoreOrderHistFilter(int p_storeID, string p_filter)
        {
            try
            {

                return Ok(await _orderBL.SearchStoreOrderHistFilter(p_storeID, p_filter));
            }
            catch (System.Exception)
            {

                //will return an appropriate status code:
                return NotFound();
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
