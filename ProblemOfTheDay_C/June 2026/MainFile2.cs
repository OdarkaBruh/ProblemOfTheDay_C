using System;
using System.Collections.Generic;
using System.Linq;

public class SecondWeek
{
    private static byte day = 14;

    public static void launchDay()
    {
        switch (day)
        {
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
            case 13:
                // I tried to solve this problem, but despite my love of math, I'm so not a fan of combinatorics :'
                break;
            case 14:
                int[][] numbers = { new[] { 0, 1, 0 }, new []{0, 1, 1}, new []{0, 0, 0} };
                List<int> coordinates = exitPoint(numbers);
                Console.WriteLine(coordinates[0] + " " + coordinates[1]);
                break;
        }
    }

    /// <summary>
    /// 08.06.2026 (13.06.2026) - Seating Arrangement
    ///
    /// Given an integer k representing the number of people to be seated and an array seats[], where 0 denotes
    /// an empty seat and 1 denotes an occupied seat.
    ///
    /// Determine whether it is possible to seat all k people such that no two occupied seats are adjacent
    /// (including newly seated people).
    /// </summary>
    /// <param name="k">the number of people to be seated</param>
    /// <param name="seats">a representation of people sitting</param>
    /// <returns>whether it is possible to seat all k people such that no two occupied seats are adjacent</returns>
    private static bool canSeatAllPeople(int k, int[] seats)
    {
        for (var i = 0; i < seats.Length; i++)
        {
            if (i != 0 && seats[i] == 1 && seats[i - 1] == 1) return false;
            else if ( k != 0 && seats[i] == 0 && 
                      (i == 0 || seats[i - 1] == 0) &&
                      (i + 1 == seats.Length || seats[i + 1] == 0))
            {
                k--;
                i++;
            }
        }
        return k == 0;
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

    /// <summary>
    /// 14.06.2026 - Exit Point in a Matrix
    /// Given a matrix mat[][] of size n × m consisting of 0s and 1s. You start at the top-left cell (0, 0)
    /// and initially move in the left-to-right direction (i.e., towards the right).
    ///
    /// While traversing the matrix, follow these rules:
    ///     If the current cell contains 0, continue moving in the same direction.
    ///     If the current cell contains 1, change your direction to the right (clockwise turn), and
    ///     update the cell value to 0.
    ///
    /// You continue this process until you move outside the boundaries of the matrix. Your task is to determine the
    /// coordinates (row and column index) of the cell from which you exit the matrix.
    ///
    /// Time: 0,1
    /// <remarks>Maybe not the shortest solution, but I like how easy to understand it is.</remarks>
    /// </summary>
    /// <param name="mat"> a matrix to travel through</param>
    /// <returns>The coordinates (row and column) of the cell from which the matrix was exited</returns>
    /// <exception cref="NotImplementedException"></exception>
    private static List<int> exitPoint(int[][] mat)
    {
        List<int> coordinates = new List<int>();
        var pointX = 0;
        var pointY = 0;
        var currentDirection = Directions.East;

        while (pointX >= 0 && pointX < mat[0].Length && pointY >= 0 && pointY < mat.Length) {
            if (mat[pointY][pointX] == 1) {
                currentDirection = getNextDirection(currentDirection);
                mat[pointY][pointX] = 0;
            }
            pointX += getX(currentDirection);
            pointY += getY(currentDirection);
        }
        coordinates.Add(pointY - getY(currentDirection));
        coordinates.Add(pointX - getX(currentDirection));
        
        return coordinates;
        int getX(Directions dir)
        {
            if (dir == Directions.West) return -1;
            else if (dir == Directions.East) return + 1;
            else return 0;
        }
        
        int getY(Directions dir)
        {
            if (dir == Directions.North) return -1;
            else if (dir == Directions.South) return 1;
            else return 0;
        }
        
        Directions getNextDirection(Directions direction)
        {
            switch (direction)
            {
                case Directions.East:
                    return Directions.South;
                case Directions.West:
                    return Directions.North;
                case Directions.North:
                    return Directions.East;
                case Directions.South:
                    return Directions.West;
                default:
                    throw new NotImplementedException();
            }
        }  
    }
    
    enum Directions
    {
        East,
        West,
        North,
        South,        
    }
}