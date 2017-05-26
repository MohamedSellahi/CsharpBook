namespace MySQL_DBtest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("instructor")]
    public partial class instructor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public instructor()
        {
            advisors = new HashSet<advisor>();
            teaches = new HashSet<teach>();
        }

        [StringLength(15)]
        public string ID { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        [StringLength(20)]
        public string dept_name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? salary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<advisor> advisors { get; set; }

        public virtual department department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teach> teaches { get; set; }
    }
}
