using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTests
{
    public class YearTest
    {
       [Fact]

       public void HaveYear()
       {
                YearGroup tst = new YearGroup();

                tst.Name = "Year 6";
                tst.YearGroupId = 6;

            Assert.Equal("Year 6", tst.Name);
            Assert.Equal(6, tst.YearGroupId);

        }
        
    }
}
