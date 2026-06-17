using System;
using System.Collections.Generic;
using System.Linq;

public class ThirdWeek
{
    private static byte day = 16;

    public static void launchDay()
    {
        switch (day)
        {
            case 15:
                Console.WriteLine(minimumCost(new[] { 9, 6, 3, 2, 20 }, 8));
                break;
            case 16:
                int[,] arr = new int[,] { { 0, 6 }, { 0, 3 }, { 0, 2 }, { 1, 4 }, { 1, 5 } };
                constructList(arr).ForEach(x => Console.Write($"{x} "));
                break;
            case 17:
                Console.WriteLine("Result: " + maxProduct(5));
                break;
        }
    }

    private static int minimumCost(int[] costs, int finalWeight)
    {
        var map = new Dictionary<int, int>();
        for (var i = 0; i < costs.Length; i++)
        {
            if (costs[i] != -1) map.Add(i + 1, costs[i]);
        }

        if (map.Count == 0) return -1;
        else if (map.Count == 1)
        {
            int weight = 0;
            int price = 0;
            while (weight < finalWeight)
            {
                weight += map.First().Key;
                price += map.First().Value;
            }

            if (weight == finalWeight) return price;
            else return -1;
        }

        var costPerKg = new Dictionary<int, double>();
        foreach (var pair in map)
        {
            costPerKg.Add(pair.Key, pair.Value / pair.Key);
        }

        var costPerKgSorted = costPerKg.OrderBy(weight => weight.Value).ThenBy(weight => weight.Key);
        int min = -1;

        foreach (var keyValuePair in map)
        {
            Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value}");
        }

        foreach (var pair in costPerKgSorted)
        {
            int price = 0;
            var weight = 0;
            while (weight + pair.Key <= finalWeight)
            {
                price += map[pair.Key];
                weight += pair.Key;
            }

            Console.WriteLine($"{pair.Key} - {weight} - {price}");
            if (weight == finalWeight)
            {
                if (min == -1) return price;
                else if (min > price) min = price;
            }
            else
            {
                int result = iterate(map, finalWeight, weight, price);
                if (result != -1 && (min == -1 || min > result)) min = result;
            }
        }

        return min;
    }


    private static int iterate(Dictionary<int, int> costs, int finalWeight, int currentWeight, int currentPrice)
    {
        Console.WriteLine($"(sub)     {currentPrice} {currentWeight}");
        if (finalWeight < currentWeight) return -1;
        else if (finalWeight == currentWeight) return currentPrice;

        List<int> prices = new List<int>();
        int price;
        foreach (var pair in costs)
        {
            Console.WriteLine($"     - {pair.Key} - {currentWeight + pair.Key} - {currentPrice}");
            price = iterate(costs, finalWeight, currentWeight + pair.Key, currentPrice + pair.Value);

            if (price != -1) prices.Add(price);
        }

        if (prices.Count == 0) return -1;
        return prices.Min();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queries"></param>
    /// <returns></returns>
    public static List<int> constructList(int[,] queries) {
        List<int> result = new List<int>(){0};
        for (var i = 0; i < queries.GetLength(0); i++)
        {
            if (queries[i,0] == 0) result.Add(queries[i,1]);
            else
            {
                for (var j = 0; j < result.Count; j++)
                {
                    result[j] ^= queries[i,1];
                }
            }
        }

        result.Sort();
        return result;
    }
    
    public static int maxProduct(int n)
    {
        if (n < 4) return (n-1);
        var divided = 1;
        while (n > 4) {
            n-=3;
            divided*=3;
        }
        return (n * divided);
    }
}