using System;
using System.Collections.Generic;

class JournalEntry
{
    public DateTime Date { get; set; }
    public string Content { get; set; }

    public JournalEntry(DateTime date, string content)
    {
        Date = date;
        Content = content;
    }
}

class Program
{
    static List<JournalEntry> journalEntries = new List<JournalEntry>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Agregar entrada");
            Console.WriteLine("2. Ver entradas");
            Console.WriteLine("3. Buscar entradas por fecha");
            Console.WriteLine("4. Eliminar entrada por fecha");
            Console.WriteLine("5. Salir");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AgregarEntrada();
                    break;
                case 2:
                    VerEntradas();
                    break;
                case 3:
                    BuscarPorFecha();
                    break;
                case 4:
                    EliminarPorFecha();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }
    }

    static void AgregarEntrada()
    {
        Console.WriteLine("Ingresa tu entrada:");
        string content = Console.ReadLine();

        JournalEntry entry = new JournalEntry(DateTime.Now, content);
        journalEntries.Add(entry);

        Console.WriteLine("¡Entrada agregada!");
    }

    static void VerEntradas()
    {
        if (journalEntries.Count == 0)
        {
            Console.WriteLine("No hay entradas para mostrar.");
            return;
        }

        Console.WriteLine("------ Entradas del Diario ------");

        foreach (var entry in journalEntries)
        {
            Console.WriteLine($"{entry.Date}: {entry.Content}");
        }

        Console.WriteLine("---------------------------------");
    }

    static void BuscarPorFecha()
    {
        Console.WriteLine("Ingresa la fecha en el formato dd/mm/yyyy:");
        DateTime fecha = Convert.ToDateTime(Console.ReadLine());

        var entradasEnFecha = journalEntries.FindAll(entry => entry.Date.Date == fecha.Date);

        if (entradasEnFecha.Count == 0)
        {
            Console.WriteLine("No se encontraron entradas para esta fecha.");
            return;
        }

        Console.WriteLine($"------ Entradas para el {fecha.Date} ------");

        foreach (var entry in entradasEnFecha)
        {
            Console.WriteLine($"{entry.Date}: {entry.Content}");
        }

        Console.WriteLine("---------------------------------");
    }

    static void EliminarPorFecha()
    {
        Console.WriteLine("Ingresa la fecha en el formato dd/mm/yyyy:");
        DateTime fecha = Convert.ToDateTime(Console.ReadLine());

        var entradasEnFecha = journalEntries.FindAll(entry => entry.Date.Date == fecha.Date);

        if (entradasEnFecha.Count == 0)
        {
            Console.WriteLine("No se encontraron entradas para esta fecha.");
            return;
        }

        Console.WriteLine($"------ Entradas para el {fecha.Date} ------");

        foreach (var entry in entradasEnFecha)
        {
            Console.WriteLine($"{entry.Date}: {entry.Content}");
        }

        Console.WriteLine("---------------------------------");

        Console.WriteLine("¿Deseas eliminar todas las entradas de esta fecha? (S/N)");
        string respuesta = Console.ReadLine();

        if (respuesta.ToLower() == "s")
        {
            journalEntries.RemoveAll(entry => entry.Date.Date == fecha.Date);
            Console.WriteLine("Entradas eliminadas.");
        }
        else
        {
            Console.WriteLine("Operación cancelada.");
        }
    }
}

