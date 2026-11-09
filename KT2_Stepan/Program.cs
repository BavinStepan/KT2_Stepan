using System;
using System.Collections.Generic;

public class Playlist
{
    private List<string> tracks = new List<string>();

    public void Add(string title)
    {
        tracks.Add(title);
    }

    public string this[int position]
    {
        get
        {
            if (position < 0 || position >= tracks.Count)
                throw new ArgumentOutOfRangeException(nameof(position));
            return tracks[position];
        }
        set
        {
            if (position < 0 || position >= tracks.Count)
                throw new ArgumentOutOfRangeException(nameof(position));
            tracks[position] = value;
        }
    }

    public int this[string title]
    {
        get
        {
            return tracks.IndexOf(title);
        }
    }

    public override string ToString()
    {
        List<string> result = new List<string>();
        for (int i = 0; i < tracks.Count; i++)
        {
            result.Add($"{i}: {tracks[i]}");
        }
        return string.Join(", ", result);
    }
}

class Program
{
    static void Main()
    {
        Playlist playlist = new Playlist();
        playlist.Add("Track A");
        playlist.Add("Track B");
        playlist.Add("Track C");

        Console.WriteLine("Исходный плейлист:");
        Console.WriteLine(playlist.ToString());

        playlist[1] = "Track B (Remix)";
        Console.WriteLine("\nПосле замены по индексу [1]:");
        Console.WriteLine(playlist.ToString());

        Console.WriteLine("\nПоиск по названию 'Track A':");
        Console.WriteLine($"Позиция: {playlist["Track A"]}");

        Console.WriteLine("\nПоиск несуществующего трека:");
        Console.WriteLine($"Позиция: {playlist["Unknown"]}");

        Console.WriteLine("\nПопытка обратиться к несуществующему индексу [10]:");
        try
        {
            Console.WriteLine(playlist[10]);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}