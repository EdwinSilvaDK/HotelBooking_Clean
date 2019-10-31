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
            yield return new object[] { DateTime.Today.AddDays(1), DateTime.Today.AddDays(9), true }; //Case 1 B&B
            yield return new object[] { DateTime.Today.AddDays(21), DateTime.Today.AddDays(30), true }; //Case 2 A&A
            yield return new object[] { DateTime.Today.AddDays(9), DateTime.Today.AddDays(21), false }; //Case 3 B&A
            yield return new object[] { DateTime.Today.AddDays(9), DateTime.Today.AddDays(10), false }; //Case 4 B&O
            yield return new object[] { DateTime.Today.AddDays(9), DateTime.Today.AddDays(20), false }; //Case 5 B&O
            yield return new object[] { DateTime.Today.AddDays(20), DateTime.Today.AddDays(21), false }; //Case 6 O&A
            yield return new object[] { DateTime.Today.AddDays(10), DateTime.Today.AddDays(21), false }; //Case 7 O&A
            yield return new object[] { DateTime.Today.AddDays(10), DateTime.Today.AddDays(11), false }; //Case 8 O&O
            yield return new object[] { DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), false }; //Case 9 O&O
            yield return new object[] { DateTime.Today.AddDays(19), DateTime.Today.AddDays(20), false }; //Case 10 O&O
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
