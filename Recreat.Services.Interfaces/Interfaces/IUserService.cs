using Recreat.Domain.Core;
using Recreat.Infrastructure.Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recreat.Services.Interfaces.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Login(LoginDTO login);
        Task<UserDTO> Registr(RegistrDTO registr);
    }
}
