using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;
namespace Denys_Golovan_HW
{
    [TestFixture]
    class ListFilterer
    {
        public List<int> GetIntegersFromList(List<object> lst)
        {
            return lst.Where(elem => elem.GetType() == typeof(int)).Select(e => Convert.ToInt32(e)).ToList();
        }
        [Test]
        public void testIntegersFromList1()
        {
            Assert.AreEqual(GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b' }), new List<int>() { 1, 2 });
        }
        [Test]
        public void testIntegersFromList2()
        {
            Assert.AreEqual(GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b', 0, 15}), new List<int>() { 1, 2, 0, 15 });
        }

    }
}
