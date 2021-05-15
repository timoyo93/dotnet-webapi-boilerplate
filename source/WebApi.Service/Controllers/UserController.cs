using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApi.Logic.Models;
using WebApi.Logic.Services;

namespace WebApi.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("api/v1")]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    [ProducesResponseType((int) HttpStatusCode.NoContent)]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <inheritdoc />
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        /// <summary>
        /// Returns all stored users
        /// </summary>
        /// <returns></returns>
        [HttpGet("users")]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }
        
        /// <summary>
        /// Returns users for provided userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId:guid}")]
        public ActionResult<User> GetOneUserByUserId([FromRoute] Guid userId)
        {
            var user = _userService.GetOneUser(userId);

            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest($"No User found for userId: {userId}");
        }
        
        /// <summary>
        /// Add a user to memory and returns it
        /// </summary>
        /// <param name="userToAdd"></param>
        /// <returns></returns>
        [HttpPost("user")]
        public ActionResult<User> AddUserToMemory([FromBody] User userToAdd)
        {
            var user = _userService.AddUser(userToAdd);
            return Ok(user);
        }
        
        /// <summary>
        /// Updates a specific user
        /// </summary>
        /// <param name="userToUpdate"></param>
        /// <returns></returns>
        [HttpPut("user")]
        public ActionResult<User> UpdateUserInMemory([FromBody] User userToUpdate)
        {
            var user = _userService.UpdateUser(userToUpdate);
            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest($"No User found for userId: {userToUpdate.UserId}");
        }
        
        /// <summary>
        /// Deletes user for provided userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("user/{userId:guid}")]
        public ActionResult<string> DeleteUserFromMemory([FromRoute] Guid userId)
        {
            var deletedUserId = _userService.DeleteUser(userId);
            if (deletedUserId != null)
            {
                return Ok($"User with userId: {userId} has been deleted!");
            }

            return BadRequest($"No User found for userId: {userId}");
        }
    }
}