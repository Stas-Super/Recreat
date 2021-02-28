using Recreat.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recreat.Infrastructure.Data.DTO
{
    public class RegistrDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
