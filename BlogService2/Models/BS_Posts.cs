namespace BlogService2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BS_Posts
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Comment { get; set; }

        public Guid PersonId { get; set; }

        public virtual BS_Persons BS_Persons { get; set; }
    }
}
