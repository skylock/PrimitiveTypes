using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PrimitiveTypes
{
    [TestClass]
    public class Meteo
    {
        [TestMethod]
        [TestCategory("14_Weather_Station")]
        public void Test_Add_New_Daily_Reading() {
            ReadingsList readingsList = new ReadingsList();

            readingsList.Add(21.73);

            double reading = readingsList.GetReading(0);

            Assert.AreEqual(21.73, reading);
        }

        [TestMethod]
        [TestCategory("14_Weather_Station")]
        public void Test_Add_A_List_Of_Daily_Readings() {
            var readings = new List<double> { -5, -10, 0.23, 12.53, 17.05 };
            
            ReadingsList readingsList = new ReadingsList();

            readingsList.Add(readings);

            double reading = readingsList.GetReading(4);

            Assert.AreEqual(17.05, reading);
        }

        [TestMethod]
        [TestCategory("14_Weather_Station")]
        public void Test_Average_Of_Daily_Readings() {
            var readings = new List<double> { 7.15, 10, 9.23, 12.53, 17.05 };

            ReadingsList readingsList = new ReadingsList();

            readingsList.Add(readings);

            double average = readingsList.AverageTemperature;

            Assert.AreEqual(11.192, average, 3);
        }

        [TestMethod]
        [TestCategory("14_Weather_Station")]
        public void Test_Minimum_Temperature_Of_Daily_Readings() {
            var readings = new List<double> { 10, 9.23, 12.53, 7.15, 17.05 };

            ReadingsList readingsList = new ReadingsList();

            readingsList.Add(readings);

            double minimumTemperature = readingsList.MinimumTemperature;

            Assert.AreEqual(7.15, minimumTemperature);
        }

        [TestMethod]
        [TestCategory("14_Weather_Station")]
        public void Test_Maximum_Temperature_Of_Daily_Readings() {
            var readings = new List<double> { 10, 9.23, 12.53, 7.15, 17.05 };

            ReadingsList readingsList = new ReadingsList();

            readingsList.Add(readings);

            double maximumTemperature = readingsList.MaximumTemperature;

            Assert.AreEqual(17.05, maximumTemperature);
        }

        [TestMethod]
        [TestCategory("14_Weather_Station")]
        public void Test_Maximum_Temperature_Difference_Of_Daily_Readings() {
            var readings = new List<double> { 10, 9.23, 12.53, 7.15, 17.05 };

            ReadingsList readingsList = new ReadingsList();

            readingsList.Add(readings);

            double maximumTemperature = readingsList.MaximumDiference;

            Assert.AreEqual(9.9, maximumTemperature);
        }
    }

    public struct ReadingsList 
    {
        private static List<double> dailyReadings = new List<double>();

        public void Add(double temperature) {
            dailyReadings.Add(temperature);
        }

        public void Add(List<double> temperatures) {
            foreach (var value in temperatures) dailyReadings.Add(value);
        }

        public double GetReading(uint day) {
            ValidateInput(day);
            return dailyReadings[(int)day];
        }

        private static void ValidateInput(uint day) {
            if (day > dailyReadings.Count) throw new ArgumentException("Requested reading is not in list.");
        }

        public double AverageTemperature {
            get 
            {
                double sum = 0;
                foreach (var value in dailyReadings) {
                    sum += value;
                }
                return sum / dailyReadings.Count;
            }
        }

        public int Readings {
            get {
                return dailyReadings.Count;
            }
        }


        public double MinimumTemperature
        {
            get 
            {
                double[] result = dailyReadings.ToArray();
                return result.Min();
            }
        }

        public double MaximumTemperature
        {
            get {
                double[] result = dailyReadings.ToArray();
                return result.Max();
            }
        }

        public double MaximumDiference 
        {
            get 
            {
                return this.MaximumTemperature - this.MinimumTemperature;
            }
        }
    }
}
