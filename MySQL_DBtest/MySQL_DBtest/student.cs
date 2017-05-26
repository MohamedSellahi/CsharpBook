namespace MySQL_DBtest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("student")]
    public partial class student
    {
        [StringLength(15)]
        public string ID { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        [StringLength(20)]
        public string dept_name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? tot_credit { get; set; }

        public virtual advisor advisor { get; set; }

        public virtual department department { get; set; }
    }
}
