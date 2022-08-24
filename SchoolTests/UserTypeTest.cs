using Models.Entities;
using Xunit;

namespace SchoolTests
{
    public class UserTypeTest
    {
        [Fact]

        public void UserType()
        {
            UserType tst = new UserType();

            tst.Name = "Teacher";
            tst.UserTypeId = 1;


            Assert.Equal("Teacher", tst.Name);
            

        }
    }
}
