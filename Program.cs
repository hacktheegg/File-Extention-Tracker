

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Format your values like this: ");
        Console.WriteLine("[folderPath] [searchedFileExtention]");
        Console.Write(@"FileExtentionTracker\: ");
        string input = Console.ReadLine();

        string[] dirs = Directory.GetDirectories(input.Split(' ')[0], );
    }
}