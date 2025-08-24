// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;

namespace To_Do_List;
public class CsvEntry
{
    public int EntryNr { get; set; }
    public string Entry { get; set; }
}

class Program
{
    static void Main()
    {
        

        // appData Folder; if not existing - create.
        string appDataPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "cs_ToDoList"
        );
        string csvFilePath = Path.Combine(appDataPath, "data.csv");
        if (!Directory.Exists(appDataPath))
        {
            Directory.CreateDirectory(appDataPath);
        }
        // End appData Folder;

        // csv File; if not existing - create.
        List<CsvEntry> entries = new List<CsvEntry>();

        if (!File.Exists(csvFilePath))
        {
            using (var writer = new StreamWriter(csvFilePath))
            {
                writer.WriteLine("EntryNr;Entry");
            }
            Console.WriteLine("CSV-Datei created: " + csvFilePath);
        }
        else
        {
            //Console.WriteLine("CSV-Datei already exists: " + csvFilePath);
            string[] lines = File.ReadAllLines(csvFilePath);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(";");
                if (parts.Length == 2)
                {
                    entries.Add(new CsvEntry
                    {
                        EntryNr = int.Parse(parts[0]),
                        Entry = parts[1]
                    });
                }
            }
        }
        // End csv File;
        // Output of all todos

        Console.WriteLine("To-Do-List Command Line Tool");
        Console.WriteLine("Current To-Do's: ");

        while (true)
        {

        foreach (var e in entries)
        {
            Console.WriteLine($"{e.EntryNr}: {e.Entry}");
        }

        Console.WriteLine("Operations: (a)dd, (d)elete, (q)uit");
        string inputOp = Console.ReadLine();
        if (!char.TryParse(inputOp, out char op))
        {
            Console.WriteLine("Invalid Operator");
        }
        switch (op)
            {
            case 'q':
                Console.WriteLine("exit App");
                return;
            case 'a':
                Console.WriteLine("Add a new To-Do: ");
                string newEntry = Console.ReadLine();
                //-> entryNr + entry to array. Write it to file after
                int entryNr = entries.Count + 1;

                var newCsvEntry = new CsvEntry
                {
                    EntryNr = entryNr,
                    Entry = newEntry
                };
                entries.Add(newCsvEntry);

                File.AppendAllText(csvFilePath, $"{entryNr};{newEntry}{Environment.NewLine}");

                Console.WriteLine(entryNr + ";" + newEntry);
                break;
            case 'd':
                Console.WriteLine("Delete To-Do: ");
                break;
            default:
                Console.WriteLine("exit");
                break;
            }
        }
    }
}




