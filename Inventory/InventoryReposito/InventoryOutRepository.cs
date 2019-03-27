using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Inventory.Entity;
using Inventory.InventoryInterface;
using WCMS_COMMON;

namespace Inventory.InventoryReposito
{
    public class InventoryOutRepository : InventoryOutInterface
    {
        private readonly WCMSEntities _entities = new WCMSEntities();




        public List<tblInventoryForServiceItem> CheckImeiNumber(tblInventoryForServiceItem checkImei)
        {
            List<tblInventoryForServiceItem> list;

            try
            {
                

                    list =
                        _entities.tblInventoryForServiceItems.Where(
                            x => x.IMEI1 == checkImei.IMEI1 || x.IMEI2 == checkImei.IMEI1).ToList();

            }
            catch(Exception exception)
            {

                throw exception;

            }

            return list;
         
        }


        public bool InsertInventoryOutInfo(List<tblInventoryForServiceItem> im)
        {

            try
            {
                foreach (var s in im)
                {
                    var list = new tblInventoryForServiceItem();

                    list =
                        _entities.tblInventoryForServiceItems.FirstOrDefault(
                            x => x.IMEI1 == s.IMEI1 || x.IMEI2 == s.IMEI1);
                    if (list != null)
                    {
                        if (s.IsInventoryOut == null)
                            list.IsInventoryOut = true;
                        if (s.IsInventoryOutDate == null)
                            list.IsInventoryOutDate = DateTime.Now;
                        _entities.Entry(list).State = EntityState.Modified;
                        _entities.SaveChanges();

                    }
                    else
                    {
                        return false;
                    }

                    
                }
            }
            catch
                (Exception
                    exception)
            {

                throw exception;

            }
        
            return true;
        }




        public List<tblDealerInfo> GetDealerInfoDetails(string term)
        {
            List<tblDealerInfo> retailers;

            using (var entity = new RBSYNERGYEntities())
            {

                retailers =
                    entity.tblDealerInfoes.Where(a => a.DealerName.ToLower().Contains(term.ToLower()))
                        .ToList();
            }
            return retailers;
        }

    }
}