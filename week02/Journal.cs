using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry e in entries)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter output = new StreamWriter(file))
        {
            foreach (Entry e in entries)
            {
                output.WriteLine(e.ToString());
            }
        }
    }

    public void LoadFromFile(string file)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            Entry e = new Entry(parts[1].Trim(), parts[2].Trim());
            e.Date = parts[0].Trim();
            entries.Add(e);
        }
    }
}