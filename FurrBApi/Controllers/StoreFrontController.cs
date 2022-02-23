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
        public StoreFrontController(IStoreFrontBL p_storeBL, IInventoryBL p_irepo)
        {
            _storeBL = p_storeBL;
            _irepo = p_irepo;
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
        [HttpGet("GetInventoryByStoreID{id}")]
        public IActionResult GetInventoryByStoreID(int id)
        {
            //try
            //{
            return Ok(_irepo.GetAllInventoryByStoreID(id));
            // }
            //catch (SqlException)
            // {

            // return NotFound();
            //}
        }

        // POST: api/StoreFront
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
