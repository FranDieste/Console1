using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Aggregates.BookAggregate.Configuration
{
    [Table("tables", Schema ="sys")]
    public sealed class SysTables
    {
        [Key]
        public int object_id { get; set; }
        public string name { get; set; }
    }
}
