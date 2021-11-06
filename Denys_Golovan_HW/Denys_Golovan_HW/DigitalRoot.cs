using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace Denys_Golovan_HW
{
    [TestFixture]
    class DigitalRoot
    {
        public int ComputeDigitalRoot(int num)
        {
            num = Math.Abs(num);

            while (num >= 10)
            {
                int sum = 0;
                int copy = num;
                while (copy != 0)
                {
                    sum += copy % 10;
                    copy /= 10;
                }
                num = sum;
            }
            return num;
        }

        [TestCase(4, 4)]
        [TestCase(942, 6)]
        [TestCase(493193, 2)]
        public void TestDIgitalRoot(int arg, int expected)
        {
            Assert.AreEqual(ComputeDigitalRoot(arg), expected);
        }
    }
}
