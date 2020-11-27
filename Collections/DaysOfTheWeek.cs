using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    /// <summary>
    /// This is a non-generic collection
    /// </summary>
    public class DaysOfTheWeekCollection : IEnumerable
    {
        private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < days.Length; index++)
            {
                // Yield each day of the week.
                yield return days[index];
            }
        }
    }
}
