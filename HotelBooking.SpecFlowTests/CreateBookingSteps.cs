using HotelBooking.Core;
using System;
using TechTalk.SpecFlow;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace HotelBooking.SpecFlowTests
{
    [Binding]
    public class CreateBookingSteps
    {

        DateTime startDate, endDate;
        bool result;
        private BookingManager bookingManager;
        private Mock<IRepository<Booking>> fakeBookingRepository;
        private Mock<IRepository<Room>> fakeRoomRepository;

        public CreateBookingSteps()
        {

            // Create Test data - Booking
            var bookings = new List<Booking>
            {
                new Booking { Id=1, StartDate=DateTime.Today.AddDays(10), EndDate=DateTime.Today.AddDays(20), IsActive=true, CustomerId=1, RoomId=1 },
                new Booking { Id=2, StartDate=DateTime.Today.AddDays(10), EndDate=DateTime.Today.AddDays(20), IsActive=true, CustomerId=2, RoomId=2 },
            };

            // Creating test data - Room
            var rooms = new List<Room>
            {
                new Room { Id=1, Description="A" },
                new Room { Id=2, Description="B" },
            };

            // Instantiating The Mocked Repositories
            fakeBookingRepository = new Mock<IRepository<Booking>>();
            fakeRoomRepository = new Mock<IRepository<Room>>();

            // Setup both repos needed in the tests
            fakeRoomRepository.Setup(x => x.GetAll()).Returns(rooms);
            fakeBookingRepository.Setup(x => x.GetAll()).Returns(bookings);

            bookingManager = new BookingManager(fakeBookingRepository.Object, fakeRoomRepository.Object);
            
        }

        [Given(@"I have specified the start date to be in (.*) day")]
        public void GivenIHaveSpecifiedTheStartDateToBeInDay(int start)
        {
            startDate = DateTime.Today.AddDays(start);
        }
        
        [Given(@"I have specified the end date to be in (.*) days")]
        public void GivenIHaveSpecifiedTheEndDateToBeInDays(int end)
        {
            endDate = DateTime.Today.AddDays(end);
        }

        [When(@"When the dates have been entered")]
        public void WhenWhenTheDatesHaveBeenEntered()
        {
            var booking = new Booking { StartDate = startDate , EndDate = endDate};
            result = bookingManager.CreateBooking(booking);
        }
        
        [Then(@"the result should return (.*)")]
        public void ThenTheResultShouldReturnTrue(bool expectedResult)
        {
            Assert.Equal(expectedResult, result);
        }
    }
}
