using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace Denys_Golovan_HW
{
    [TestFixture]
    class FirstUniqueLetter
    {
        public string first_non_repeating_letter(string str)
        {
            if (str=="")
            {
                return "";
            }
            Dictionary<char, int> freqmap = new Dictionary<char, int>();
            foreach (char c in str.ToLower().ToCharArray())
            {
                if (!freqmap.Keys.Contains(c))
                {
                freqmap.Add(c, 0);
                }

                freqmap[c] +=  1;
            }
            if (freqmap.Values.Contains(1))
            {
                return str[str.ToLower().IndexOf(freqmap.First(x => x.Value == 1).Key)].ToString();
            }
            return "";
        }

        [TestCase("stress", "t")]
        [TestCase("STRress", "T")]
        public void test_first_non_repeating_letter(string arg, string expected)
        {
            Assert.AreEqual(expected, first_non_repeating_letter(arg));
        }
    }
}
