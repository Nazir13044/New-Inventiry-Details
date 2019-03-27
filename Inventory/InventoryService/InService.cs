using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory.Entity;
using Inventory.InventoryManager;
using WCMS_COMMON;

namespace Inventory.InventoryService
{

    public class InService
    {
        private readonly InManager _inManager=new InManager();
        public List<tblModel> GetModelName()
        {
            var list = new List<tblModel>();
            try
            {
                list = _inManager.GetModelName();
            }
            catch (Exception ex)
            {

            }

            return list;
        }
        public List<tblColor> GetColorName()
        {
            var list = new List<tblColor>();
            try
            {
                list = _inManager.GetColorName();
            }
            catch (Exception ex)
            {

            }

            return list;
        }




        public List<tblIMEIRecord> ImeiExists(tblIMEIRecord im)
        {
            var list = new List<tblIMEIRecord>();
            try
            {
                list = _inManager.ImeiExists(im);
            }
            catch (Exception ex)
            {

            }
            return list;
        }


        //public tblInventoryForServiceItem CheckDuplicateIMEI(tblInventoryForServiceItem checkDuplicate)
        //{
        //    //var list = new List<tblInventoryForServiceItem>();
        //    try
        //    {
        //        return _inManager.CheckDuplicateIMEI(checkDuplicate);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
     
        //}

        public List<tblInventoryForServiceItem> CheckDuplicateIMEI(tblInventoryForServiceItem checkImei)
        {
            //var result = new Result();
            try
            {

               return _inManager.CheckDuplicateIMEI(checkImei);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return list;
        }



       

        public Result InsertImeiInfo(tblInventoryForServiceItem im)
        {
            try
            {

                return _inManager.InsertImeiInfo(im);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        //public Result InsertInventoryBarcode(tblBarCodeInv im)
        //{
        //    try
        //    {

        //        return _inManager.InsertInventoryBarcode(im);
        //    }
        //    catch (Exception ex)
        //    {

        //        return new Result { IsSuccess = false, Message = ex.Message };
        //    }
        //}

    }
}