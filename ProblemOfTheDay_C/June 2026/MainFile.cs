using System;
using System.Collections.Generic;
using System.Linq;

public class FirstWeek
{
    private static byte day = 5;

    public static void launchDay()
    {
        switch (day)
        {
            case 2:
            //sumDiffPairs
            case 3:
                int[] arr = { 1, 2, 3, 3, 2, 2, 1, 3 };
                int[][] queries = { new[] { 1, 4, 3 }, new[] { 1, 6, 2 } };

                int[] result = freqInRange(arr, queries).ToArray();
                Array.ForEach(result, n => Console.Write("{0} ", n));
                break;

            case 4:
                Console.WriteLine(maxSubstring("0001010001"));
                break;

            case 5:
                Console.WriteLine(lexicographicallySmallest("eggbpb", 2));
                break;
        }
    }

    public static int sumDiffPairs(int[] arr, int k)
    {
        Array.Sort(arr);

        int maxPairSum = 0;
        int n = arr.Length;

        int i = n - 1;
        while (i >= 0)
        {
            if (i >= 0 && (i - 1) >= 0 && (arr[i] - arr[i - 1] < k))
            {
                maxPairSum += arr[i] + arr[i - 1];
                i -= 2;
            }
            else
            {
                i--;
            }
        }

        return maxPairSum;
    }

    public static List<int> freqInRange(int[] arr, int[][] queries)
    {
        List<int> result = new List<int>();
        foreach (int[] query in queries)
        {
            var counter = 0;

            var fromIndex = query[0];
            var checkNextNSymbols = query[1] - query[0] + 1;

            int tempIndex;
            while ((tempIndex = Array.IndexOf(arr, query[2], fromIndex, checkNextNSymbols)) != -1)
            {
                counter++;
                checkNextNSymbols -= tempIndex - fromIndex + 1;
                fromIndex = tempIndex + 1;
            }

            result.Add(counter);
        }

        return result;
    }

    /// <summary>
    /// 04.06.2026 - Substring with Max Zero-One Diff
    /// Given a binary string s consisting of 0s and 1s. Find the maximum difference of the number of 0s and the
    /// number of 1s (number of 0s – number of 1s) in a substring of the string.
    ///
    /// <remarks>
    /// Sometimes, even for difficult tasks, you need to try out the most stupid and simple decision. That is why I
    /// love programming.
    /// </remarks>
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int maxSubstring(string s)
    {
        int max = -1;
        int Os = 0;
        bool match = false;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0')
            {
                match = true;
                Os += 1;
            }
            else if (Os > 0) Os -= 1;

            if (Os > max && match) max = Os;
        }

        return max;
    }

    public static string lexicographicallySmallest(string s, int k)
    {
        bool isPowerofTwo(int n) {
            if (n <= 0) return false;
            return Math.Pow(2, (int) Math.Log(n, 2)) == n;
        }
        
        var result = s.ToArray();
        Array.Sort(result);
        Array.Reverse(result);
        
        if (isPowerofTwo(result.Length)) k = k / 2;
        else k = k * 2;
        
        if (k >= result.Length) return "-1";
        else {
            result = result.Take(k).ToArray();
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(i + " " + s);
                s = s.Remove(s.IndexOf(result[i]), 1);
            }
        }
        return s;
    }
}