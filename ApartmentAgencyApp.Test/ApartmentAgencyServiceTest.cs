
using ApartmentAgencyApp.Exceptions;
using ApartmentAgencyApp.Fakes;
using ApartmentAgencyApp.Models;
using ApartmentAgencyApp.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static ApartmentAgencyApp.Test.Parser;

namespace ApartmentAgencyApp.Test
{
    //example of Guid: 00000000-0000-0000-0000-000000000001
    [TestFixture]
    public class ApartmentAgencyServiceTest
    {
        private FakeApartmentService _fakeApartmentsService;
        private FakeDateCalculationService _fakecalculationService;
        private FakeReservationService _fakeReservationService;

        private ApartmentAgencyService _apartmenAgencyApp;

        [SetUp]
        public void SetUp()
        {
            _fakeApartmentsService = new FakeApartmentService(
               new List<Apartment>()
               {
                new Apartment
                {
                    Id=Guid.Parse("00000000-0000-0000-0000-000000000001")
                }
               });

            _fakecalculationService = new FakeDateCalculationService(new RequestDaysInfo
            {
                NumberOfDays = 10,

                NumberOfSeasonDays = 3
            });
            _fakeReservationService = new FakeReservationService();

            _apartmenAgencyApp = new ApartmentAgencyService(
                _fakecalculationService,
                _fakeApartmentsService,

                _fakeReservationService);

        }

        [TestCaseSource(typeof(PictParser), nameof(PictParser.GetTestCases))]
        public void CalculateApartmentRank_ReturnsExpectedResult(int distanceFromBeach, int percentageOfPositiveReviews, ApartmentType apartmentType, bool renovatedInTheLastYear, ApartmentRank expectedResult)
        {
            ApartmentRank result = _apartmenAgencyApp.CalculateApartmentRank(distanceFromBeach, percentageOfPositiveReviews, apartmentType, renovatedInTheLastYear);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void MakeApartmantReservation_BedOnly_ReturnsComplexA()
        {
            var request = new ReservationRequest
            {
                DistanceFromTheBeach = 799,
                NumberOfBeds = 3,
                ApartmentType = ApartmentType.BedOnly
            };
            var requestDaysInfo = new RequestDaysInfo
            {
                NumberOfDays = 5,
                NumberOfSeasonDays = 4

            };
            var apartment = new Apartment
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                NumberOfBeds = 3

            };
            var availableApartment = new List<Apartment>
            {apartment};

            _fakeApartmentsService = new FakeApartmentService(availableApartment);
            _fakecalculationService = new FakeDateCalculationService(requestDaysInfo);
            _fakeReservationService = new FakeReservationService();

            _apartmenAgencyApp = new ApartmentAgencyService(_fakecalculationService, _fakeApartmentsService, _fakeReservationService);

            _apartmenAgencyApp.MakeApartmentReservation(request);
            Assert.That(_fakeReservationService.Reservations.Count, Is.EqualTo(1));
            Assert.That(_fakeReservationService.Reservations[0].ApartmentComplex, Is.EqualTo(ApartmentComplex.ComplexA));
        }

        [Test]
        public void MakeApartmantReservation_BedOnly_ReturnsComplexB()
        {
            var request = new ReservationRequest
            {
                DistanceFromTheBeach = 799,
                NumberOfBeds = 1,
                ApartmentType = ApartmentType.BedOnly
            };
            var requestDaysInfo = new RequestDaysInfo
            {
                NumberOfDays = 5,
                NumberOfSeasonDays = 4

            };
            var apartment = new Apartment
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                NumberOfBeds = 1

            };
            var availableApartment = new List<Apartment>
            {apartment};

            _fakeApartmentsService = new FakeApartmentService(availableApartment);
            _fakecalculationService = new FakeDateCalculationService(requestDaysInfo);
            _fakeReservationService = new FakeReservationService();

            _apartmenAgencyApp = new ApartmentAgencyService(_fakecalculationService, _fakeApartmentsService, _fakeReservationService);

            _apartmenAgencyApp.MakeApartmentReservation(request);
            Assert.That(_fakeReservationService.Reservations.Count, Is.EqualTo(1));
            Assert.That(_fakeReservationService.Reservations[0].ApartmentComplex, Is.EqualTo(ApartmentComplex.ComplexB));
        }


        [Test]
        public void MakeApartmantReservation_Studio_ReturnsComplexB_NumberOfDays()
        {
            var request = new ReservationRequest
            {
                DistanceFromTheBeach = 799,
                NumberOfBeds = 1,
                ApartmentType = ApartmentType.Studio
            };
            var requestDaysInfo = new RequestDaysInfo
            {
                NumberOfDays = 13,
                NumberOfSeasonDays = 4

            };
            var apartment = new Apartment
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                NumberOfBeds = 1

            };
            var availableApartment = new List<Apartment>
            {apartment};

            _fakeApartmentsService = new FakeApartmentService(availableApartment);
            _fakecalculationService = new FakeDateCalculationService(requestDaysInfo);
            _fakeReservationService = new FakeReservationService();

            _apartmenAgencyApp = new ApartmentAgencyService(_fakecalculationService, _fakeApartmentsService, _fakeReservationService);

            _apartmenAgencyApp.MakeApartmentReservation(request);
            Assert.That(_fakeReservationService.Reservations.Count, Is.EqualTo(1));
            Assert.That(_fakeReservationService.Reservations[0].ApartmentComplex, Is.EqualTo(ApartmentComplex.ComplexB));
        }

        [Test]
        public void MakeApartmantReservation_Studio_ReturnsComplexB_NumberOfSeasonDays()
        {
            var request = new ReservationRequest
            {
                DistanceFromTheBeach = 799,
                NumberOfBeds = 1,
                ApartmentType = ApartmentType.Studio
            };
            var requestDaysInfo = new RequestDaysInfo
            {
                NumberOfDays = 11,
                NumberOfSeasonDays = 10

            };
            var apartment = new Apartment
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                NumberOfBeds = 1

            };
            var availableApartment = new List<Apartment>
            {apartment};

            _fakeApartmentsService = new FakeApartmentService(availableApartment);
            _fakecalculationService = new FakeDateCalculationService(requestDaysInfo);
            _fakeReservationService = new FakeReservationService();

            _apartmenAgencyApp = new ApartmentAgencyService(_fakecalculationService, _fakeApartmentsService, _fakeReservationService);

            _apartmenAgencyApp.MakeApartmentReservation(request);
            Assert.That(_fakeReservationService.Reservations.Count, Is.EqualTo(1));
            Assert.That(_fakeReservationService.Reservations[0].ApartmentComplex, Is.EqualTo(ApartmentComplex.ComplexB));
        }

        [Test]
        public void MakeApartmantReservation_Studio_ReturnsComplexC_NumberOfSeasonDays_NumberOfSeasonsDay()
        {
            var request = new ReservationRequest
            {
                DistanceFromTheBeach = 799,
                NumberOfBeds = 1,
                ApartmentType = ApartmentType.Studio
            };
            var requestDaysInfo = new RequestDaysInfo
            {
                NumberOfDays = 12,
                NumberOfSeasonDays = 9

            };
            var apartment = new Apartment
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                NumberOfBeds = 1

            };
            var availableApartment = new List<Apartment>
            {apartment};

            _fakeApartmentsService = new FakeApartmentService(availableApartment);
            _fakecalculationService = new FakeDateCalculationService(requestDaysInfo);
            _fakeReservationService = new FakeReservationService();

            _apartmenAgencyApp = new ApartmentAgencyService(_fakecalculationService, _fakeApartmentsService, _fakeReservationService);

            _apartmenAgencyApp.MakeApartmentReservation(request);
            Assert.That(_fakeReservationService.Reservations.Count, Is.EqualTo(1));
            Assert.That(_fakeReservationService.Reservations[0].ApartmentComplex, Is.EqualTo(ApartmentComplex.ComplexC));
        }
    

     public void MakeApartmantReservation_Studio_ReturnsComplexD()
        {
            var request = new ReservationRequest
            {
                DistanceFromTheBeach = 300,
                NumberOfBeds = 3,
                ApartmentType = ApartmentType.StudioWithTerrace
            };
            var requestDaysInfo = new RequestDaysInfo
            {
                NumberOfDays = 10,
                NumberOfSeasonDays = 7

            };
            var apartment = new Apartment
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                NumberOfBeds = 3

            };
            var availableApartment = new List<Apartment>
            {apartment};

            _fakeApartmentsService = new FakeApartmentService(availableApartment);
            _fakecalculationService = new FakeDateCalculationService(requestDaysInfo);
            _fakeReservationService = new FakeReservationService();

            _apartmenAgencyApp = new ApartmentAgencyService(_fakecalculationService, _fakeApartmentsService, _fakeReservationService);

            _apartmenAgencyApp.MakeApartmentReservation(request);
            Assert.That(_fakeReservationService.Reservations.Count, Is.EqualTo(1));
            Assert.That(_fakeReservationService.Reservations[0].ApartmentComplex, Is.EqualTo(ApartmentComplex.ComplexD));
        }

        [Test]
        public void Makereservation_Exception_Substitutes()
        {
            var request = new ReservationRequest
            {
                DistanceFromTheBeach = 400,
                NumberOfBeds = 2,
                ApartmentType = ApartmentType.BedOnly
            };

            var apartment = new Apartment
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                NumberOfBeds = 2,
            };

            var requestDaysInfo = new RequestDaysInfo
            {
                NumberOfDays = 2,
                NumberOfSeasonDays = 1
            };

            var availableApartment = new List<Apartment>();

            var calculationService = Substitute.For<IDateCalculationService>();
            var apartmentService = Substitute.For<IApartmentService>();
            var reservationService = Substitute.For<IReservationService>();

            calculationService
            .GetDaysInfo(request.DateOfArrival, request.DateOfDeparture)
            .Returns(requestDaysInfo);

            apartmentService
           .GetAvailableApartments(request)
           .Returns(availableApartment);

            var service = new ApartmentAgencyService(
                calculationService,
                apartmentService,
                reservationService);

            Assert.That((Action)(() => service.MakeApartmentReservation(request)),
            Throws.TypeOf<NoAvailableApartmentsException>());

        }
    }
}