using System;
using System.Collections.Generic;
using HotelBooking.Core;
using HotelBooking.UnitTests.Fakes;
using HotelBooking.WebApi.Controllers;
using Moq;
using Xunit;

namespace HotelBooking.UnitTests
{
    public class BookingManagerTests
    {
        private BookingManager bookingManager;
        private Mock<IRepository<Booking>> fakeBookingRepository;
        private Mock<IRepository<Room>> fakeRoomRepository;
        public BookingManagerTests(){

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

        [Fact]
        public void FindAvailableRoom_StartDateNotInTheFuture_ThrowsArgumentException()
        {
            DateTime date = DateTime.Today;
            Assert.Throws<ArgumentException>(() => bookingManager.FindAvailableRoom(date, date));
        }

        [Fact]
        public void FindAvailableRoom_RoomAvailable_RoomIdNotMinusOne()
        {
            // Arrange
            DateTime date = DateTime.Today.AddDays(1);

            // Act
            int roomId = bookingManager.FindAvailableRoom(date, date);

            // Assert
            Assert.NotEqual(-1, roomId);
        }
    

        [Fact]
        public void CreateBooking_RoomIdIsMoreThanOr0_ReturnsTrue()
        {

            //Arrange
            var booking = new Booking { StartDate = DateTime.Today.AddDays(21), EndDate = DateTime.Today.AddDays(30) };

            //Act
            var isBooked = bookingManager.CreateBooking(booking);

            //Assert
            Assert.True(isBooked);
        }

        [Fact]
        public void CreateBooking_RoomIdIsLessThan0_ReturnsFalse()

        {
            //Arrange
            var booking = new Booking { StartDate = DateTime.Today.AddDays(13), EndDate = DateTime.Today.AddDays(14) };

            //Act
            var isBooked = bookingManager.CreateBooking(booking);

            //Assert
            Assert.False(isBooked);
        }

        [Theory]
        [ClassData(typeof(BookingTestDataDriven))]
        public void CreateBooking_IsRoomAvailable_ExpectedShould(DateTime startDate, DateTime endDate, bool expectedResult)
        {
            // Arrange
            var booking = new Booking{ StartDate = startDate, EndDate = endDate };

            // Act
            var isBooked = bookingManager.CreateBooking(booking);

            // Assert
            Assert.Equal(isBooked, expectedResult);

        }
        
        [Fact]
        public void GetFullyOccupiedDays_EndDateCantBeBeforeStartDate_ArgumentException()
        {
            // Arrange
            var booking = new Booking { StartDate = DateTime.Today.AddDays(3), EndDate = DateTime.Today.AddDays(2) };

            Assert.Throws<ArgumentException>(() => bookingManager.GetFullyOccupiedDates(booking.StartDate, booking.EndDate));
        }


    }
}
