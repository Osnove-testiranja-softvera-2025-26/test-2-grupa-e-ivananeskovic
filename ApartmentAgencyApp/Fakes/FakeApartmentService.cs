using ApartmentAgencyApp.Models;
using ApartmentAgencyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentAgencyApp.Fakes
{
    public class FakeApartmentService : IApartmentService
    {

        private readonly List<Apartment> _apartment;

        public FakeApartmentService(List<Apartment> apartment)
        {
            _apartment = apartment;
        }
        public List<Apartment> GetAvailableApartments(ReservationRequest request)
        {
           return _apartment;
        }
    }
}
