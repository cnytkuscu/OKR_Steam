using Microsoft.AspNetCore.Mvc;

namespace OKR_Steam.Controllers.IC
{
    public interface IInventoryController
    {
        #region GET METHODS

        public IActionResult GetSteamInventoryByUsername(string username);


        #endregion



        #region INSERT METHODS
        #endregion

        #region UPDATE METHODS
        #endregion

        #region DELETE METHODS
        #endregion
    }
}
