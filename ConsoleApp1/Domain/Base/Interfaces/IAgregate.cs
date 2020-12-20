using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base.Interfaces
{
    public   interface IAgregate
    {
        public int Version { get; set; }
    }
}
