using System;
namespace Models.Entities
{
    public class UserType
    {
        public UserType()
        {
        }

        public int UserTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}

