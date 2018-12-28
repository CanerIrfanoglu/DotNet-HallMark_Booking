namespace roomBooking
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        [BookingValidate]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
        [DataType(DataType.DateTime)]
        public DateTime endDate { get; set; }

        public int? userID { get; set; }

        public int? roomID { get; set; }

        public virtual room room { get; set; }

        public virtual user user { get; set; }
    }
}
