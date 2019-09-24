using System;
using HotelBooking.Core;
using HotelBooking.UnitTests.Fakes;
using Xunit;

namespace HotelBooking.UnitTests
{
    public class BookingManagerTests
    {
        private IBookingManager bookingManager;

        public BookingManagerTests()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);
            IRepository<Booking> bookingRepository = new FakeBookingRepository(start, end);
            IRepository<Room> roomRepository = new FakeRoomRepository();
            bookingManager = new BookingManager(bookingRepository, roomRepository);
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
        public void CreateBooking_RoomIsAvailable_ReturnsTrue()
        {   
            //Arrange
            var booking = new Booking{StartDate = DateTime.Today.AddDays(21), EndDate =  DateTime.Today.AddDays(30)};
            //Act
            var isBooked = bookingManager.CreateBooking(booking);
            //Assert
            Assert.True(isBooked);
        } 
        
        [Fact]
        public void CreateBooking_RoomIsNotAvailable_ReturnsFalse()
        {
            //Arrange
            var booking = new Booking{StartDate = DateTime.Today.AddDays(10), EndDate =  DateTime.Today.AddDays(20)};
            //Act
            var isBooked = bookingManager.CreateBooking(booking);
            //Assert
            Assert.False(isBooked);
        }

        [Fact]
        public void GetFullyOccupiedDates_GivenDates_ReturnsOccupancyDatesList()
        {
            //Arrange
            var startDate = DateTime.Today.AddDays(10);
            var endDate = DateTime.Today.AddDays(20);
            //Act
            var occupancyDatesList = bookingManager.GetFullyOccupiedDates(startDate, endDate);
            //Assert
            Assert.All(occupancyDatesList, n => Assert.NotEmpty(occupancyDatesList));
        }

        [Fact]
        public void GetFullyOccupiedDates_StartDateLaterThanEndDate_ThrowsArgumentException()
        {
            //Arrange
            DateTime startDate = DateTime.Today.AddDays(1);
            DateTime endDate = DateTime.Today;
            //Assert
            //Exception is thrown if the start date is greater than the end date.
            Assert.Throws<ArgumentException>(() => bookingManager.GetFullyOccupiedDates(startDate, endDate));
        }
    }
}
