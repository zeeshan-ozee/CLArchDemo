using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Domain.Entities.Authentication;

namespace CLArch.Application.Interfaces
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void AddUser(User user);
    }
}