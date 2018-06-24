namespace Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LINQExtensions
    {
        public static IEnumerable<float> TotalAvarageSpeedAtEachPerformance(this IEnumerable<float> enumerable)
        {
            var currentValuesAtEachElement = new List<List<float>>();
            using (var enumerator = enumerable.GetEnumerator())
            {
                var previousElems = new List<float>();
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
 