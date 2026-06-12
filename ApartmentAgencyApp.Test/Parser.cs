using ApartmentAgencyApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentAgencyApp.Test
{
    internal class Parser
    {
        public class PictParser
        {
            private static readonly string PictResultpath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "PictResults.txt");

            public static IEnumerable<TestCaseData> GetTestCases()
            {
                string[] lines = File.ReadAllLines(PictResultpath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split('\t');

                    if (parts.Length < 5)
                        continue;
                    int distanceFromBeach = int.Parse(parts[0].Trim());
                    int percentageOfPositiveReviews = int.Parse(parts[1].Trim());
                    ApartmentType apartmentType = (ApartmentType)Enum.Parse(typeof(ApartmentType), parts[2].Trim());
                    bool renovatedInTheLastYear = bool.Parse(parts[3].Trim());
                    ApartmentRank expectedResult = (ApartmentRank)Enum.Parse(typeof(ApartmentRank), parts[4].Trim());
                    yield return new TestCaseData(
                       distanceFromBeach,
                       percentageOfPositiveReviews,
                       apartmentType,
                       renovatedInTheLastYear,
                       expectedResult)
                       .SetName(
                           $"GetApartmentRank_Distance={distanceFromBeach}_" +
                           $"Reviews={percentageOfPositiveReviews}_" +
                           $"Type={apartmentType}_" +
                           $"Renovated={renovatedInTheLastYear}_" +
                           $"Expected={expectedResult}");
                }
            }
        }
    }
}
