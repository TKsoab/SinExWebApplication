﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinExWebApp20317887.Models;

namespace SinExWebApp20317887.Controllers
{
    public class BusinessShippingAccountsController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();

        // GET: BusinessShippingAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessShippingAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusinessShippingAccountId,ContactPersonName,CompanyName,DepartmentName,ShippingAccountId,BuildingInfo,StreetInfo,CityInfo,ProvinceCode,PostalCode,PhoneNumber,Email,CreditCardType,CreditCardNumber,CreditCardSecurityNumber,CreditCardHolderName,CreditCardExpiryYear,CreditCardExpiryMonth")] BusinessShippingAccount businessShippingAccount)
        {
            if (ModelState.IsValid)
            {
                //db.BusinessShippingAccounts.Add(businessShippingAccount);
                //db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(businessShippingAccount);
        }

        // GET: BusinessShippingAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessShippingAccount businessShippingAccount = (BusinessShippingAccount)db.BusinessShippingAccounts.Find(id);
            if (businessShippingAccount == null)
            {
                return HttpNotFound();
            }
            return View(businessShippingAccount);
        }

        // POST: BusinessShippingAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusinessShippingAccountId,ContactPersonName,CompanyName,DepartmentName,ShippingAccountId,BuildingInfo,StreetInfo,CityInfo,ProvinceCode,PostalCode,PhoneNumber,Email,CreditCardType,CreditCardNumber,CreditCardSecurityNumber,CreditCardHolderName,CreditCardExpiryYear,CreditCardExpiryMonth")] BusinessShippingAccount businessShippingAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessShippingAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(businessShippingAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
