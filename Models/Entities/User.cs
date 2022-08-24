using System;
namespace Models.Entities
{

    public class User
    {
        public Guid UserId { get; set; }

        public int UserTypeId { get; set; }

        public int? YearGroupId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }



        public UserType UserType { get; set; }

        public YearGroup? YearGroup { get; set; }

        public ICollection<UserClass>? UserClasses { get; set; }
    }
}
