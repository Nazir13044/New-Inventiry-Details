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
    public class InventoryController : Controller
    {
      
        private readonly InService _inService=new InService();
        public ActionResult Index()
        {
            return View();
        }

      
        public JsonResult GetModelName()
        {
            List<tblModel> list = new List<tblModel>();
            try
            {
                list = _inService.GetModelName().ToList();
            }
            catch (Exception ex)
            {

            }
            var objstate = list.Select(x => new { value = x.Model, Id = x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetColorName()
        {
            List<tblColor> list = new List<tblColor>();
            try
            {
                list = _inService.GetColorName().ToList();
            }
            catch (Exception ex)
            {

            }
            var objstate = list.Select(x => new { value = x.Name, Id = x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult InsertImeiInfo(List<tblInventoryForServiceItem> imeiNumber)
        {
            var result = new Result();
            try
            {

                foreach (var im in imeiNumber)
                {


                 

                  


                        var existImei =
                            _inService.ImeiExists(new tblIMEIRecord() {IMEI1 = im.IMEI1}).FirstOrDefault();

                        if (existImei == null)
                        {
                            im.IsInventoryInDate = DateTime.Now;
                            im.IsInventoryIn = true;
                            im.AddedDate = DateTime.Now;
                            im.IsInventoryInDate = DateTime.Now;

                            result = _inService.InsertImeiInfo(im);
                        }
                        else
                        {

                            im.IsInventoryIn = true;
                            im.IsInventoryInDate = DateTime.Now;
                            im.IMEI1 = existImei.IMEI1;
                            im.IMEI2 = existImei.IMEI2;
                            im.Model = existImei.Model;
                            im.Color = existImei.Color;
                            im.Project = existImei.Project;
                            im.EanCode = existImei.EanCode;
                            im.AddedDate = existImei.AddedDate;
                            im.Bt = existImei.Bt;
                            im.Wifi = existImei.Wifi;
                            im.Sn = existImei.Sn;
                            im.WO = existImei.WO;
                            result = _inService.InsertImeiInfo(im);

                        }
                    }
              
            }
            catch (Exception ex)
            {

            }
            return Json(result);


        }

        //public JsonResult CheckDuplicateIMEI(tblInventoryForServiceItem checkImei)
        //{
        //    //var list = new List<tblInventoryForServiceItem>();
           
        //    var result = new Result();
        //    try
                
        //    {

        //        //list = _inService.CheckDuplicateIMEI(checkImei).ToList();
        //        var resul = _inService.CheckDuplicateIMEI(new tblInventoryForServiceItem() { IMEI1 = checkImei.IMEI1 });
        //        if (resul == null)
        //        {

        //        }
        //        else
        //        {
        //            result.IsSuccess = false;
        //            result.Message = "Current IMEI Already Exists";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Json(result);


        //}

        public JsonResult CheckDuplicateIMEI(tblInventoryForServiceItem checkImei)
       {
            var result = new Result();
            var list = new List<tblInventoryForServiceItem>();
            try
            {
                list = _inService.CheckDuplicateIMEI(checkImei).ToList(); 
                     
            }
            catch (Exception ex)
            {
                throw new Exception("Error message");
            }


            return Json(list);

        }


	}
}