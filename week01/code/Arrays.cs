public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // Step 1: Create a new double array of size 'length' to hold our results.
        // Step 2: Loop from 1 to 'length' (inclusive) using index i.
        // Step 3: At each iteration, calculate the multiple by multiplying 'number' by i.
        //         e.g. MultiplesOf(7, 5): 7*1=7, 7*2=14, 7*3=21, 7*4=28, 7*5=35
        // Step 4: Store the result in the array at position (i - 1) since arrays are 0-indexed.
        // Step 5: Return the completed array.

        var result = new double[length];

        for (var i = 1; i <= length; i++)
        {
            result[i - 1] = number * i;
        }

        return result;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // Step 1: Calculate the split point: (data.Count - amount).
        //         This is the index where the list divides into two halves.
        //         e.g. data={1,2,3,4,5,6,7,8,9}, amount=3 → splitPoint = 9 - 3 = 6
        // Step 2: Slice the FIRST part from index 0 up to the split point.
        //         e.g. GetRange(0, 6) → {1, 2, 3, 4, 5, 6}
        // Step 3: Slice the SECOND part from the split point to the end.
        //         These are the elements that will rotate to the front.
        //         e.g. GetRange(6, 3) → {7, 8, 9}
        // Step 4: Clear the original list.
        // Step 5: Add the second part first, then the first part after.
        //         e.g. {7, 8, 9} + {1, 2, 3, 4, 5, 6} = {7, 8, 9, 1, 2, 3, 4, 5, 6}

        var splitPoint = data.Count - amount;

        var firstPart = data.GetRange(0, splitPoint);
        var secondPart = data.GetRange(splitPoint, amount);

        data.Clear();
        data.AddRange(secondPart);
        data.AddRange(firstPart);
    }
}