using Recreat.Domain.Core.Base;
using System;

namespace Recreat.Domain.Core
{
    public class User : Base.BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
