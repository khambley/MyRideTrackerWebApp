using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyRideTrackerWebApp.Models
{
	public class Ride
	{
		public int RideId { get; set; }
		[DataType(DataType.Date)]
		public DateTime RideDate { get; set; }
		//TODO: make this a decimal to support other user's odometers, mine rounds to the nearest int
		public int MileageStart { get; set; }
		//TODO: make this a decimal to support other user's odometers, mine rounds to the nearest int
		public int MileageEnd { get; set; }
		//TODO: make this a decimal to support other user's odometers, mine rounds to the nearest int
		public int TotalMiles { get; set; }
		public bool FillUp { get; set; }

		[Column(TypeName = "decimal(8, 2)")]
		public decimal Gallons { get; set; }

		[Column(TypeName = "decimal(8, 2)")]
		public decimal PricePerGallon { get; set; }

		[Column(TypeName = "decimal(8, 2)")]
		public decimal MapMiles { get; set; }
		public string RideRoute { get; set; }
		public string RideDescription { get; set; }
		public string ImagePath { get; set; }


	}
}
