using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("Format your values like this: ");
        Console.WriteLine("[folderPath];[searchedFileExtention]");
        Console.Write(@"FileExtentionTracker\: ");
        string input = Console.ReadLine();

        string[] dirs = Directory.GetFiles(input.Split(";")[0], "*" + input.Split(";")[1], SearchOption.AllDirectories);

        for (int i = 0; i < dirs.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + dirs[i]);
        }

        Console.WriteLine("done");



        if (!System.IO.Directory.Exists("Where Shortcuts Are Sent"))
        {
            System.IO.Directory.CreateDirectory("Where Shortcuts Are Sent");
        }



        Console.WriteLine("\nmass shortcut? (y/n)");

        char answer = Console.ReadKey(true).KeyChar;

        if (answer.ToString().ToLower() == "y")
        {

            System.IO.File.WriteAllLines("Where Shortcuts Are Sent\\Shortcuts.txt", dirs);

        }
            
        Console.WriteLine("done");

        Console.ReadLine();

        System.Environment.Exit(1);
    }
}