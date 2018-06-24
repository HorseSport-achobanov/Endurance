namespace Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static IEnumerable<double?> TotalAvarageSpeedAtEachPerformance(this IEnumerable<double?> enumerable)
        {
            var currentValuesAtEachElement = new List<List<double?>>();
            using (var enumerator = enumerable.GetEnumerator())
            {
                var previousElems = new List<double?>();
                while (enumerator.MoveNext())
                {
                    previousElems.Add(enumerator.Current);
                    currentValuesAtEachElement.Add(previousElems);
                }
            }

            return currentValuesAtEachElement
                .Select(l => l.Aggregate((a, b) => (a + b) / 2));
        }
    }
}
 