using System;
using System.Collections.Generic;
using System.Linq;

public class SecondWeek
{
    private static byte day = 9;

    public static void launchDay()
    {
        switch (day)
        {
            // Add 9
            case 8:
                SecondWeek_Day8.launchDay();
                break;
            case 9:
                int[] seats = new[] { 0,1,0 };
                Console.WriteLine(canSeatAllPeople(1, seats));
                break;
            case 10:
                int[] a = new[] { 2, 1, 3, 5, 4, 6 };
                Console.WriteLine(binarySearchable(a));
                break;
            case 11:
                Console.WriteLine(findIndex("(())))("));
                break;
            case 12:
                Console.WriteLine(kSubstr("abab", 2));
                break;
        }
    }

    

    /// <summary>
    /// 10.06.2026 - Binary Searchable Count
    ///
    /// Given an array arr[] consisting of n distinct integers, find the maximum count of integers that are
    /// binary searchable in the given array.
    /// </summary>
    /// <param name="arr">Given an array with integers to be checked</param>
    /// <returns>the maximum count of integers that are binary searchable in the given array</returns>
    private static int binarySearchable(int[] arr)
    {
        var i = 0;
        foreach (var a in arr)
        {
            if (SearchBinary(a))
            {
                i++;
            }
        }

        return i;
        
        bool SearchBinary(int x)
        {
            var l = 0;
            var r = arr.Length - 1;

            while (l <= r)
            {
                var mid = l + (r - l) / 2;

                if (arr[mid] == x) return true;
                else if (arr[mid] < x)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }

            return false;
        }
    }

    /// <summary>
    /// 11.06.2026 - Equal Point in Brackets
    ///
    /// Given a string s of opening and closing brackets '(' and ')' only, find an equal point in the string.
    /// </summary>
    /// <param name="s">the string to be checked</param>
    /// <returns>index of equal point</returns>
    private static int findIndex(string s)
    {
        var maxPairs = 0;
        var maxIndex = 0;
        var maxClosed = 0;

        foreach (var c in s)
        {
            if (c == ')') maxClosed++;
        }

        var pairs = 0;
        var open = 0;
        var closed = maxClosed;

        for (var i = 0; i < s.Length; i++)
        {
            var character = s[i];
            if (character == '(') open++;
            else if (character == ')') closed--;

            if (open != closed) continue;
            pairs++;
            if (pairs <= maxPairs) continue;
            maxPairs = pairs;
            maxIndex = i + 1;
        }

        return maxIndex;
    }

    /// <summary>
    /// 12.06.2026 - Check Repeated Substring with K Replacements
    /// Given a string s and an integer k, check if it is possible to convert s to a string that is repetition of
    /// a substring with k characters else returns false. In order to convert we can replace one substring of length k
    /// with any k characters.
    /// </summary>
    /// <param name="s">String to be checked</param>
    /// <param name="k">repeat string length</param>
    /// <returns>Can a string be converted into a repeating string</returns>
    private static bool kSubstr(string s, int k)
    {
        var map = new Dictionary<string, int>();
        for (var i = 0; i < s.Length / k; i++)
        {
            var part = s.Substring(i * k, k);
            if (!map.ContainsKey(part)) map.Add(part, 1);
            else map[part]++;
        }

        if (map.Count > 2) return false;
        else if (map.Count == 1) return true;
        foreach (var var in map)
        {
            if (var.Value == 1) return true;
        }
        return false;
    }
}