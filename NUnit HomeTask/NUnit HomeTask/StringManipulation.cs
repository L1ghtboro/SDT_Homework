using NUnit.Framework;
using System.Linq;

public class StringManipulation
{
    public static char FirstNonRepeatingLetter(string input)
    {
        foreach (char c in input)
        {
            if (input.ToUpper().Count(char.ToUpper, c) == 1)
            {
                return c;
            }
        }

        return '\0';
    }
}

public class StringManipulationTests
{
    [Test]
    public void FirstNonRepeatingLetter_ShouldReturnFirstNonRepeatingCharacter()
    {
        string input = "stress";
        char expected = 't';

        char result = StringManipulation.FirstNonRepeatingLetter(input);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void FirstNonRepeatingLetter_ShouldReturnCorrectCase()
    {
        string input = "sTreSS";
        char expected = 'T';

        char result = StringManipulation.FirstNonRepeatingLetter(input);

        Assert.AreEqual(expected, result);
    }
}