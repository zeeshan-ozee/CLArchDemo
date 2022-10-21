using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Interfaces;
using CLArch.Domain.Entities.Authentication;
using Microsoft.Extensions.Logging;

namespace CLArch.Persistance
{
    public class UserRepository : IUserRepository //GenericRepository<User>,
    {
        // public UserRepository(ApplicationContext context, ILogger logger) : base(context, logger) { }

        readonly static List<User> _users = new();
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }
    }
}