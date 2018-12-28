namespace roomBooking
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Security;
    

    public partial class booking
    {
        [Key]
        public int eventID { get; set; }

        [Required]
        [StringLength(30)]
        public string eventName { get; set; }

        [Display(Name = "Start Date and Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
        [DataType(DataType.DateTime)]
        public DateTime startDate { get; set; }

        [Display(Name = "End Date and Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
        [BookingValidate]
        [DataType(DataType.DateTime)]
        public DateTime endDate { get; set; }

        [StringLength(128)]
        public string userID { get; set; }

        public int? roomID { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual room room { get; set; }
    }
}
