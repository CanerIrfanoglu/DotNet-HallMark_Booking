namespace roomBooking
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            bookings = new HashSet<booking>();
        }

        public int userID { get; set; }

        [Required]
        [StringLength(12)]
        public string aNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string userName { get; set; }

        [Required]
        [StringLength(15)]
        public string upwd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<booking> bookings { get; set; }
    }
}
