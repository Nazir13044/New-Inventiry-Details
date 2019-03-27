using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory.Entity;
using Inventory.InventoryInterface;
using Inventory.InventoryReposito;
using WCMS_COMMON;

namespace Inventory.InventoryManager
{
    public class InventoryOutManager
    {
        private readonly InventoryOutInterface _iinventoryOutManager = new InventoryOutRepository();



        public List<tblInventoryForServiceItem> CheckImeiNumber(tblInventoryForServiceItem checkImei)
        {         
            try
            {
              
                return _iinventoryOutManager.CheckImeiNumber(checkImei);
            }
            catch (Exception ex)
            {
                throw ex;
            }
      
        }

        public Result InsertInventoryOutInfo(List<tblInventoryForServiceItem> imeiNumber)
        {

            var result = new Result();
            try
            {
                result.IsSuccess = _iinventoryOutManager.InsertInventoryOutInfo(imeiNumber);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<tblDealerInfo> GetDealerInfoDetails(string term)
        {
            var retailers = new List<tblDealerInfo>();
            try
            {
                retailers = _iinventoryOutManager.GetDealerInfoDetails(term);
            }
            catch (Exception ex)
            {

            }

            return retailers;
        }

    }
}