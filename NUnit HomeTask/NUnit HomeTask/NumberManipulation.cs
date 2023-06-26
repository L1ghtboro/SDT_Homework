using NUnit.Framework;

public class NumberManipulation
{
    public static int NextBigger(int num)
    {
        char[] digits = num.ToString().ToCharArray();

        for (int i = digits.Length - 2; i >= 0; i--)
        {
            if (digits[i] < digits[i + 1])
            {
                Array.Sort(digits, i + 1, digits.Length - i - 1);
                int swapIndex = Array.FindIndex(digits, i + 1, digits.Length - i - 1, d => d > digits[i]);
                Swap(digits, i, swapIndex);
                return int.Parse(new string(digits));
            }
        }

        return -1;
    }

    private static void Swap(char[] array, int index1, int index2)
    {
        char temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}

public class NumberManipulationTests
{
    [Test]
    public void NextBigger_ShouldReturnNextBiggerNumber()
    {
        int num = 12;
        int expected = 21;

        int result = NumberManipulation.NextBigger(num);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void NextBigger_ShouldReturnNegativeOne()
    {
        int num = 531;
        int expected = -1;

        int result = NumberManipulation.NextBigger(num);

        Assert.AreEqual(expected, result);
    }
}