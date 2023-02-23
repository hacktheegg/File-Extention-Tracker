





class Program
{
    static void Main(string[] args)
    {
        Console.Write("Format your values like this: ");
        Console.WriteLine("[folderPath] * [searchedFileExtention]");
        Console.Write(@"FileExtentionTracker\: ");
        string input = Console.ReadLine();

        string[] dirs = Directory.GetFiles(input.Split(" * ")[0], "*" + input.Split(" * ")[1], SearchOption.AllDirectories);

        for (int i = 0; i < dirs.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + dirs[i]);
        }

        Console.WriteLine("done");

        Console.ReadLine();
    }
}