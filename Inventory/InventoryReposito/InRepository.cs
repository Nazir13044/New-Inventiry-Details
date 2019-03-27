using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Inventory.Entity;
using Inventory.InventoryInterface;
using Microsoft.Ajax.Utilities;
using WCMS_COMMON;

namespace Inventory.InventoryReposito
{
    public class InRepository:InInterface
    {
        private readonly WCMSEntities _entities=new WCMSEntities();
      
        public List<tblModel> GetModelName()
        {
            List<tblModel> list;
            try
            {
                list = _entities.tblModels.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }
        public List<tblColor> GetColorName()
        {
            List<tblColor> list;
            try
            {
                list = _entities.tblColors.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

       
        public bool InsertImeiInfo(tblInventoryForServiceItem im)
        {
            try
            {

                _entities.tblInventoryForServiceItems.Add(im);
                _entities.SaveChanges();

            }
            catch (Exception exception)
            {

                throw exception;

            }

            return true;
        }

        public bool InsertblBarcodeInventory(tblInventoryForServiceItem im)
        {
            try
            {
                string type = null;
                string order = null;
                var s = im.WO;

                if (s != null)
                {

                    var index = s.IndexOf('_');
                    string ordernumb = (s.Substring(index + 1, 1).ToString());

                    if (ordernumb == "C" || ordernumb == "S")
                    {


                        if (ordernumb == "C")
                        {

                            var ckdIndex = s.IndexOf('_');
                            ordernumb = s.Substring(ckdIndex + 5, 1).ToString();
                            order = ordernumb;
                            type = s.Substring(ckdIndex + 1, 3).ToString();
                        }

                        if (ordernumb == "S")
                        {

                            var skdIndex = s.IndexOf('_');
                            ordernumb = s.Substring(skdIndex + 5, 1).ToString();
                            order = ordernumb;
                            type = "SKD";
                        }

                    }
                    else
                    {
                        type = "SKD";
                        if (ordernumb != "2" && ordernumb != "3" && ordernumb != "4" && ordernumb != "5")
                        {

                            order = "1";
                        }
                        else
                        {
                            order = ordernumb;
                        }

                    }



                    var barcode = new tblBarCodeInv
                    {
                        RecID = Guid.NewGuid(),
                        PrintDate = DateTime.Now,
                        ProductType = "Cell Phone",
                        DelieveredTo = order,
                        Model = im.Model,
                        Color = im.Color,
                        BarCode = im.IMEI1,
                        BarCode2 = im.IMEI2,

                        PrintSuccess = true,
                        AddedBy = "InventoryApp",
                        Updatedby = type,
                        DateAdded = DateTime.Now,
                        DateUpdated = DateTime.Now.ToString("yyyyMMdd")

                    };
                    _entities.tblBarCodeInvs.Add(barcode);
                    _entities.SaveChanges();


                }
                else
                {
                    var barcode2 = new tblBarCodeInv
                    {
                        RecID = Guid.NewGuid(),
                        PrintDate = DateTime.Now,
                        ProductType = "Cell Phone",
                        Model = im.Model,
                        Color = im.Color,
                        BarCode = im.IMEI1,
                        DelieveredTo = "h",
                        BarCode2 = im.IMEI2,
                        PrintSuccess = true,
                        AddedBy = "InventoryApp",
                        DateAdded = DateTime.Now,
                        DateUpdated = DateTime.Now.ToString("yyyyMMdd")

                    };
                    _entities.tblBarCodeInvs.Add(barcode2);
                    _entities.SaveChanges();

                }
            }
            catch (Exception exception)
            {

                throw exception;

            }

            return true;
        }


       
       
        public List<tblIMEIRecord> ImeiExists(tblIMEIRecord imei)
        {
            List<tblIMEIRecord> list;
            try
            {
                list = _entities.tblIMEIRecords.Where(x => x.IMEI1 == imei.IMEI1 || x.IMEI2 == imei.IMEI1).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }



        //public tblInventoryForServiceItem CheckDuplicateIMEI(tblInventoryForServiceItem imei)
        //{
        //   tblInventoryForServiceItem list;
        //    try
        //    {
        //        list = _entities.tblInventoryForServiceItems.FirstOrDefault(x => x.IMEI1 == imei.IMEI1 || x.IMEI2 == imei.IMEI1);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //    return list;
        //}

        public List<tblInventoryForServiceItem> CheckDuplicateIMEI(tblInventoryForServiceItem checkImei)
        {
            List<tblInventoryForServiceItem> list;

            try
            {

                list =
                    _entities.tblInventoryForServiceItems.Where(
                        x => x.IMEI1 == checkImei.IMEI1 || x.IMEI2 == checkImei.IMEI1 || x.IMEI1 == checkImei.IMEI2 || x.IMEI2 == checkImei.IMEI2).ToList();

            }
            catch (Exception exception)
            {

                throw exception;

            }

            return list;

        }
       
            
    }
}