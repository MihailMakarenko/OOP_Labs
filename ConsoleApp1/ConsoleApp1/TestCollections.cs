using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class TestCollections
{

    public TestCollections(int numberOfElements)
    {
        _editions = GenerateEditions(numberOfElements);
        _strings = GenerateStrings(numberOfElements);
        _editionToMagazine = GenerateEditionToMagazineMap(numberOfElements);
        _stringToMagazine = GenerateStringToMagazineMap(numberOfElements);
    }

    private List<Edition> _editions;
    private List<string> _strings;
    private Dictionary<Edition, Magazine> _editionToMagazine;
    private Dictionary<string, Magazine> _stringToMagazine;

    public List<Edition> GetEditions
    {
        get
        {
            return _editions;
        }
        set
        {
            _editions.RemoveAt(_editions.Count - 1);
        }
    }

    public List<string> GetStrings
    {
        get
        {
            return _strings;
        }
        set
        {
            _strings.RemoveAt(_strings.Count - 1);
        }
    }


    private static List<Edition> GenerateEditions(int count)
    {
        Random random = new Random();

        var editions = new List<Edition>();
        for (int i = 0; i < count; i++)
        {
            editions.Add(new Edition (i.ToString(), new DateTime( 2023, 4, 1), random.Next(0, 150)));
        }
        return editions;
    }

    private static List<string> GenerateStrings(int count)
    {
        var strings = new List<string>();
        for (int i = 0; i < count; i++)
        {
            strings.Add($"String {i}");
        }
        return strings;
    }

    private static Dictionary<Edition, Magazine> GenerateEditionToMagazineMap(int count)
    {

        Random random = new Random();
        List<Article> articles = [new Article(), new Article()];
        var map = new Dictionary<Edition, Magazine>();
        for (int i = 0; i < count; i++)
        {
            map.Add(new Edition(i.ToString(), new DateTime(2023, 1, 1), random.Next()), GenerateMagazine(count));
        }
        return map;
    }

    private static Dictionary<string, Magazine> GenerateStringToMagazineMap(int count)
    {
        var map = new Dictionary<string, Magazine>();
        for (int i = 0; i < count; i++)
        {
            map.Add($"String {i}", GenerateMagazine(count));
        }
        return map;
    }

    private static Magazine GenerateMagazine(int id)
    {
        Random random = new Random();
        List<Article> articles = [new Article(), new Article(), new Article()];
        List<Person> people = [new Person(), new Person(), new Person()];
        return new Magazine((random.Next()).ToString(), people,Frequency.Weekly, DateTime.Now, id, articles);
    }

    public void MeasurePerformance(Edition edition, String str)
    {
        var stopwatch = Stopwatch.StartNew();
        _editions.Contains(edition);
        stopwatch.Stop();
        Console.WriteLine($"Time to search for Edition in List<Edition>: {stopwatch.Elapsed} ms");

        // Measure performance for List<string>
        stopwatch.Restart();
        _strings.Contains(str);
        stopwatch.Stop();
        Console.WriteLine($"Time to search for string in List<string>: {stopwatch.Elapsed} ms");

        // Measure performance for Dictionary<Edition, Magazine>
        stopwatch.Restart();
        _editionToMagazine.ContainsKey(edition);
        stopwatch.Stop();
        Console.WriteLine($"Time to search for Edition in Dictionary<Edition, Magazine>: {stopwatch.Elapsed} ms");

        // Measure performance for Dictionary<string, Magazine>
        stopwatch.Restart();
        _stringToMagazine.ContainsKey(str);
        stopwatch.Stop();
        Console.WriteLine($"Time to search for string in Dictionary<string, Magazine>: {stopwatch.Elapsed} ms");
    }
}