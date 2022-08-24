using System;
namespace Models.Entities
{
    public class UserClass
    {
        
            public Guid UserId { get; set; }
            public string ClassId { get; set; }
            public int SchoolId { get; set; }

            public User? User { get; set; }
            public Class? Class { get; set; }
        
    }
}

