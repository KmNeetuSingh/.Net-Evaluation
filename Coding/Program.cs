using System;
using System.Collections.Generic;

public class Solution
{
    // 1. Method to find the maximum subarray sum using Kadane's Algorithm
    public int MaxSub(int[] nums)
    {
        int maxSoFar = nums[0];
        int maxEndingHere = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
            maxSoFar = Math.Max(maxSoFar, maxEndingHere);
        }

        return maxSoFar;
    }

    // 2. Method to find the intersection and union of two unsorted arrays
    public (List<int> intersection, List<int> union) FindIntersectionAndUnion(int[] arr1, int[] arr2)
    {
        HashSet<int> set1 = new HashSet<int>(arr1);
        HashSet<int> set2 = new HashSet<int>(arr2);

        List<int> intersection = new List<int>();
        List<int> union = new List<int>(set1);

        foreach (var item in set2)
        {
            if (set1.Contains(item))
                intersection.Add(item);
            else
                union.Add(item);
        }

        return (intersection, union);
    }

    // 3. Sparse Matrix Multiplication using a 2D array
    public int[,] SparseMatrixMultiplication(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix2.GetLength(1);
        int common = matrix1.GetLength(1);

        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                for (int k = 0; k < common; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }

    // 4. Method to find the first missing positive integer in an unsorted array
    public int FirstMissingPositive(int[] nums)
    {
        HashSet<int> numSet = new HashSet<int>(nums);
        int small = 1;

        while (numSet.Contains(small))
        {
            small++;
        }

        return small;
    }

    // 5. Method to rotate a 2D matrix 90 degrees clockwise in place
    public void RotateMatrix90DegreesClockwise(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int layer = 0; layer < n / 2; layer++)
        {
            int first = layer;
            int last = n - layer - 1;

            for (int i = first; i < last; i++)
            {
                int offset = i - first;
                int top = matrix[first, i];

                matrix[first, i] = matrix[last - offset, first];
                matrix[last - offset, first] = matrix[last, last - offset];
                matrix[last, last - offset] = matrix[i, last];
                matrix[i, last] = top;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // 1. Test Kadane's Algorithm (Maximum Subarray Sum)
        int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        int maxSum = solution.MaxSub(nums);
        Console.WriteLine("Maximum Subarray Sum: " + maxSum);

        // 2. Test Intersection and Union of Arrays
        int[] arr1 = { 1, 2, 2, 1 };
        int[] arr2 = { 2, 2 };
        var (intersection, union) = solution.FindIntersectionAndUnion(arr1, arr2);
        Console.WriteLine("Intersection: " + string.Join(", ", intersection));
        Console.WriteLine("Union: " + string.Join(", ", union));

        // 3. Test Sparse Matrix Multiplication
        int[,] matrix1 = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
        int[,] matrix2 = { { 1, 0 }, { 0, 1 }, { 1, 1 } };
        int[,] result = solution.SparseMatrixMultiplication(matrix1, matrix2);
        Console.WriteLine("Sparse Matrix Multiplication Result:");
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                Console.Write(result[i, j] + " ");
            }
            Console.WriteLine();
        }

        // 4. Test First Missing Positive Integer
        int[] unsortedArray = { 3, 4, -1, 1 };
        int firstMissingPositive = solution.FirstMissingPositive(unsortedArray);
        Console.WriteLine("First Missing Positive: " + firstMissingPositive);

        // 5. Test Rotating a 2D Matrix 90 Degrees Clockwise
        int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        solution.RotateMatrix90DegreesClockwise(matrix);
        Console.WriteLine("Rotated Matrix 90 Degrees Clockwise:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
