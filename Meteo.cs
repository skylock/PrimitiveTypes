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

            double reading = weatherStation.GetReading(0);

            Assert.AreEqual(21.73, reading);
        }

        [TestMethod]
        [TestCategory("14_Weather_Station")]
        public void Test_Add_A_List_Of_Daily_Readings() {
            var readings = new List<double> { -5, -10, 0.23, 12.53, 17.05 };
            
            WeatherStation weatherStation = new WeatherStation();

            weatherStation.AddReading(readings);

            double reading = weatherStation.GetReading(4);

            Assert.AreEqual(17.05, reading);
        }
    }

    public struct WeatherStation 
    {
        private static List<double> dailyReadings = new List<double>();

        public void AddReading(double temperature) {
            dailyReadings.Add(temperature);
        }

        public void AddReading(List<double> temperatures) {
            foreach (var value in temperatures) dailyReadings.Add(value);
        }

        public double GetReading(uint day) {
            ValidateInput(day);
            return dailyReadings[(int)day];
        }

        private static void ValidateInput(uint day) {
            if (day > dailyReadings.Count) throw new ArgumentException("Requested reading not in list.");
        }

        public int Readings {
            get {
                return dailyReadings.Count;
            }
        }

    }
}
