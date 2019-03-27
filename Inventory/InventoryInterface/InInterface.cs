using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entity;
using WCMS_COMMON;

namespace Inventory.InventoryInterface
{
    interface InInterface
    {
        List<tblModel> GetModelName();
        List<tblColor> GetColorName();
        List<tblIMEIRecord> ImeiExists(tblIMEIRecord imei);
     
        bool InsertImeiInfo(tblInventoryForServiceItem im);

   
        bool InsertblBarcodeInventory(tblInventoryForServiceItem im);

        //tblInventoryForServiceItem CheckDuplicateIMEI(tblInventoryForServiceItem checkDuplicate);
        //List<tblInventoryForServiceItem> CheckDuplicateIMEI(tblInventoryForServiceItem checkImei);
        List<tblInventoryForServiceItem> CheckDuplicateIMEI(tblInventoryForServiceItem checkImei);
    }
}
