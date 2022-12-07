using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Business.IBS;

namespace OKR_Steam.Controllers.C
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemBusiness _itemBusiness;
        public ItemController(IItemBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }


        [HttpGet("GetItemDetailByItemId/{itemId}")]
        public ProcessResult<SteamItemModel> GetItemDetailByItemId(Guid itemId)
        {
            var returnData = new ProcessResult<SteamItemModel>();
            returnData = _itemBusiness.GetItemDetailByItemId(itemId);
            return returnData;
        }


    }
}
