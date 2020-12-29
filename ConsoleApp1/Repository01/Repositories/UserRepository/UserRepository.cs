using Domain.Aggregates.UserAggregate.Entities;
using Domain.Aggregates.UserAggregate.Repositories;
using Repository01.Repositories.Base.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository01.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private IApplicationDbContext _context;
        public UserRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);

              //_context.Users.FirstOrDefault(u=>u.)

          
        }
    }
}
