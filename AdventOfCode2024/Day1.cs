
using System.Diagnostics;

namespace AdventOfCode2024
{
    public class Day1
    {

        private (List<int> LocationIdsLeft, List<int> LocationIdsRight) GetInput()
        {
            var lines = File.ReadAllLines("Day1.Input.txt");
            var locationIdsLeft = new List<int>();
            var locationIdsRight = new List<int>();

            foreach (var line in lines)
            {
                var values = line.Split("   ");
                locationIdsLeft.Add(int.Parse(values[0]));
                locationIdsRight.Add(int.Parse(values[1]));
            }

            return (locationIdsLeft, locationIdsRight);
        }


        [Fact]
        public void Task1()
        {
            var (locationIdsLeft, locationIdsRight) = GetInput();

            locationIdsLeft.Sort();
            locationIdsRight.Sort();

            var distance = CalculateDistances(locationIdsLeft, locationIdsRight).Sum();

             
            Debug.WriteLine($"Day 1, Task 1 answer id: {distance}");
        }

        [Fact] 
        public void Task2()
        {
            var (locationIds1, locationIds2) = GetInput();

            locationIds1.Sort();
            locationIds2.Sort();

            var similarities = CalculateSimilarities(locationIds1, locationIds2).Sum();   

            Debug.WriteLine($"Day 1, Task 2 answer id: {similarities}");
        }

  
        private IEnumerable<int> CalculateSimilarities(List<int> LocationIdsLeft, List<int> LocationIdsRight)
        {
            var locationIdsRightFrequencyLookup = LocationIdsRight
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            foreach (var locationId in LocationIdsLeft)
            {
                if (locationIdsRightFrequencyLookup.TryGetValue(locationId, out var factor))
                {
                    yield return locationId * factor;
                }
            }
        }


        private IEnumerable<int> CalculateDistances(List<int> locationIdsLeft, List<int> locationIdsRight)
        {
            for (int i = 0; i < locationIdsLeft.Count; i++)
            {
               yield return Math.Abs(locationIdsLeft[i] - locationIdsRight[i]);
            }
        }
    }
}