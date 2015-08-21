using System;

namespace MandelbrotCS
{
	public abstract class ComplexMath
	{
		public ComplexMath()
		{
		}

        public static Complex Sum(Complex c1, Complex c2)
        {
            Complex result = new Complex();
            result.a = c1.a + c2.a;
            result.b = c1.b + c2.b;
            return result;
        }

        public static Complex Product(Complex c1, Complex c2)
        {
            Complex result = new Complex();
            result.a = (c1.a * c2.a) + (c1.b * c2.b);
            result.b = (c1.a * c2.b) + (c1.b * c2.a);
            return result;
        }

        public static Complex Square(Complex c1)
        {
            Complex result = new Complex();
            result.a = (c1.a * c1.a) - (c1.b * c1.b);
            result.b = 2*c1.a*c1.b;
            return result;
        }

        public static Complex Subtract(Complex c1, Complex c2)
        {
            Complex result = new Complex();
            result.a = c1.a - c2.a;
            result.b = c1.b - c2.b;
            return result;
        }
	}

    public struct Complex 
    {
        public double a;
        public double b;
    }
}
