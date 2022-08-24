using System;


namespace Models.Entities
{
    public class YearGroup
    {
        public int YearGroupId { get; set; }
        public string Name { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}

