using System;
using System.Web.Mvc;

namespace NoteManager.Infrastructure.TempDatas
{
    public class TempDataFactory : Controller
    {
        #region Create

        public void CreateFailure(Type typeException, ControllerBase controller, string message)
        {
            controller.TempData[ETempData.Failure.ToString()] = message;
        }

        public void CreateFailure(ControllerBase controller, string message)
        {   
            controller.TempData[ETempData.Failure.ToString()] = message;
        }

        public void CreateSuccess(ControllerBase controller, string message)
        {
            controller.TempData[ETempData.Success.ToString()] = message;
        }

        public void CreateInformation(ControllerBase controller, string message)
        {
            controller.TempData[ETempData.Information.ToString()] = message;
        }

        public void CreateWarning(ControllerBase controller, string message)
        {
            controller.TempData[ETempData.Warning.ToString()] = message;
        }

        #endregion

        #region Remove

        public void RemoveFailure(ControllerBase controller)
        {
            controller.TempData[ETempData.Failure.ToString()] = null;
        }

        public void RemoveSuccess(ControllerBase controller)
        {
            controller.TempData[ETempData.Success.ToString()] = null;
        }

        public void RemoveInformation(ControllerBase controller)
        {
            controller.TempData[ETempData.Information.ToString()] = null;
        }

        public void RemoveWarning(ControllerBase controller)
        {
            controller.TempData[ETempData.Warning.ToString()] = null;
        }
        
        #endregion
    }
}