using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRideTrackerWebApp.Data;
using MyRideTrackerWebApp.Models;

namespace MyRideTrackerWebApp.Controllers
{
    public class RidesController : Controller
    {
        private readonly RideDbContext _context;
        public const int StartingMileage = 415;

        public RidesController(RideDbContext context)
        {
            _context = context;
        }

        // GET: Rides
        public async Task<IActionResult> Index(int? pageNumber)
        {
            ViewBag.InitialStartingMileage = StartingMileage;
            //var model = await _context.Rides
            //    .Select(r => new Ride
            //    {
            //        RideId = r.RideId,
            //        RideDate = r.RideDate,
            //        MileageStart = r.MileageStart,
            //        MileageEnd = r.MileageEnd,
            //        TotalMiles = r.TotalMiles,
            //        FillUp = r.FillUp,
            //        Gallons = r.Gallons,
            //        PricePerGallon = r.PricePerGallon,
            //        MilesPerGallon = r.MilesPerGallon,
            //        RideRoute = r.RideRoute,
            //        RideDescription = r.RideDescription,
            //        ImagePath = r.ImagePath
            //    }).ToListAsync();
            var rides = from r in _context.Rides
                        select r;
            int pageSize = 10;
            return View(await PaginatedList<Ride>.CreateAsync(rides.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Rides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ride = await _context.Rides
                .FirstOrDefaultAsync(m => m.RideId == id);
            if (ride == null)
            {
                return NotFound();
            }

            return View(ride);
        }

        // GET: Rides/Create
        public IActionResult Create()
        {
            var ridesList = _context.Rides.ToList();
            if (ridesList.Count() == 0)
            { 
                ViewBag.Mileage = StartingMileage;
            }
            else
            {
                var prevRideInDb = _context.Rides
                                           .OrderByDescending(r => r.RideId)
                                           .FirstOrDefault();

                ViewBag.Mileage = prevRideInDb.MileageEnd;
            }
            return View();
        }

        // POST: Rides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RideId,RideDate,MileageEnd,FillUp,Gallons,PricePerGallon,MapMiles,RideRoute,RideDescription,ImagePath")] Ride ride)
        {
            var ridesList = _context.Rides.ToList();
            if ( ridesList.Count() == 0)
            {
                ride.MileageStart = StartingMileage;
                ViewBag.Mileage = ride.MileageStart;
            } else
            {
                var prevRideInDb = _context.Rides
                                           .OrderByDescending(r => r.RideId)
                                           .FirstOrDefault();

                ride.MileageStart = prevRideInDb.MileageEnd;
                ViewBag.Mileage = ride.MileageStart;
            }
            if(ride.FillUp == true)
            {
                ride.MilesPerGallon = GetMilesPerGallon();
            }
            
            ride.TotalMiles = ride.MileageEnd - ride.MileageStart;

            if (ModelState.IsValid)
            {
                _context.Add(ride);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ride);
        }

        // GET: Rides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ride = await _context.Rides.FindAsync(id);
            if (ride == null)
            {
                return NotFound();
            }
            
            return View(ride);
        }

        // POST: Rides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RideId,RideDate,MileageStart,MileageEnd,RideRoute,RideDescription")] Ride ride)
        {
            if (id != ride.RideId)
            {
                return NotFound();
            }

            ride.TotalMiles = ride.MileageEnd - ride.MileageStart;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ride);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RideExists(ride.RideId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ride);
        }

        // GET: Rides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ride = await _context.Rides
                .FirstOrDefaultAsync(m => m.RideId == id);
            if (ride == null)
            {
                return NotFound();
            }

            return View(ride);
        }

        // POST: Rides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ride = await _context.Rides.FindAsync(id);
            _context.Rides.Remove(ride);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RideExists(int id)
        {
            return _context.Rides.Any(e => e.RideId == id);
        }
        public decimal? GetMilesPerGallon()
        {
            var fillUpList = _context.Rides
                .OrderByDescending(r => r.RideId)
                .Where(r => r.FillUp == true).ToList();
            
            if (fillUpList.Count() > 1)
            {
                var latestFillUp = fillUpList.ElementAt(0);
                var secondLatestFillUp = fillUpList.ElementAt(1);
                decimal fillUpMiles = latestFillUp.MileageEnd - secondLatestFillUp.MileageEnd;
                decimal? fillUpMilesPerGallon = fillUpMiles / latestFillUp.Gallons;
                return fillUpMilesPerGallon;
            }
            else
                return null;
            
            
            
        }
    }
}
