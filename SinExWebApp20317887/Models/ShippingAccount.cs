using SinExWebApp20317887.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinExWebApp20317887.Models
{
    [Table("ShippingAccount")]
    public abstract class ShippingAccount
    {
        public virtual int ShippingAccountId { get; set; }

        //        [Required][StringLength(12,MinimumLength =12)][RegularExpression(@"^[0-9]*$")]
        //        public virtual string ShippingAccountNumber { get; set; }
        [MaxWords(10)]
        [StringLength(10)]
        public virtual string UserName { get; set; }

        //navigation property
        public virtual ICollection<Shipment> Shipments { get; set; }

        //public virtual string acctype { get; set; }


        //general info
        // public virtual string MailingAddress { get; set; }
        [StringLength(50,ErrorMessage ="Please Limit Your Words In 50 Characters.")]
        [Display(Name = "Building")]
        [MaxWords(50)]
        public virtual string BuildingInfo { get; set; }

        [Required(ErrorMessage ="This Field Is Required.")]
        [StringLength(35, ErrorMessage = "Please Limit Your Words In 35 Characters.")]
        [Display(Name = "Street")]
        [MaxWords(35)]
        public virtual string StreetInfo { get; set; }

        [Required(ErrorMessage = "This Field Is Required.")]
        [StringLength(25, ErrorMessage = "Please Limit Your Words In 25 Characters.")]
        [Display(Name = "City")]
      //  [RegularExpression(@"^[A-Z,a-z]*$")]
        [MaxWords(25)]
        public virtual string CityInfo { get; set; }

        [Required(ErrorMessage = "This Field Is Required.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Please Enter Province Code With 2 Letters.")]
        [RegularExpression(@"^[A-Z]*$", ErrorMessage = "Please Enter Province Code With 2 Letters.")]
        [Display(Name = "Province Code")]
        [MaxWords(2)]
        public virtual string ProvinceCode { get; set; }

        [StringLength(6, MinimumLength = 5,ErrorMessage ="Invalid Code, Postal Code Should Be 5-6 Characters.")]
        [RegularExpression(@"^[A-Z,0-9]*$", ErrorMessage = "Only LETTERS And/Or DIGITS Are Valid Input.")]
        [Display(Name = "Postal Code")]
        [MaxWords(6)]
        public virtual string PostalCode { get; set; }

        [Required(ErrorMessage = "This Field Is Required.")]
        [StringLength(14, MinimumLength = 8,ErrorMessage ="Invalid Length.")]
        [RegularExpression(@"^\+*[0-9]*[0-9]+$", ErrorMessage = "Please Enter Valid Phone Number With Number Only.")]
        [Display(Name = "Phone Number")]
        [MaxWords(14)]
        public virtual string PhoneNumber { get; set; }

        [Required(ErrorMessage = "This Field Is Required.")]
        [StringLength(30,ErrorMessage ="Please Enter An Email Address Within 30 Characters.")]
        [RegularExpression(@"^([a-zA-z0-9_\-\.]+)\@([a-z]+)(\.)([a-z]+)(\.)*([a-z])*$", ErrorMessage ="Format Should Look Like Email@mail.com\nOnly A-Z,a-z,-,_,@ Are Allowed.")]//[RegularExpression(@"^[A-Za-z@,-,_]*$")]
        [Display(Name = "Email")]
        [MaxWords(30)]
        public virtual string Email { get; set; }

        //credit info
        [Required(ErrorMessage = "This Field Is Required.")]
        [StringLength(16)]
        [Display(Name = "Credit Card Type")]
        [MaxWords(16)]
        [CreditCardValidation("Type")]
        public virtual string CreditCardType { get; set; }

        [Required(ErrorMessage = "This Field Is Required.")]
        [StringLength(19, MinimumLength = 14,ErrorMessage ="Invalid Length.")]
        [Display(Name = "Card Number")]
        [RegularExpression(@"^[0-9]+$",ErrorMessage ="Numbers Only.")]
        [MaxWords(19)]
        public virtual string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "This Field Is Required.")]
        [StringLength(4, MinimumLength = 3,ErrorMessage = "Invalid Length")]
        [Display(Name = "Card Security Number")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Numbers Only.")]
        [MaxWords(4)]
        public virtual string CreditCardSecurityNumber { get; set; }

        [Required(ErrorMessage = "This Field Is Required.")]
        [StringLength(70)]
        [Display(Name = "Card Holder")]
        [MaxWords(70)]
        public virtual string CreditCardHolderName { get; set; }

        //        public virtual DateTime CreditCardExpiryDate { get; set; }
        [Required(ErrorMessage = "This Field Is Required.")]
        [Display(Name = "Expiry Year")]
        [MaxWords(4)]
        [StringLength(4,MinimumLength =4, ErrorMessage = "Please Enter Year In Full Format.(20XX)")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Numbers Only.")]
        [CreditCardValidation("Year")]
        public virtual string CreditCardExpiryYear { get; set; }

        [Required(ErrorMessage = "This Field Is Required.")]
        [Display(Name = "Expiry Month")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Numbers Only.")]
        [MaxWords(2)]
        [StringLength(2,MinimumLength =2, ErrorMessage = "Please Enter Year In Full Format.(01-12)")]
        [CreditCardValidation("Month")]
        public virtual string CreditCardExpiryMonth { get; set; }


    }
}