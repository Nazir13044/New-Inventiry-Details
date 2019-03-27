using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Entity;
using Inventory.InventoryService;
using WCMS_COMMON;

namespace Inventory.Controllers
{
    public class InventoryOutController : Controller
    {
         private readonly InventoryOutService _inventoryOutService=new InventoryOutService();
        public ActionResult Index()
        {
            return View();
        }



        public JsonResult CheckImeiNumber(tblInventoryForServiceItem checkImei)
        {
            var list = new List<tblInventoryForServiceItem>();
            try
            {
                list = _inventoryOutService.CheckImeiNumber(checkImei).ToList();         
            }
            catch (Exception ex)
            {
                throw new Exception("Error message");
            }
            return Json(list.ToArray(), JsonRequestBehavior.AllowGet);


        }




        public JsonResult InsertInventoryOut(List<tblInventoryForServiceItem> imeiNumber)
        {
            var result = new Result();
            try
            {
                result = _inventoryOutService.InsertInventoryOutInfo(imeiNumber);                              
            }
            catch (Exception ex)
            {

            }
            return Json(result);


        }



        public JsonResult GetDealerInfoDetails(string term)
        {
            var list = new List<tblDealerInfo>();
            try
            {
                list = _inventoryOutService.GetDealerInfoDetails(term).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            var objstate = list.Select(x => new { value = x.DealerName, Id = x.DealerId, code = x.DealerCode, City=x.City,Address = x.DealerAddress, phone = x.DealerPhoneNumber }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }

	}
}