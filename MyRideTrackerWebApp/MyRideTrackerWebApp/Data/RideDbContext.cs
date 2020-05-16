using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRideTrackerWebApp.Models;

namespace MyRideTrackerWebApp.Data
{
	public class RideDbContext : DbContext
	{
		public RideDbContext (DbContextOptions<RideDbContext> options) : base(options) { }

		public DbSet<Ride> Rides { get; set; }
	}
}
