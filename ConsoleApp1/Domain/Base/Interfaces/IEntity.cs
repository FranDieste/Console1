using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base.Interfaces
{
     public  interface IEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string UserCode { get; set; }

    }
}
