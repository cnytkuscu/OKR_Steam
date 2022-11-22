using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Business.IBS;
using OKR_Steam.Models.ResponseModels;
using System.Data;
using System;
using System.Dynamic;
using OKR_Steam.ErrorMW;

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
