using System;
namespace Models.Entities
{
    public class Class
    {
        public string ClassId { get; set; }

        public int SchoolId { get; set; }

        public ICollection<UserClass>? UserClasses { get; set; }
    }
}

