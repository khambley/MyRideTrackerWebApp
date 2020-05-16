using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRideTrackerWebApp.Models
{
	public class Ride
	{
		public int RideId { get; set; }
		[DataType(DataType.Date)]
		public DateTime RideDate { get; set; }
		public decimal RideDistance { get; set; }
		public string RideRoute { get; set; }
		public string RideDescription { get; set; }

	}
}
