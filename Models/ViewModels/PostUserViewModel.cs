using System;
using Models.Entities;

namespace Models.ViewModels
{
    public class PostUserViewModel
    {
        public User User { get; set; }
        public List<UserType> UserTypeList { get; set; }
        public List<YearGroup> YearGroupList { get; set; }
    }
}

