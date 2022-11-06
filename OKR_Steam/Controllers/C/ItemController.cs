using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Business.IBS;
using OKR_Steam.Controllers.IC;

namespace OKR_Steam.Controllers.C
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller, IItemController
    {
        private readonly IItemBusiness _itemBusiness;
        public ItemController(IItemBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }


        [HttpGet("GetItemDetailByItemId/{itemId}")]
        public IActionResult GetItemDetailByItemId(Guid itemId)
        {
            var returnData = _itemBusiness.GetItemDetailByItemId(itemId);
            return Ok(returnData);
        }

        
    }
}
