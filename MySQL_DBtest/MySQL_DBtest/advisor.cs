namespace MySQL_DBtest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("advisor")]
    public partial class advisor
    {
        [Key]
        [StringLength(15)]
        public string student_id { get; set; }

        [StringLength(15)]
        public string instructor_id { get; set; }

        public virtual instructor instructor { get; set; }

        public virtual student student { get; set; }
    }
}
