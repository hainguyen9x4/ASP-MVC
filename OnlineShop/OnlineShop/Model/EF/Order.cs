namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public long ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public long CustomerID { get; set; }

        [StringLength(50)]
        public string ShipName { get; set; }

        [StringLength(50)]
        public string ShipAddr { get; set; }

        [StringLength(50)]
        public string ShipMail { get; set; }

        [StringLength(50)]
        public string ShipPhone { get; set; }

        public int Status { get; set; }
    }
}
