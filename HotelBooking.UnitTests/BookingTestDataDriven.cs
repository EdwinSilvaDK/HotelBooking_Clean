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
            yield return new object[] { DateTime.Today.AddDays(1), DateTime.Today.AddDays(9), true };
            yield return new object[] { DateTime.Today.AddDays(9), DateTime.Today.AddDays(11), false };
            yield return new object[] { DateTime.Today.AddDays(11), DateTime.Today.AddDays(19), false };
            yield return new object[] { DateTime.Today.AddDays(19), DateTime.Today.AddDays(21), false };
            yield return new object[] { DateTime.Today.AddDays(21), DateTime.Today.AddDays(30), true };
            yield return new object[] { DateTime.Today.AddDays(10), DateTime.Today.AddDays(11), false };
            yield return new object[] { DateTime.Today.AddDays(19), DateTime.Today.AddDays(20), false };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
