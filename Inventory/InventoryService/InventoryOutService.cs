using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory.Entity;
using Inventory.InventoryManager;
using WCMS_COMMON;

namespace Inventory.InventoryService
{
    public class InventoryOutService
    {
        private readonly InventoryOutManager _inventoryOutManager=new InventoryOutManager();
       

        public List<tblInventoryForServiceItem> CheckImeiNumber(tblInventoryForServiceItem checkImei)
        {
            var list = new List<tblInventoryForServiceItem>();
            try
            {

                list= _inventoryOutManager.CheckImeiNumber(checkImei);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return list;
        }

        public Result InsertInventoryOutInfo(List<tblInventoryForServiceItem> imeiNumber)
        {
            try
            {

                return _inventoryOutManager.InsertInventoryOutInfo(imeiNumber);
            }
            catch (Exception ex)
            {

                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public List<tblDealerInfo> GetDealerInfoDetails(string term)
        {
            var list = new List<tblDealerInfo>();
            try
            {

                list = _inventoryOutManager.GetDealerInfoDetails(term);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return list;
        }

    }
}