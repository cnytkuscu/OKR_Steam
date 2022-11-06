using Microsoft.AspNetCore.Mvc;

namespace OKR_Steam.Controllers.IC
{
    public interface IItemController
    {  
        #region GET METHODS 
        public IActionResult GetItemDetailByItemId(Guid itemId); 

        #endregion


        #region INSERT METHODS
        #endregion

        #region UPDATE METHODS
        #endregion

        #region DELETE METHODS
        #endregion
    }
}
