using Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Aggregates.UserAggregate.Entities
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string PassWord { get; set; }
        
    }
}
