using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.UnitTests
{
    public class BookingTestDataDriven : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { DateTime.Today.AddDays(11), DateTime.Today.AddDays(22), false };
            yield return new object[] { DateTime.Today.AddDays(15), DateTime.Today.AddDays(25), false };
            yield return new object[] { DateTime.Today.AddDays(20), DateTime.Today.AddDays(30), false };
            yield return new object[] { DateTime.Today.AddDays(21), DateTime.Today.AddDays(30), true };
            yield return new object[] { DateTime.Today.AddDays(25), DateTime.Today.AddDays(35), true };
            yield return new object[] { DateTime.Today.AddDays(41), DateTime.Today.AddDays(50), true };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
