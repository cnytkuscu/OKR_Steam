using Microsoft.AspNetCore.Mvc;


namespace OKR_Steam.Controllers.C
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : Controller
    {
        private readonly IInventoryBusiness _inventoryBusiness;
        public InventoryController(IInventoryBusiness inventoryBusiness)
        {
            _inventoryBusiness = inventoryBusiness;
        }


        [HttpGet("GetSteamInventoryByUsername/{username}")]
        public ProcessResult<SteamInventoryModel> GetSteamInventoryByUsername(string username)
        { 
            return _inventoryBusiness.GetSteamInventoryByUsername(username); 
        }
    }
}
