using Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Aggregates.BookAggregate.Entities
{
   public class Chapter:IEntity
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string UserCode { get; set; }
    }
}
