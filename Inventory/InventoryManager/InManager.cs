using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory.Entity;
using Inventory.InventoryInterface;
using Inventory.InventoryReposito;
using Inventory.InventoryService;
using WCMS_COMMON;

namespace Inventory.InventoryManager
{
    public class InManager
    {
        private readonly InInterface _iiInterface = new InRepository();

        public List<tblModel> GetModelName()
        {
            try
            {
                return _iiInterface.GetModelName();
            }
            catch (Exception ex) { throw ex; }
        }
        public List<tblColor> GetColorName()
        {
            try
            {
                return _iiInterface.GetColorName();
            }
            catch (Exception ex) { throw ex; }
        }



        //public List<tblBarCodeInv> BarcodeExists(tblBarCodeInv bar)
        //{
        //    try
        //    {

        //        return _iiInterface.BarcodeExists(bar);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<tblIMEIRecord> ImeiExists(tblIMEIRecord imei)
        {
            try
            {

                return _iiInterface.ImeiExists(imei);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public tblInventoryForServiceItem CheckDuplicateIMEI(tblInventoryForServiceItem checkDuplicate)
        //{
        //    try
        //    {

        //        return _iiInterface.CheckDuplicateIMEI(checkDuplicate);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<tblInventoryForServiceItem> CheckDuplicateIMEI(tblInventoryForServiceItem checkImei)
        {
            var result = new Result();
            try
            {

                return _iiInterface.CheckDuplicateIMEI(checkImei);
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public Result InsertImeiInfo(tblInventoryForServiceItem im)
        {

            var result = new Result();
            try
            {
                result.IsSuccess = _iiInterface.InsertImeiInfo(im);
                if (result.IsSuccess)
                {
                    result.IsSuccess = _iiInterface.InsertblBarcodeInventory(im);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

       
    }
}