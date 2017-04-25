using SinExWebApp20317887.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinExWebApp20317887.Models
{
    public class PersonalShippingAccount:ShippingAccount
    {
        public virtual int PersonalShippingAccountId { get; set; }

        [Required(ErrorMessage = "This Field Is Required.")]
        [StringLength(35,ErrorMessage ="Maximum Characters are 35.")]
        [Display(Name = "First Name")]
        [MaxWords(35)]
        public virtual string FirstName { get; set; }
        [Required(ErrorMessage = "This Field Is Required.")]
        [StringLength(35, ErrorMessage = "Maximum Characters are 35.")]
        [Display(Name = "Last Name")]
        [MaxWords(35)]
        public virtual string LastName { get; set; }
    }
}