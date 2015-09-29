using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class ArcheologicalSite
    {
        [TestMethod]
        [TestCategory("03_ArcheologicalSite")]
        public void Compute_Building_Area_For_Given_Coordinates() {
            Point A = new Point(0.000000, 0.000000);
            Point B = new Point(1.000000, 1.000000);
            Point C = new Point(0.000000, 1.000000);

            double actualArea = ComputeMinimumArea(A, B, C);

            Assert.AreEqual(1.000000, actualArea);
        }

        [TestMethod]
        [TestCategory("03_ArcheologicalSite")]
        public void Compute_Building_Area_For_Given_Coordinates_2() {
            Point A = new Point(6.000000, 5.000000);
            Point B = new Point(2.000000, 2.000000);
            Point C = new Point(5.000000, 6.000000);

            double actualArea = ComputeMinimumArea(A, B, C);

            Assert.AreEqual(7.000000, actualArea);
        }

        [TestMethod]
        [TestCategory("03_ArcheologicalSite")]
        public void Compute_Building_Area_For_Coordinates_On_The_Same_Line() {
            Point A = new Point(1.000000, 2.000000);
            Point B = new Point(2.000000, 3.000000);
            Point C = new Point(-3.000000, -2.000000);

            double actualArea = ComputeMinimumArea(A, B, C);

            Assert.AreEqual(0.000000, actualArea);
        }

        private double ComputeMinimumArea(Point A, Point B, Point C) {
            double determinant = ComputeDeterminant(A, B, C);
            return determinant;
        }

        private double ComputeDeterminant(Point A, Point B, Point C) {
            double result =  A.x * (B.y - C.y) + B.x * (C.y - A.y) + C.x * (A.y - B.y);
            return (result > 0) ? result : result * (-1);
        }
    }

    public class Point {
        private double v1;
        private double v2;

        public Point(double v1, double v2) {
            this.v1 = v1;
            this.v2 = v2;
        }

        public double x {
            get { return this.v1; }
        }

        public double y {
            get { return this.v2; }
        }
    }
}
