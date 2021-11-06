using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace Denys_Golovan_HW
{

    [TestFixture]
    class CountPairs
    {
        public int Count(int[] arr, int target)
        {
            int count = 0;

            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == target)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        [TestCase(new int[]{1, 3, 6, 2, 2, 0, 4, 5}, 5, 4)]
        [TestCase(new int[] {1, 2, 3 }, 3,1)]
        public void TestCount(int[] arg, int target, int expected)
        {
            Assert.AreEqual(Count(arg, target), expected);
        }
    }
}
