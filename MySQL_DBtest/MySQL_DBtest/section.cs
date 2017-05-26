namespace MySQL_DBtest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("section")]
    public partial class section
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public section()
        {
            takes = new HashSet<take>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string course_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string sec_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(6)]
        public string semester { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal year { get; set; }

        [StringLength(15)]
        public string building { get; set; }

        [StringLength(7)]
        public string room_number { get; set; }

        [StringLength(4)]
        public string time_slot_id { get; set; }

        public virtual classroom classroom { get; set; }

        public virtual course course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<take> takes { get; set; }
    }
}
