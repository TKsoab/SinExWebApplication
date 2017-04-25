using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinExWebApp20317887.ViewModels
{
    public class ShipmentsSearchViewModel
    {
        public virtual int ShippingAccountId { get; set; }
        public virtual List<SelectListItem> ShippingAccounts { get; set; }
        public virtual List<SelectListItem> days { get; set; }
        public virtual List<SelectListItem> months { get; set; }
        public virtual List<SelectListItem> years { get; set; }
        public virtual string Shipdaybefore { get; set; }
        public virtual string Shipmonthbefore { get; set; }
        public virtual string Shipyearbefore { get; set; }
        public virtual string Shipdayafter { get; set; }
        public virtual string Shipmonthafter { get; set; }
        public virtual string Shipyearafter { get; set; }
        public virtual string Deliverydaybefore { get; set; }
        public virtual string Deliverymonthbefore { get; set; }
        public virtual string Deliveryyearbefore { get; set; }
        public virtual string Deliverydayafter { get; set; }
        public virtual string Deliverymonthafter { get; set; }
        public virtual string Deliveryyearafter { get; set; }
        //        public virtual DateTime DeliveredDate { get; set; }

    }
}