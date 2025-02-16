using System;
using System.Collections.Generic;

public class Sol
{
    // 1. Kadane's Algorithm for Max Subarray Sum
    public int MaxSub(int[] nums)
    {
        int max = nums[0], curr = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            curr = Math.Max(nums[i], curr + nums[i]);
            max = Math.Max(max, curr);
        }
        return max;
    }

    // 2. Intersection and Union of Two Arrays
    public (List<int> inter, List<int> uni) InterUnion(int[] a1, int[] a2)
    {
        var set1 = new HashSet<int>(a1);
        var set2 = new HashSet<int>(a2);
        var inter = new List<int>();
        var uni = new List<int>(set1);

        foreach (var x in set2)
        {
            if (set1.Contains(x)) inter.Add(x);
            else uni.Add(x);
        }

        return (inter, uni);
    }

    // 3. Sparse Matrix Multiplication
    public int[,] MatMul(int[,] m1, int[,] m2)
    {
        int r = m1.GetLength(0), c = m2.GetLength(1), com = m1.GetLength(1);
        var res = new int[r, c];

        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                for (int k = 0; k < com; k++)
                    res[i, j] += m1[i, k] * m2[k, j];

        return res;
    }

    // 4. First Missing Positive Integer
    public int FirstMissing(int[] nums)
    {
        var set = new HashSet<int>(nums);
        int i = 1;
        while (set.Contains(i)) i++;
        return i;
    }

    // 5. Rotate Matrix 90 Degrees Clockwise
    public void Rotate90(int[,] mat)
    {
        int n = mat.GetLength(0);
        for (int l = 0; l < n / 2; l++)
        {
            int f = l, lst = n - l - 1;
            for (int i = f; i < lst; i++)
            {
                int off = i - f;
                int tmp = mat[f, i];
                mat[f, i] = mat[lst - off, f];
                mat[lst - off, f] = mat[lst, lst - off];
                mat[lst, lst - off] = mat[i, lst];
                mat[i, lst] = tmp;
            }
        }
    }
}

// class Program
// {
//     static void Main(string[] args)
//     {
//         Sol s = new Sol();

//         // 1. Test Max Subarray Sum
//         int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
//         Console.WriteLine("Max Subarray Sum: " + s.MaxSub(nums));

//         // 2. Test Intersection and Union
//         int[] a1 = { 1, 2, 2, 1 }, a2 = { 2, 2 };
//         var (inter, uni) = s.InterUnion(a1, a2);
//         Console.WriteLine("Intersection: " + string.Join(", ", inter));
//         Console.WriteLine("Union: " + string.Join(", ", uni));

//         // 3. Test Sparse Matrix Multiplication
//         int[,] m1 = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
//         int[,] m2 = { { 1, 0 }, { 0, 1 }, { 1, 1 } };
//         var res = s.MatMul(m1, m2);
//         Console.WriteLine("Matrix Multiplication Result:");
//         for (int i = 0; i < res.GetLength(0); i++)
//         {
//             for (int j = 0; j < res.GetLength(1); j++)
//                 Console.Write(res[i, j] + " ");
//             Console.WriteLine();
//         }

//         // 4. Test First Missing Positive
//         int[] arr = { 3, 4, -1, 1 };
//         Console.WriteLine("First Missing Positive: " + s.FirstMissing(arr));

//         // 5. Test Rotate Matrix 90 Degrees
//         int[,] mat = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
//         s.Rotate90(mat);
//         Console.WriteLine("Rotated Matrix:");
//         for (int i = 0; i < mat.GetLength(0); i++)
//         {
//             for (int j = 0; j < mat.GetLength(1); j++)
//                 Console.Write(mat[i, j] + " ");
//             Console.WriteLine();
//         }
//     }
// }