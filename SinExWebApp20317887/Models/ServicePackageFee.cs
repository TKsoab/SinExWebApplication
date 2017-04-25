using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace SinExWebApp20317887.Models
{
    [Table("ServicePackageFee")]
    public class ServicePackageFee
    {
        public virtual int ServicePackageFeeID { get; set; }
        public virtual decimal Fee { get; set; }
        public virtual decimal MinimumFee { get; set; }
        //Foreign
        public virtual int PackageTypeID { get; set; }
        public virtual int ServiceTypeID { get; set; }
        //Navigation to PackageT
        public virtual PackageType PackageType { get; set; }
        //Navigation to ServiceT
        public virtual ServiceType ServiceType { get; set; }

        //public virtual String CurrencyType { get; set; }
        //public virtual List<SelectListItem> CurrencyTypes { get; set; }
    }
}