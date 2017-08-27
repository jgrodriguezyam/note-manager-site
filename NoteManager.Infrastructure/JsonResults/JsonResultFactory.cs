using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NoteManager.Infrastructure.TempDatas;

namespace NoteManager.Infrastructure.JsonResults
{
    public class JsonFactory : Controller
    {
        public JsonResult Success()
        {
            return Json(new { Result = ETempData.Success.ToString() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Success(string message)
        {
            return Json(new { Result = ETempData.Success.ToString(), Message = message }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Success(string message, string view)
        {
            return Json(new { Result = ETempData.Success.ToString(), Message = message, View = view }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Success(string message, int id)
        {
            return Json(new { Result = ETempData.Success.ToString(), Message = message, Id = id },
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult Success<T>(T model, string message = "")
        {
            return Json(new { Result = ETempData.Success.ToString(), Message = message, Record = model }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Success<T>(List<T> models)
        {
            return Json(new { Result = ETempData.Success.ToString(), Records = models }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Success<T>(List<T> models, int count)
        {
            return Json(new { Result = ETempData.Success.ToString(), Records = models, Count = count }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Information(string message = "")
        {
            return Json(new { Result = ETempData.Information.ToString(), Message = message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Failure(Type typeException, string message)
        {
            var result = ETempData.Failure.ToString();
            return Json(new { Result = result, Message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}