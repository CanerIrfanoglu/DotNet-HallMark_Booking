using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using roomBooking;


namespace roomBooking
{
    public class BookingValidate : ValidationAttribute
    {

        private SqlSchema db = new SqlSchema();
        protected override ValidationResult IsValid(object value,
                    ValidationContext validationContext)
        {
            booking Booking = (booking)validationContext.ObjectInstance;

            DateTime endDateTime = (DateTime)value;
            DateTime startDateTime = (DateTime)Booking.startDate;

            int result = DateTime.Compare(endDateTime, startDateTime);

            if (result < 0)
            {
                return new ValidationResult("End Date and Time cannot be earlier than Start Date and Time");
            }
            else if (result == 0)
            {
                return new ValidationResult("End Date and Time cannot be the same as Start Date and Time");
            }

            int result2 = DateTime.Compare(endDateTime.AddHours(-4), startDateTime);

            if (result2 > 0)
            {
                return new ValidationResult("End Date and Time cannot be more than 4 Houtrs after Start Date and Time");
            }

            string query = "SELECT * FROM bookings WHERE startDate >= " + startDateTime + "AND endDate <= " + endDateTime;
            System.Diagnostics.Debug.WriteLine(query);

            var testconflict1 = db.bookings.Where(x => x.startDate < endDateTime & x.endDate >= endDateTime);
            var testconflict2 = db.bookings.Where(x => x.startDate <= startDateTime & x.endDate > startDateTime);
            var testconflict3 = db.bookings.Where(x => x.startDate <= startDateTime & x.endDate >= endDateTime);
            var testconflict4 = db.bookings.Where(x => x.startDate > startDateTime & x.endDate < endDateTime);

            if (testconflict1.Count() != 0 || testconflict2.Count() != 0 || testconflict3.Count() != 0 || testconflict4.Count() != 0)
            {
                return new ValidationResult("Room already booked ");
            }

            DateTime TimeNow = DateTime.Now;
            int result3 = DateTime.Compare(TimeNow, startDateTime);

            if (result3 > 0)
            {
                return new ValidationResult("Start Date and Time is in the past");
            }


            return ValidationResult.Success;
        }
    }
}