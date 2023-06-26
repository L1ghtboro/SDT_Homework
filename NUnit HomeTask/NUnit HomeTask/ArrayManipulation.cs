using NUnit.Framework;

public class ArrayManipulation
{
    public static int CountPairs(int[] arr, int target)
    {
        int count = 0;

        for (int i = 0; i < arr.Length; i++)
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
}

public class ArrayManipulationTests
{
    [Test]
    public void CountPairs_ShouldReturnCorrectNumberOfPairs()
    {
        int[] arr = { 1, 3, 6, 2, 2, 0, 4, 5 };
        int target = 5;
        int expected = 3;

        int result = ArrayManipulation.CountPairs(arr, target);

        Assert.AreEqual(expected, result);
    }
}