using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRideTrackerWebApp.Models;
using MyRideTrackerWebApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace MyRideTrackerWebApp.Controllers
{
    [Authorize]
    public class SeedController : Controller
    {
        private RideDbContext context;
        public SeedController(RideDbContext ctx) => context = ctx;
        public IActionResult Index()
        {
            ViewBag.Count = context.Rides.Count();

            return View(context.Rides.OrderBy(r => r.RideId).Take(20));
        }
        [HttpPost]
        public IActionResult CreateProductionData()
        {
            ClearData();

            context.Rides.AddRange(new Ride[]
            {
                new Ride
                {
                    //Ride #1
                    RideDate = Convert.ToDateTime("05/21/2020"),
                    RideNumber = 1,
                    MileageStart = 415,
                    MileageEnd = 415,
                    MilesPerGallon = 0,
                    FillUp = true,
                    Gallons = Convert.ToDecimal(2.2),
                    PricePerGallon = Convert.ToDecimal(1.95),
                    RideRoute = "Gas Station Fill Up",
                    RideDescription = "Initial Fill Up and Starting Ride"
                },
                new Ride
                {
                    //Ride #2
                    RideDate = Convert.ToDateTime("05/22/2020"),
                    RideNumber = 2,
                    MileageStart = 415,
                    MileageEnd = 485,
                    TotalMiles = 485 - 415,
                    FillUp = false,
                    RideRoute = "Down to Nielsens, Lake Villa, IL",
                    RideDescription = "Sunny and 80s"
                },
                new Ride
                {
                    //Ride #3
                    RideDate = Convert.ToDateTime("05/22/2020"),
                    RideNumber = 3,
                    MileageStart = 485,
                    MileageEnd = 510,
                    TotalMiles = 510 - 485,
                    FillUp = false,
                    RideRoute = "Thru park with Conner",
                    RideDescription = "3rd Ride"
                },
                new Ride
                {
                    //Ride #4
                    RideDate = Convert.ToDateTime("05/23/2020"),
                    RideNumber = 4,
                    MileageStart = 510,
                    MileageEnd = 530,
                    TotalMiles = 530 - 510,
                    FillUp = true,
                    Gallons = Convert.ToDecimal(2.89),
                    PricePerGallon = Convert.ToDecimal(1.95),
                    MilesPerGallon = Convert.ToDecimal(530 - 415) / Convert.ToDecimal(2.89),
                    RideRoute = "Culvers and thru park with Conner",
                    RideDescription = "4th Ride"
                },
                new Ride
                {
                    //Ride #5
                    RideDate = Convert.ToDateTime("05/24/2020"),
                    RideNumber = 5,
                    MileageStart = 530,
                    MileageEnd = 579,
                    TotalMiles = 579 - 530,
                    FillUp = false,
                    RideRoute = "West of I94 MB loop",
                    RideDescription = "5th Ride"
                },
                new Ride
                {
                    //Ride #6
                    RideDate = Convert.ToDateTime("05/25/2020"),
                    RideNumber = 6,
                    MileageStart = 579,
                    MileageEnd = 600,
                    TotalMiles = 600 - 579,
                    FillUp = true,
                    Gallons = Convert.ToDecimal(1.54),
                    PricePerGallon = Convert.ToDecimal(1.95),
                    MilesPerGallon = Convert.ToDecimal(600 - 530) / Convert.ToDecimal(1.54),
                    RideRoute = "Hwy A to Sturtevant to Home",
                    RideDescription = "6th Ride"

                },
                new Ride
                {
                    //Ride #7
                    RideDate = Convert.ToDateTime("05/26/2020 02:09 PM"),
                    RideNumber = 7,
                    MileageStart = 600,
                    MileageEnd = 629,
                    TotalMiles = 629 - 600,
                    FillUp = false,
                    RideRoute = "Rode down to Nielsons, Lake Villa, IL",
                    RideDescription = "7th Ride"
                },
                new Ride
                {
                    //Ride #8
                    RideDate = Convert.ToDateTime("05/26/2020 04:00 PM"),
                    RideNumber = 8,
                    MileageStart = 630,
                    MileageEnd = 660,
                    TotalMiles = 660 - 630,
                    FillUp = false,
                    RideRoute = "Rode back home from Nielsons, Lake Villa, IL",
                    RideDescription = "8th Ride"
                },
                new Ride
                {
                    //Ride #9
                    RideDate = Convert.ToDateTime("05/26/2020 06:13 PM"),
                    RideNumber = 9,
                    MileageStart = 666,
                    MileageEnd = 667,
                    TotalMiles = 667 - 666,
                    FillUp = false,
                    RideRoute = "Rode to park and back",
                    RideDescription = "9th Ride"
                },
                new Ride
                {
                    //Ride #10
                    RideDate = Convert.ToDateTime("05/27/2020 05:03 PM"),
                    RideNumber = 10,
                    MileageStart = 667,
                    MileageEnd = 672,
                    FillUp = false,
                    TotalMiles = 672 - 667,
                    RideRoute = "Rode around park and back home",
                    RideDescription = "10th Ride"
                },
                new Ride
                {
                    //Ride #11
                    RideDate = Convert.ToDateTime("05/29/2020 09:20 AM"),
                    RideNumber = 11,
                    MileageStart = 672,
                    MileageEnd = 675,
                    FillUp = false,
                    TotalMiles = 675 - 672,
                    RideRoute = "Rode to McD and back home",
                    RideDescription = "11th Ride"
                },
                new Ride
                {
                    //Ride #12
                    RideDate = Convert.ToDateTime("05/29/2020 12:38 PM"),
                    RideNumber = 12,
                    MileageStart = 675,
                    MileageEnd = 681,
                    TotalMiles = 681 - 675,
                    FillUp = false,
                    RideRoute = "Rode to Subway, Walgreens and home",
                    RideDescription = "12th Ride"
                }
            });
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult ClearData()
        {
            context.Database.SetCommandTimeout(System.TimeSpan.FromMinutes(10));
            context.Database.BeginTransaction();
            context.Database.ExecuteSqlRaw("DELETE FROM Rides");
            context.Database.CommitTransaction();
            return RedirectToAction(nameof(Index));


        }
    }
}