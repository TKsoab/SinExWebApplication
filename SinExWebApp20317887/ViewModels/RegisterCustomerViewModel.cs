using SinExWebApp20317887.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SinExWebApp20317887.ViewModels
{
    public class RegisterCustomerViewModel
    {
        public PersonalShippingAccount PersonalInformation { get; set; }
        public BusinessShippingAccount BusinessInformation { get; set; }
        public RegisterViewModel LoginInformation { get; set; }
        public virtual List<SelectListItem> months { get; set; }
        public virtual List<SelectListItem> years { get; set; }

    }
}