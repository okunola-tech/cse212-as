// Arrays.cs
using System;
using System.Collections.Generic;

public class Arrays
{
    // Part 1: MultiplesOf function
    // Plan:
    // 1. Create a double array of size equal to the number of multiples (numMultiples).
    // 2. Use a for loop starting from 1 to numMultiples.
    // 3. For each iteration i, calculate the multiple as startingNumber * i and store it in the array at index i-1.
    // 4. Return the array.
    public static double[] MultiplesOf(double startingNumber, int numMultiples)
    {
        double[] multiples = new double[numMultiples];
        for (int i = 1; i <= numMultiples; i++)
        {
            multiples[i - 1] = startingNumber * i;
        }
        return multiples;
    }

    // Part 2: RotateListRight function
    // Plan:
    // 1. Calculate the effective rotation amount using modulo, but since amount is guaranteed to be between 1 and data.Count, we can proceed directly.
    // 2. Use GetRange to get the last 'amount' elements: data.GetRange(data.Count - amount, amount)
    // 3. Use GetRange to get the first (data.Count - amount) elements: data.GetRange(0, data.Count - amount)
    // 4. Clear the original list.
    // 5. Add the last part to the list first using AddRange.
    // 6. Then add the first part using AddRange.
    // This will rotate the list to the right by 'amount' positions.
    public static void RotateListRight(List<int> data, int amount)
    {
        List<int> lastPart = data.GetRange(data.Count - amount, amount);
        List<int> firstPart = data.GetRange(0, data.Count - amount);
        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}