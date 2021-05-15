using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Logic.Models;

namespace WebApi.Logic.Services
{
    public class UserService : IUserService
    {
        private List<User> _userList;

        public UserService()
        {
            _userList = new List<User>
            {
                new User
                {
                    UserId = Guid.NewGuid(),
                    Firstname = "Jon",
                    Lastname = "Doe"
                },
                new User
                {
                    UserId = Guid.NewGuid(),
                    Firstname = "Stan",
                    Lastname = "Marsh"
                }
            };
        }

        public List<User> GetAllUsers()
        {
            return _userList;
        }

        public User GetOneUser(Guid userId)
        {
            try
            {
                var user = _userList.First(u => u.UserId == userId);
                return user;
            }
            catch
            {
                return null;
            }
        }

        public User AddUser(User userToAdd)
        {
            _userList.Add(userToAdd);
            return userToAdd;
        }

        public User UpdateUser(User updatedUser)
        {
            var userFound = false;
            for (var index = _userList.Count - 1; index >= 0; index--)
            {
                if (_userList[index].UserId != updatedUser.UserId) continue;
                _userList[index] = updatedUser;
                userFound = true;
            }

            return userFound ? updatedUser : null;
        }

        public Guid? DeleteUser(Guid userId)
        {
            var userFound = false;
            for (var index = _userList.Count - 1; index >= 0; index--)
            {
                if (_userList[index].UserId != userId) continue;
                _userList.RemoveAt(index);
                userFound = true;
            }
            
            return userFound ? userId : null;
        }
    }
}