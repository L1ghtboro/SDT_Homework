using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public class ListFilterer
{
    public static List<int> GetIntegersFromList(List<object> mixedList)
    {
        return mixedList.OfType<int>().ToList();
    }
}

public class ListFiltererTests
{
    [Test]
    public void GetIntegersFromList_ShouldReturnOnlyIntegers()
    {
        List<object> mixedList = new List<object>() { 1, 2, 'a', 'b' };
        List<int> expected = new List<int>() { 1, 2 };

        List<int> result = ListFilterer.GetIntegersFromList(mixedList);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void GetIntegersFromList_ShouldReturnAllIntegers()
    {
        List<object> mixedList = new List<object>() { 1, 2, 'a', 'b', 0, 15 };
        List<int> expected = new List<int>() { 1, 2, 0, 15 };

        List<int> result = ListFilterer.GetIntegersFromList(mixedList);

        Assert.AreEqual(expected, result);
    }
}