using ApartmentAgencyApp.Models;
using ApartmentAgencyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentAgencyApp.Fakes
{
    public class FakeDateCalculationService : IDateCalculationService
    {
        private readonly RequestDaysInfo _requestDaysInfo;

        public FakeDateCalculationService(RequestDaysInfo requestDaysInfo)
        {
            _requestDaysInfo = requestDaysInfo;
        }
        public RequestDaysInfo GetDaysInfo(DateTime from, DateTime to)
        {
            return _requestDaysInfo;
        }
    }
}
