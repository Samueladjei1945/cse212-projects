public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
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

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
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
        // Step 5: Add the second part first (rotated elements go to the front).
        //         Then add the first part after (remaining elements go to the back).
        //         e.g. {7, 8, 9} + {1, 2, 3, 4, 5, 6} = {7, 8, 9, 1, 2, 3, 4, 5, 6}

        var splitPoint = data.Count - amount;

        var firstPart = data.GetRange(0, splitPoint);        // e.g. {1, 2, 3, 4, 5, 6}
        var secondPart = data.GetRange(splitPoint, amount);  // e.g. {7, 8, 9}

        data.Clear();
        data.AddRange(secondPart);  // Rotated elements go to the front
        data.AddRange(firstPart);   // Remaining elements go to the back
    }
}