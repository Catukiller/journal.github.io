using System;
using System.Collections.Generic;

class Journal
{
    private List<string> entries = new List<string>();

    public void AddEntry(string entry)
    {
        entries.Add(entry);
    }

    public void ViewEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
        }
        else
        {
            for (int i = 0; i < entries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {entries[i]}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Journal ---");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. View Entries");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter your entry: ");
                    string entry = Console.ReadLine();
                    journal.AddEntry(entry);
                    break;
                case "2":
                    journal.ViewEntries();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
