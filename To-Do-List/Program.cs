// See https://aka.ms/new-console-template for more information
using System;
namespace To_Do_List;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("To-Do-List Command Line Tool");

        // appData Folder; if not existing - create.
        string appDataPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "cs_ToDoList"
        );
        if (!Directory.Exists(appDataPath))
        {
            Directory.CreateDirectory(appDataPath);
        }
        // End appData Folder;
        
        // csv File; if not existing - create.
        string csvFilePath = Path.Combine(appDataPath, "data.csv");

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
            Console.WriteLine("CSV-Datei already exists: " + csvFilePath);
        }
        // End csv File;

        //-> Read 2 array


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
                break;
            case 'a':
                Console.WriteLine("Add a new To-Do: ");
                int entryNr = 0; //from array -> needs to ++ 
                string entry = Console.ReadLine();
                //-> entryNr + entry to array. Write it to file after
                Console.WriteLine(entryNr + ";" + entry);
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




