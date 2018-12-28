using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using roomBooking;

namespace roomBooking.Controllers
{
    public class bookingsController : Controller
    {
        private SqlSchema db = new SqlSchema();

        // GET: bookings
        public ActionResult Index()
        {
            var bookings = db.bookings.Include(b => b.AspNetUser).Include(b => b.room);
            return View(bookings.ToList());
        }

        // GET: bookings/Details/5
         public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: bookings/Create
        public ActionResult Create()
        {
            ViewBag.userID = new SelectList(db.AspNetUsers.Where(x => x.Email == User.Identity.Name), "Id", "Email");
            ViewBag.roomID = new SelectList(db.rooms, "roomID", "roomName");
            return View();
        }

        // POST: bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventID,eventName,startDate,endDate,userID,roomID")] booking booking)
        {
            if (ModelState.IsValid)
            {
                String EmailAddress = db.AspNetUsers.Single(x => x.Id == booking.userID).Email;
                String Date = Convert.ToString(booking.startDate);
                String startTime = Convert.ToString(booking.startDate);
                String endTime = Convert.ToString(booking.endDate);
                String roomName = db.rooms.Single(x => x.roomID == booking.roomID).roomName;

                String Message = "Hello \n" + roomName + " Has Been Booked By You From " + startTime + " to " + endTime + ".";

                SOAPEmailService.Service_CallClient mailCall = new SOAPEmailService.Service_CallClient();
                String check = mailCall.sendMail(EmailAddress, Message);

                db.bookings.Add(booking);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.userID = new SelectList(db.AspNetUsers, "Id", "Email", booking.userID);
            ViewBag.roomID = new SelectList(db.rooms, "roomID", "roomName", booking.roomID);
            return View(booking);
        }

        // GET: bookings/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.userID = new SelectList(db.AspNetUsers, "Id", "Email", booking.userID);
            ViewBag.roomID = new SelectList(db.rooms, "roomID", "roomName", booking.roomID);
            return View(booking);
        }

        // POST: bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit([Bind(Include = "eventID,eventName,startDate,endDate,userID,roomID")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userID = new SelectList(db.AspNetUsers, "Id", "Email", booking.userID);
            ViewBag.roomID = new SelectList(db.rooms, "roomID", "roomName", booking.roomID);
            return View(booking);
        }

        // GET: bookings/Delete/5        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]        
        public ActionResult DeleteConfirmed(int id)
        {
            booking booking = db.bookings.Find(id);
            db.bookings.Remove(booking);
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
