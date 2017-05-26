namespace MySQL_DBtest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class teach
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string course_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(8)]
        public string sec_id { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(6)]
        public string semester { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal year { get; set; }

        public virtual course course { get; set; }

        public virtual instructor instructor { get; set; }
    }
}
