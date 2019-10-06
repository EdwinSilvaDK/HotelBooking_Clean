using System;
using HotelBooking.Core;
using HotelBooking.UnitTests.Fakes;
using Xunit;

namespace HotelBooking.UnitTests
{
    public class BookingManagerTests
    {
        private IBookingManager bookingManager;

        public BookingManagerTests(){
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
        public void CreateBooking_RoomIdIsMoreThanOr0_ReturnsTrue()
        {

            //Arrange
            var booking = new Booking { StartDate = DateTime.Today.AddDays(20), EndDate = DateTime.Today.AddDays(30) };

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
        // createBooking

        // get fully occupied days

        // utilize data driven testing

    }
}
