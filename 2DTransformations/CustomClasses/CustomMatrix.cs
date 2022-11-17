using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTransformations.CustomClasses
{
    public class CustomMatrix
    {
        public CustomMatrix(double x11, double y12, double x21, double y22, double dx, double dy)
        {
            X11 = x11;
            Y12 = y12;
            X21 = x21;  
            Y22 = y22;
            OffsetX = dx;
            OffsetY = dy;
        }

        public double X11 { get; set; }
        public double Y12 { get; set; }
        public double X21 { get; set; }
        public double Y22 { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
        public double Determinant { get { return Determinate(); } }
        public CustomMatrix Identity { 
            get 
            { 
                return _identityMatrix; 
            }
        }
        public bool IsIdentityMatrix
        {
            get
            {
                return CheckIdentity();
            }
        }
        public bool HasInverse { get; }

        public CustomMatrix Multiply(CustomMatrix m1, CustomMatrix m2)
        {
            var matrix = m1 * m2;
            return matrix;
        }

        public void ScaleMatrix(double ScaleX, double ScaleY)
        {
            var m2 = new CustomMatrix(ScaleX, 0, 0, ScaleY, 0, 0);
            var m1 = new CustomMatrix(X11, Y12, X21, Y22, OffsetX, OffsetY);
            _ = m1 * m2;
        }

        public void ScalePrepend(double ScaleX, double ScaleY)
        {
            var m2 = new CustomMatrix(ScaleX, 0, 0, ScaleY, 0, 0);
            var m1 = new CustomMatrix(X11, Y12, X21, Y22, OffsetX, OffsetY);
            _ = m2* m1;
        }

        public CustomMatrix TranslateMatrix(double dx, double dy)
        {
            OffsetX = OffsetX + dx;
            OffsetY = OffsetY + dy;
            return new CustomMatrix(X11, Y12, X21, Y22, OffsetX, OffsetY);
        }

        public void RotateByAngle(double angle)
        {
            var m1 = new CustomMatrix(X11, Y12, X21, Y22, OffsetX, OffsetY);
            var m2 = new CustomMatrix(Math.Cos(angle), Math.Sin(angle), Math.Sin(-angle), Math.Cos(angle), 0, 0);
            _ = m1 * m2;
        }

        public void RotateByPrepend(double angle)
        {
            var m1 = new CustomMatrix(X11, Y12, X21, Y22, OffsetX, OffsetY);
            var m2 = new CustomMatrix(Math.Cos(angle), Math.Sin(angle), Math.Sin(-angle), Math.Cos(angle), 0, 0);
            _ = m2 * m1;
        }

        public void RotateByAngle(double angle, double centerX, double centerY)
        {
            var m1 = new CustomMatrix(X11, Y12, X21, Y22, -centerX, -centerY);
            var m2 = new CustomMatrix(Math.Cos(angle), Math.Sin(angle), Math.Sin(-angle), Math.Cos(angle), 0, 0);
            var m3 = m1 * m2;
            var m4 = new CustomMatrix(X11, Y12, X21, Y22, centerX, centerY);
            _ = m3 * m4;
        }

        public void Skew(double angleX, double angleY)
        {
            var m = new CustomMatrix(X11, Y12, X21, Y22, OffsetX, OffsetY);
            var skewMatrix = new CustomMatrix(1, Math.Tan(angleY), Math.Tan(angleX), 1, 0, 0);
            _ = m * skewMatrix;
        }

        public void SkewPrepend(double angleX, double angleY)
        {
            var m = new CustomMatrix(X11, Y12, X21, Y22, OffsetX, OffsetY);
            var skewMatrix = new CustomMatrix(1, Math.Tan(angleY), Math.Tan(angleX), 1, 0, 0);
            _ = skewMatrix * m;
        }

        private double Determinate()
        {
            return X11*(Y22-0) - Y12*(X21-0);
        }

        public void Inverse()
        {
            double det = Determinate();
            var x11 = X11 / det;
            var y12 = Y12/ det;
            var x21 = X21/det;
            var y22 = Y22 / det;
            var dx = OffsetX / det;
            var dy = OffsetY / det; ;
            var matrix = new CustomMatrix(x11, y12, x21, y22, dx, dy);
        }

        private bool CheckIdentity()
        {
            CustomMatrix _matrix = new CustomMatrix(X11, Y12, X21, Y22, OffsetX, OffsetY);
            if (_identityMatrix == _matrix) return true;
            else return false;
        }

        public static bool operator ==(CustomMatrix m1, CustomMatrix m2)
        {
            bool status = false;
            if (m1.X11 == m2.X11 && m1.Y12 == m2.Y12 && m1.X21 == m2.X21 && m1.Y22 == m2.Y22 && m1.OffsetX == m2.OffsetX && m1.OffsetY == m2.OffsetY) return true;
            return status;
        }

        public static bool operator !=(CustomMatrix m1, CustomMatrix m2)
        {
            bool status = false;
            if (m1.X11 != m2.X11 && m1.Y12 != m2.Y12 && m1.X21 != m2.X21 && m1.Y22 != m2.Y22 && m1.OffsetX != m2.OffsetX && m1.OffsetY != m2.OffsetY) return true;
            return status;
        }

        public static CustomMatrix operator *(CustomMatrix m1, CustomMatrix m2)
        {
            var x11 = (m1.X11 * m2.X11) + (m1.Y12 * m2.X21) + 0;
            var y12 = (m1.X11 * m2.Y12) + (m1.Y12 * m2.Y22) + 0;
            var x21 = (m1.X21 * m2.X11) + (m1.Y22 * m2.X21) + 0;
            var y22 = (m1.X21 * m2.Y12) + (m1.Y22 * m2.Y22) + 0;
            var dx = (m1.OffsetX * m2.X11) + (m1.OffsetY * m2.X21) + m2.OffsetX;
            var dy = (m1.OffsetX * m2.Y12) + (m1.OffsetY * m2.Y22) + m2.OffsetY;
            var matrix = new CustomMatrix(x11, y12, x21, y22, dx, dy);
            return matrix;
        }
        CustomMatrix _identityMatrix = new CustomMatrix(1, 0, 0, 1, 0, 0);
       
    }
}
