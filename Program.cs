using IWshRuntimeLibrary;



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

            Console.WriteLine("\nAdd previous folder with shortcut name? (y/n)");

            answer = Console.ReadKey(true).KeyChar;

            if (answer.ToString().ToLower() == "y")
            {
                for (int i = 0; i < dirs.Length; i++)
                {
                    CreateShortcut(dirs[i], dirs[i].Split(@"\")[^2] + "   " + dirs[i].Split(@"\")[^1].Split(".")[0]);
                }
            }
            else
            {
                for (int i = 0; i < dirs.Length; i++)
                {
                    CreateShortcut(dirs[i], dirs[i].Split(@"\")[^1].Split(".")[0]);
                }
            }


            Console.WriteLine("done");

            Console.ReadLine();

            System.Environment.Exit(1);
        }



        Console.WriteLine("");
        Console.Write("choose which to make a shortcut of like this: ");
        Console.WriteLine("[targetFileLocationNumber];[shortcutName]");
        Console.Write(@"FileExtentionTracker\: ");

        input = Console.ReadLine();



        CreateShortcut(dirs[int.Parse(input.Split(";")[0]) - 1], input.Split(";")[1]);

        Console.WriteLine("done");



        Console.ReadLine();
    }


    public static void CreateShortcut(string targetFileLocation, string shortcutName)
    {
        string shortcutLocation = System.IO.Path.Combine(@"Where Shortcuts Are Sent\", shortcutName + ".lnk");
        WshShell shell = new WshShell();
        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

        shortcut.Description = "Shortcut made by Hacktheegg Code";
        shortcut.IconLocation = targetFileLocation;
        shortcut.TargetPath = targetFileLocation;
        shortcut.Save();
    }
}
