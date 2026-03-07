using System.Diagnostics;

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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Create an empty list of length length;
        double[] doubles = new double[length];
        // Iterate number of length times
        for (int i=1; i <= length; i++)
        {
            double num = number * i; // At every iteration multiply number by i
            doubles[i - 1] = num; // Get the index by subtracting i (the current position) by 1
            // and then set the value of the multiple to the list.
        }
        Debug.WriteLine(doubles);
        // At the end of the iteration we return our list
        return doubles; // replace this return statement with your own
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        var startCutIndex = data.Count - amount; // Get where to start slicing by subtracting the data
        //  length by the amount we want to shift right

        int[] toGOLeft = new int[amount]; // Create a new array with size of amount that should move to the left
        var index = 0; // we create an index variable and asign 0 to properly add element to it correct index

        // Iterate through the data array starting from whewr you want to cut and move
        for(int i=startCutIndex; i < data.Count; i++)
        {
            toGOLeft[index] = data[i]; // At each iteration we add the element we want to move right to the array
            //  of element we want to move right
            index++; // Then we increment the index 
        }

        // We iterate through the data array and start shifting element to the right
        for (int i=startCutIndex-1; i >= 0 ; i--)
        {
            int ind = i + toGOLeft.Count(); // We do this by adding the current index of the data array plus size
            data[ind] = data[i]; // Then we move element to the right
        }

        // We iterate throught the data array
        for(int i=0; i<toGOLeft.Count(); i++)
        {
            data[i] = toGOLeft[i]; // At the end we start appending whatever is in our array to the beginning of our data list
        }
    }
}
