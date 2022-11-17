using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStruct
{
    public struct CustomVector
    {
        public CustomVector(double x, double y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public double Length
        {
            get
            {
                return GetLength();
            }
        }
        public double LengthSquared
        {
            get
            {
                return Math.Pow(Length,2);
            }
        }

        public CustomVector AddVector(CustomVector v1, CustomVector v2)
        {
            var x = v1.XCoordinate + v2.XCoordinate;
            var y = v1.YCoordinate + v2.YCoordinate;
            var vectorAddition = new CustomVector(x, y);
            return vectorAddition;
        }

        public CustomVector SubtractVector(CustomVector v1, CustomVector v2)
        {
            var x = v1.XCoordinate - v2.XCoordinate;
            var y = v1.YCoordinate - v2.YCoordinate;
            var vector = new CustomVector(x, y);
            return vector;
        }

        public double Multiply(CustomVector v1, CustomVector v2)
        {
            var result = (v1.XCoordinate * v2.XCoordinate) + (v1.YCoordinate * v2.YCoordinate); 
            return result;
        }

        public CustomVector Multiply(CustomVector v1, double scalar)
        {
            var x = scalar * v1.XCoordinate;
            var y = scalar * v1.YCoordinate;
            return new CustomVector(x, y);
        }

        public CustomVector DivideByScalar(CustomVector v1, double scalar)
        {
            var x = v1.XCoordinate / scalar;
            var y = v1.YCoordinate / scalar;
            return new CustomVector(x, y); 
        }

        public double Angle(CustomVector v1, CustomVector v2)
        {
            var theta = (Math.Atan(v2.YCoordinate/v2.XCoordinate) - (Math.Atan(v1.YCoordinate/v1.XCoordinate)) * 180) / Math.PI;
            return theta;
        }

        private double GetLength()
        {
            var len = Math.Sqrt(Math.Pow(XCoordinate,2) + Math.Pow(YCoordinate,2));
            return len;
        }

        public void Normalize()
        {
            var originalLength = Length;
            XCoordinate = XCoordinate / originalLength;
            YCoordinate = YCoordinate / originalLength;
        }
    }
}
