using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using SinExWebApp20317887.Models;

namespace SinExWebApp20317887.Controllers
{
    public class BaseController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();
        // GET: Base





        public decimal ChangeCurrency(string currencyCode)
        {
        if(Session[currencyCode]==null){
            var currencies = db.Currencies.ToList();
            foreach (var item in currencies) {
                Session[item.CurrencyCode] = item.ExchangeRate;
            }
            }
            return Decimal.Parse(Session[currencyCode].ToString());
            //return fee*(Decimal)Session[currencyCode];
        }
    }
}