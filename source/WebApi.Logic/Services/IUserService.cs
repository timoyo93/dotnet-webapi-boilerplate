using System;
using System.Collections.Generic;
using WebApi.Logic.Models;

namespace WebApi.Logic.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetOneUser(Guid userId);
        User AddUser(User userToAdd);
        User UpdateUser(User updatedUser);
        Guid? DeleteUser(Guid userId);
    }
}