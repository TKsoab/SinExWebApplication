using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinExWebApp20317887.Validation
{
    public class CreditCardValidation : ValidationAttribute
    {
        private readonly string _choose;

        public CreditCardValidation(string choose)
            : base("{0} Is Not A Valid Year Input")
        {
            _choose = choose;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var v = value.ToString();


                switch (_choose)
                {
                    case "Year":
                        switch (v)
                        {
                            case "2016": return new ValidationResult("Please Enter Valid Year Between 2017-2027.");
                            case "2017":
                            case "2018":
                            case "2019":
                            case "2020":
                            case "2021":
                            case "2022":
                            case "2023":
                            case "2024":
                            case "2025":
                            case "2026":
                            case "2027": return ValidationResult.Success;
                            default: return new ValidationResult("Please Enter Valid Year Between 2017-2027.");
                        }
                    case "Month":
                        if (v != "01" && v != "02" && v != "03" && v != "04" && v != "05" && v != "06" && v != "07" && v != "08" && v != "09" &&
                            v != "10" && v != "11" && v != "12")
                        {
                            return new ValidationResult("Please Enter Valid Month Between 01-12.");
                        }
                        else return ValidationResult.Success;

                    case "Type":
                        if (v != "American Express" && v != "DinersClub" && v != "Discover" && v != "MasterCard" && v != "UnionPay" && v != "Visa")
                        {
                            return new ValidationResult("Please Enter Valid Credit Card Type.");
                        }
                        else return ValidationResult.Success;


                }
            }
            return ValidationResult.Success;
        }
    }
}