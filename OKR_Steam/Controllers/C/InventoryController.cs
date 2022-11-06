using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Business.IBS;
using OKR_Steam.Controllers.IC;

namespace OKR_Steam.Controllers.C
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : Controller,IInventoryController
    {
        private readonly IInventoryBusiness _inventoryBusiness;
        public InventoryController(IInventoryBusiness inventoryBusiness)
        {
            _inventoryBusiness = inventoryBusiness; 
        }


        [HttpGet("GetSteamInventoryByUsername/{username}")]
        public IActionResult GetSteamInventoryByUsername(string username)
        {
            var returnData = _inventoryBusiness.GetSteamInventoryByUsername(username);
            return Ok(returnData);
        }
    }
}
