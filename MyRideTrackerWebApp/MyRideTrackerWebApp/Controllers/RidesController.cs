using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyRideTrackerWebApp.Controllers
{
    public class RidesController : Controller
    {
        // GET: Rides
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rides/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rides/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Rides/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rides/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Rides/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rides/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}