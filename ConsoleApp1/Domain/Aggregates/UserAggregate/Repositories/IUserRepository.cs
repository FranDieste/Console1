using Domain.Aggregates.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Aggregates.UserAggregate.Repositories
{
   public interface IUserRepository
    {
        void Add(User user);
    }
}
