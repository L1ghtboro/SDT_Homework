using NUnit.Framework;

public class DigitManipulation
{
    public static int DigitalRoot(int number)
    {
        while (number > 9)
        {
            int sum = 0;

            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            number = sum;
        }

        return number;
    }
}

public class DigitManipulationTests
{
    [Test]
    public void DigitalRoot_ShouldReturnDigitalRoot()
    {
        int number = 16;
        int expected = 7;

        int result = DigitManipulation.DigitalRoot(number);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void DigitalRoot_ShouldReturnDigitalRootWithLargerNumber()
    {
        int number = 493193;
        int expected = 2;

        int result = DigitManipulation.DigitalRoot(number);

        Assert.AreEqual(expected, result);
    }
}