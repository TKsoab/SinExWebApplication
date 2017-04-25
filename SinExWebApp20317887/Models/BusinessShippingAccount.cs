using SinExWebApp20317887.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinExWebApp20317887.Models
{
    public class BusinessShippingAccount:ShippingAccount
    {
        public virtual int BusinessShippingAccountId { get; set; }

        [Required(ErrorMessage = "This Field Is Required.")]
        [StringLength(70, ErrorMessage = "Maximum Characters are 70.")]
        [Display(Name = "Contact Person")]
        [MaxWords(70)]
        public virtual string ContactPersonName { get; set; }
        [Required(ErrorMessage = "This Field Is Required.")]
        [StringLength(40, ErrorMessage = "Maximum Characters are 40.")]
        [Display(Name = "Company Name")]
        [MaxWords(40)]
        public virtual string CompanyName { get; set; }
        [StringLength(30, ErrorMessage = "Maximum Characters are 30.")]
        [Display(Name = "Department Name")]
        [MaxWords(30)]
        public virtual string DepartmentName { get; set; }
    }
}