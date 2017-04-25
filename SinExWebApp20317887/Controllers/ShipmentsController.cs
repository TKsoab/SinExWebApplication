using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinExWebApp20317887.Models;
using SinExWebApp20317887.ViewModels;
using X.PagedList;

namespace SinExWebApp20317887.Controllers
{
    public class ShipmentsController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();

        // GET: Shipments/GenerateHistoryReport
        public ActionResult GenerateHistoryReport(int? ShippingAccountId,
            string Shipdaybefore,
        string Shipmonthbefore,
        string Shipyearbefore,
        string Shipdayafter,
        string Shipmonthafter,
        string Shipyearafter,

            string sortOrder, int? currentShippingAccountId, int? page, string currentShipdaybefore,
        string currentShipmonthbefore,
        string currentShipyearbefore,
        string currentShipdayafter,
        string currentShipmonthafter,
        string currentShipyearafter
)
        {
            // Instantiate an instance of the ShipmentsReportViewModel and the ShipmentsSearchViewModel.
            var shipmentSearch = new ShipmentsReportViewModel();
            shipmentSearch.Shipment = new ShipmentsSearchViewModel();

            //Code for paging
            ViewBag.CurrentSort = sortOrder;
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            if (ShippingAccountId == null)
            {
                ShippingAccountId = currentShippingAccountId;
            }
            else { page = 1; }
            if (Shipdaybefore == "" ||
        Shipmonthbefore == "" ||
        Shipyearbefore == "")
            {
                Shipdaybefore = currentShipdaybefore;
                Shipmonthbefore = currentShipmonthbefore;
                Shipyearbefore = currentShipyearbefore;
            }
            if (Shipdayafter == "" ||
Shipmonthafter == "" ||
Shipyearafter == "")
            {
                Shipdayafter = currentShipdayafter;
                Shipmonthafter = currentShipmonthafter;
                Shipyearafter = currentShipyearafter;
            }
           

            ViewBag.CurrentShippingAccountId = ShippingAccountId;
            ViewBag.CurrentShipdaybefore = Shipdaybefore;
            ViewBag.CurrentShipmonthbefore = Shipmonthbefore;
            ViewBag.CurrentShipyearbefore = Shipyearbefore;
            ViewBag.CurrentShipdayafter = Shipdayafter;
            ViewBag.CurrentShipmonthafter = Shipmonthafter;
            ViewBag.CurrentShipyearafter = Shipyearafter;

            // Populate the ShippingAccountId dropdown list.
            shipmentSearch.Shipment.ShippingAccounts = PopulateShippingAccountsDropdownList().ToList();
            shipmentSearch.Shipment.days = PopulateNumberDropdownList(1, 31).ToList();
            shipmentSearch.Shipment.months = PopulateNumberDropdownList(1, 12).ToList();
            DateTime now = DateTime.Now;
            shipmentSearch.Shipment.years = PopulateNumberDropdownList(now.Year - 2, now.Year + 5).ToList();
            ViewBag.ShippingAccountId = currentShippingAccountId;
            ViewBag.Shipdaybefore = currentShipdaybefore;
            ViewBag.Shipmonthbefore = currentShipmonthbefore;
            ViewBag.Shipyearbefore = currentShipyearbefore;
            ViewBag.Shipdayafter = currentShipdayafter;
            ViewBag.Shipmonthafter = currentShipmonthafter;
            ViewBag.Shipyearafter = currentShipyearafter;

            // shipmentSearch.Shipment.ShippingAccountId =(int) currentShippingAccountId;
            // Initialize the query to retrieve shipments using the ShipmentsListViewModel.
            var shipmentQuery = from s in db.Shipments
                                select new ShipmentsListViewModel
                                {
                                    WaybillId = s.WaybillId,
                                    ServiceType = s.ServiceType,
                                    ShippedDate = s.ShippedDate,
                                    DeliveredDate = s.DeliveredDate,
                                    RecipientName = s.RecipientName,
                                    NumberOfPackages = s.NumberOfPackages,
                                    Origin = s.Origin,
                                    Destination = s.Destination,
                                    ShippingAccountId = s.ShippingAccountId
                                };
            // Add the condition to select a spefic shipping account if shipping account id is not null.
            if (ShippingAccountId != null)
            {
                DateTime Shipbefore;
                DateTime Shipafter;
                DateTime Deliverybefore;
                DateTime Deliveryafter;
                int yeart, montht, dayt;
                // if (ShippedDateF != null) { shipmentQuery = shipmentQuery.Where(s => s.ShippedDate >= ShippedDateF); }
                if (((Shipdaybefore != "" && Shipmonthbefore != "" && Shipyearbefore != "")) && Shipdaybefore != null && Shipmonthbefore != null && Shipyearbefore != null)
                {
                    yeart = int.Parse(Shipyearbefore);
                    montht = int.Parse(Shipmonthbefore);
                    dayt = int.Parse(Shipdaybefore);
                    Shipbefore = new DateTime(yeart, montht, dayt);

                }
                else { Shipbefore = DateTime.MaxValue; }
                if (((Shipdayafter != "" && Shipmonthafter != "" && Shipyearafter != "")) && Shipdayafter != null && Shipmonthafter != null && Shipyearafter != null)
                {
                    yeart = int.Parse(Shipyearafter);
                    montht = int.Parse(Shipmonthafter);
                    dayt = int.Parse(Shipdayafter);

                    Shipafter = new DateTime(yeart, montht, dayt);

                }
                else { Shipafter = DateTime.MinValue; }


                // TODO: Construct the LINQ query to retrive only the shipments for the specified shipping account id.
                shipmentQuery = shipmentQuery.Where(s => s.ShippingAccountId == ShippingAccountId);

                shipmentQuery = shipmentQuery.Where(s => s.ShippedDate <= Shipbefore);
                shipmentQuery = shipmentQuery.Where(s => s.ShippedDate >= Shipafter);



                ViewBag.ServiceTypeSortParm = sortOrder == "serviceType" ? "serviceType_desc" : "serviceType";
                ViewBag.ShippedDateSortParm = sortOrder == "shippedDate" ? "shippedDate_desc" : "shippedDate";
                ViewBag.DeliveredDateSortParm = sortOrder == "deliveredDate" ? "deliveredDate_desc" : "deliveredDate";
                ViewBag.RecipientNameSortParm = sortOrder == "recipientName" ? "recipientName_desc" : "recipientName";
                ViewBag.OriginSortParm = sortOrder == "origin" ? "origin_desc" : "origin";
                ViewBag.DestinationSortParm = sortOrder == "destination" ? "destination_desc" : "destination";

                switch (sortOrder)
                {
                    case "serviceType":
                        shipmentQuery = shipmentQuery.OrderBy(s => s.ServiceType); break;
                    case "serviceType_desc":
                        shipmentQuery = shipmentQuery.OrderByDescending(s => s.ServiceType); break;

                    case "shippedDate":
                        shipmentQuery = shipmentQuery.OrderBy(s => s.ShippedDate); break;
                    case "shippedDate_desc":
                        shipmentQuery = shipmentQuery.OrderByDescending(s => s.ShippedDate); break;

                    case "deliveredDate":
                        shipmentQuery = shipmentQuery.OrderBy(s => s.DeliveredDate); break;
                    case "deliveredDate_desc":
                        shipmentQuery = shipmentQuery.OrderByDescending(s => s.DeliveredDate); break;

                    case "recipientName":
                        shipmentQuery = shipmentQuery.OrderBy(s => s.RecipientName); break;
                    case "recipientName_desc":
                        shipmentQuery = shipmentQuery.OrderByDescending(s => s.RecipientName); break;

                    case "origin":
                        shipmentQuery = shipmentQuery.OrderBy(s => s.Origin); break;
                    case "origin_desc":
                        shipmentQuery = shipmentQuery.OrderByDescending(s => s.Origin); break;

                    case "destination":
                        shipmentQuery = shipmentQuery.OrderBy(s => s.Destination); break;
                    case "destination_desc":
                        shipmentQuery = shipmentQuery.OrderByDescending(s => s.Destination); break;

                    default: shipmentQuery = shipmentQuery.OrderBy(s => s.WaybillId); break;
                }
                shipmentSearch.Shipments = shipmentQuery.ToPagedList(pageNumber, pageSize);
            }
            else
            {
                // Return an empty result if no shipping account id has been selected.
                shipmentSearch.Shipments = new ShipmentsListViewModel[0].ToPagedList(pageNumber, pageSize);
            }



            return View(shipmentSearch);
        }

        private SelectList PopulateShippingAccountsDropdownList()
        {
            // TODO: Construct the LINQ query to retrieve the unique list of shipping account ids.
            var shippingAccountQuery = db.Shipments.Select(s => s.ShippingAccountId).Distinct().OrderBy(c => c);
            return new SelectList(shippingAccountQuery);
        }
        private SelectList PopulateNumberDropdownList(int s, int e)
        {
            // TODO: Construct the LINQ query to retrieve the unique list of shipping account ids.
            string[] arr = new string[e - s + 1];
            for (int i = 0; s <= e; s++, i++)
            {
                arr[i] = s.ToString();
            }
            return new SelectList(arr);
        }

        // GET: Shipments
        public ActionResult Index()
        {

            return View(db.Shipments.ToList());
        }

        // GET: Shipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // GET: Shipments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WaybillId,ReferenceNumber,ServiceType,ShippedDate,DeliveredDate,RecipientName,NumberOfPackages,Origin,Destination,Status,ShippingAccountId")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Shipments.Add(shipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipment);
        }

        // GET: Shipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // POST: Shipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WaybillId,ReferenceNumber,ServiceType,ShippedDate,DeliveredDate,RecipientName,NumberOfPackages,Origin,Destination,Status,ShippingAccountId")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipment);
        }

        // GET: Shipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipment shipment = db.Shipments.Find(id);
            db.Shipments.Remove(shipment);
            db.SaveChanges();
            return RedirectToAction("Index");
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
