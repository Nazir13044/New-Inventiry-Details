using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entity;
using WCMS_COMMON;

namespace Inventory.InventoryInterface
{
    interface InventoryOutInterface
    {
        bool InsertInventoryOutInfo(List<tblInventoryForServiceItem> imeiNumber);

        List<tblInventoryForServiceItem> CheckImeiNumber(tblInventoryForServiceItem checkImei);
        List<tblDealerInfo> GetDealerInfoDetails(string term);
    }
}
