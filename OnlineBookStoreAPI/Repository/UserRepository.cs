using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineBookStoreAPI.Data;
using OnlineBookStoreAPI.Helpers;
using OnlineBookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly BookStoreContext _dbContext;
        private readonly IConfiguration _iconfiguration;
        public UserRepository(BookStoreContext dbContext, IMapper mapper, IConfiguration iconfiguration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _iconfiguration = iconfiguration;
        }
        public async Task<int> AddAuthorAsync(UserDTO userDTO)
        {
            try
            {
                if (!await CheckUserEmailExist(userDTO))
                {
                    var user = _mapper.Map<User>(userDTO);
                    _dbContext.Users.Add(user);
                    await _dbContext.SaveChangesAsync();
                    return user.UserId;
                }
                else
                {
                    //if user exist
                    return 0;
                }
            }
            catch (Exception ex)
            {
                //if error occurs
                return -1;
            }
        }

        public async Task<bool> CheckUserEmailExist(UserDTO userDTO)
        {
            return await _dbContext.Users.AnyAsync(x => x.UserEmail.Equals(userDTO.UserEmail));
        }

        public async Task<Tokens> Authenticate(UserDTO userDTO)
        {
            var user = await _dbContext.Users.Include(x=>x.UserType).Where(x => x.UserEmail.Equals(userDTO.UserEmail) && x.Password.Equals(userDTO.Password) && x.UserTypeId == userDTO.UserTypeId).FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, user.UserName),
             new Claim("UserId", user.UserId.ToString()),
             new Claim(ClaimTypes.Role, user.UserType.UserTypeName)
              }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };

        }
        
        private string CreateRT()
        {
            var randomNumber = new byte[32];
            using (var generator = new RNGCryptoServiceProvider())
            {
                generator.GetBytes(randomNumber);
                string token = Convert.ToBase64String(randomNumber);
                return token;
            }
        }
    }
}
