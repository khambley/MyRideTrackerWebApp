using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyRideTrackerWebApp.Data;

namespace MyRideTrackerWebApp.Models
{
	public class GreaterThanAttribute : ValidationAttribute
	{
		//never got this to work, but kept in project to try again later
		private readonly string testedPropertyName;
		
		public GreaterThanAttribute(string testedPropertyName)
		{
			this.testedPropertyName = testedPropertyName;
			
		}
		public string GetErrorMessage() =>
			$"MileageEnd must be greater than {testedPropertyName}.";

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var propertyTestedInfo = validationContext.ObjectType.GetProperty(this.testedPropertyName);
			if (propertyTestedInfo == null)
			{
				return new ValidationResult(string.Format("Unknown property {0}", this.testedPropertyName));
			}
			var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null); 

			//Compare values
			if ((int)value > (int)propertyTestedValue)
			{
				return ValidationResult.Success; 
			}
			return new ValidationResult(GetErrorMessage());
		}
		
		
	}
}
