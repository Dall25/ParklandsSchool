using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTests
{
    public class NameTest
    {
        [Fact]
      
        public void HaveName()
        {
            User sut = new User();

            sut.FirstName = "Luke";
            sut.LastName = "Dallimore";

            Assert.Equal("Luke", sut.FirstName);
            Assert.Equal("Dallimore", sut.LastName);
        }
    }
}
