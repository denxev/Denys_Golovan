using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;
namespace Denys_Golovan_HW
{
    class Person
    {
        public string FirstName { get; set; }
        public string LasName { get; set; }
        public Person(string str)
        {
            var s = str.Split(":");
            FirstName = s[0].ToUpper();
            LasName = s[1].ToUpper();
        }

        public override string ToString()
        {
            return $"({LasName}, {FirstName})";
        }
    }

    [TestFixture]
    class NameConverter
    {
        public string ConvertNames(string s)
        {
            return String.Join("" ,s.Split(";").Select(elem => new Person(elem)).OrderBy(elem => elem.LasName).ThenBy(elem => elem.FirstName).Select(e => e.ToString()).ToArray());
        }

        [TestCase("Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill", "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)")]
        [TestCase("Wilfred:Corwill;Fired:Corwill", "(CORWILL, FIRED)(CORWILL, WILFRED)")]
        public void TestConvert(string arg, string expected)
        {
            Assert.AreEqual(expected, ConvertNames(arg), message:ConvertNames(arg));
        }
    }
}
