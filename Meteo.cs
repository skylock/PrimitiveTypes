using System;
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
            WeatherStation weatherStation = new WeatherStation();

            weatherStation.AddReading(21.73);

            double reading = weatherStation.GetReading(1);

            Assert.AreEqual(21.73, reading);
        }
    }

    public struct WeatherStation 
    {
        private static List<double> dailyReadings = new List<double>();

        internal void AddReading(double temperature) {
            dailyReadings.Add(temperature);
        }

        internal double GetReading(uint day) {
            ValidateInput(day);
            return dailyReadings[(int)day - 1];
        }

        private static void ValidateInput(uint day) {
            if (day < 1) throw new ArgumentException("Day minimum value is 1.");
            if (day > dailyReadings.Count) throw new ArgumentException("Requested reading not in list.");
        }

        public int Readings {
            get {
                return dailyReadings.Count;
            }
        }

    }
}
