using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class GuestList
{
    public static string Meeting(string s)
    {
        List<string> guests = s.ToUpper().Split(';').ToList();

        guests.Sort((x, y) =>
        {
            string[] name1 = x.Split(':');
            string[] name2 = y.Split(':');

            int result = name1[1].CompareTo(name2[1]);

            if (result == 0)
            {
                result = name1[0].CompareTo(name2[0]);
            }

            return result;
        });

        return string.Join("", guests.Select(guest =>
        {
            string[] name = guest.Split(':');
            return $"({name[1]}, {name[0]})";
        }));
    }
}

public class GuestListTests
{
    [Test]
    public void Meeting_ShouldReturnSortedGuestList()
    {
        string input = "Fired:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
        string expected = "(CORWILL, ALFRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";

        string result = GuestList.Meeting(input);

        Assert.AreEqual(expected, result);
    }
}