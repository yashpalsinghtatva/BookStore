using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreAPI.Data;
using OnlineBookStoreAPI.Models;
using OnlineBookStoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(UserDTO userDTO)
        {
            var token = await _userRepository.Authenticate(userDTO);

            if (token == null)
            {
                return Unauthorized(new { errorMessage = "Invalid Email Or Password"});
            }

            return Ok(token);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            var userId = await _userRepository.AddAuthorAsync(userDTO);

            if (userId > 0)
            {
                userDTO.UserId = userId;
                return Ok(userDTO);
            }
            else if (userId == 0)
            {
                return Conflict(new ClientErrorData() { Title = "User Already Exists" });
            }
            else
            {
                return StatusCode(500);

            }
        }
    }
}
