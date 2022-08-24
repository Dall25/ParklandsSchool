using System;
using Data;

namespace Services.Implementation
{
    public class BaseService
    {
        protected readonly ParklandsSchoolContext _parklandsSchoolContext;
        
        public BaseService(ParklandsSchoolContext parklandsSchoolContext)
        {
            _parklandsSchoolContext = parklandsSchoolContext;
        }


    }

}

