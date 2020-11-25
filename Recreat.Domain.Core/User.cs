using System;

namespace Recreat.Domain.Core
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Female { get; set; }
        public int Growth { get; set; }
        public int Weight { get; set; }
        public DateTime Age { get; set; }
        public string Goal { get; set; }
        public int[] Volumes { get; set; }
        public string Mobility { get; set; }
        public int CaloriesPerDay { get; set; }


    }
}
