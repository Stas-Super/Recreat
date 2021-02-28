using Recreat.Services.Interfaces.Interfaces;
using Recreat.Infrastructure.Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Recreat.Domain.Core;
using Recreat.Infrastructure.Data.Repositories;
using Microsoft.AspNet.Identity;
using Recreat.Infrastructure.Data.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Recreat.Infrastructure.Business.Services
{
    public class UserService : IUserService
    {
        protected ApplicationDbContext ctx;
        public async Task<UserDTO> Login(LoginDTO login)
        {
            UserRepository userRepository = new UserRepository();
            var user = await userRepository.GetUserByEmail(login.Email);
            if(user != null)
            {
                PasswordHasher hasher = new PasswordHasher();
                var result = hasher.VerifyHashedPassword(user.Password, login.Password);
                if (result.HasFlag(PasswordVerificationResult.Success))
                {
                    return new UserDTO {User = user };
                }
                else
                {
                    return new UserDTO {Result = "Password incorrect", User = null };
                }
            }
            else
            {
                return new UserDTO { Result = "User Not Found", User = null };
            }
        }

        public async Task<UserDTO> Registr(RegistrDTO registr)
        {
            PasswordHasher hasher = new PasswordHasher();
            UserRepository userRepository = new UserRepository();
            var user = await ctx.Users.Where(u => u.Email.Equals(registr.Email)).FirstOrDefaultAsync();
            if (user != null)
            {
                return new UserDTO { Result = "User allready created", User = null };
            }

            var vuser = new User
            {
                FirstName = registr.FirstName,
                LastName = registr.LastName,
                Email = registr.Email,
                Password = hasher.HashPassword(registr.Password),
            };
            return new UserDTO { User = (User)user };
        }
    }
}
