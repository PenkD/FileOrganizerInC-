
class FileOrganizer
{

    static Dictionary<string, string> folderType = new Dictionary<string, string>()
    {
        { ".jpg", "Images" },
        { ".png", "Images" },
        { ".gif", "Images" },
        { ".webp", "Images" },
        { ".jfif", "Images" },
        { ".jpeg", "Images" },

        { ".mp3", "Music" },
        { ".wav", "Music" },
        { ".ogg", "Music" },
        { ".wma", "Music" },
        { ".3gp", "Music" },

        { ".mp4", "Videos" },
        { ".mov", "Videos" },
        { ".avi", "Videos" },
        { ".mkv", "Videos" },

        { ".pdf", "Documents" },
        { ".doc", "Documents" },
        { ".docx", "Documents" },
        { ".xls", "Documents" },
        { ".xlsx", "Documents" },
        { ".ppt", "Documents" },
        { ".pptx", "Documents" },
        { ".txt", "Documents" },
        { ".rtf", "Documents" },
        { ".odt", "Documents" },
        { ".csv", "Documents" },
        { ".log", "Documents" },
        { ".json", "Documents" },
        { ".xml", "Documents" },
        { ".yml", "Documents" },
        { ".yaml", "Documents" },
        { ".md", "Documents" },
        { ".html", "Documents" },
        { ".htm", "Documents" },
        { ".ahk", "Documents" },
        { ".js", "Documents" },
        { ".css", "Documents" },
        { ".ts", "Documents" },
        { ".java", "Documents" },
        { ".py", "Documents" },
        { ".c", "Documents" },
        { ".cpp", "Documents" },
        { ".h", "Documents" },
        { ".sh", "Documents" },

        { ".exe", "Executables" },
        { ".msi", "Executables" },
        { ".cmd", "Executables" },
        { ".bat", "Executables" },
        { ".apk", "Executables" },
        { ".com", "Executables" },

        { ".jar", "JARs" },

        { ".zip", "Archives" },
        { ".rar", "Archives" },
        { ".gz", "Archives" },
        { ".7z", "Archives" },
        { ".iso", "Archives" }




    };


    static List<string> FolderNames = new List<string>
    {
        "images", "Music", "Videos", "Documents", "Executables", "JARs", "Archives"

    };



    static void Main(string[] args)
    {
        
        Console.Title = "file organizer";

        string path = "";
        while (true)
        {
            Console.WriteLine("Enter a folder path: ");
            path = Console.ReadLine()?.Trim();

            if (Directory.Exists(path))
            {
                break; // exits the loop
            }
            else
            {
                Console.WriteLine("Invalid path.\n");
            }
        }

        Console.WriteLine("Cleaning path...");


        string[] files = Directory.GetFiles(path);

        foreach (string filepath in files)
        {
            string extension = Path.GetExtension(filepath).ToLower();



            if (folderType.ContainsKey(extension))
            {


                string folderNames = folderType[extension];
                string targetFolder = Path.Combine(path, folderNames);
                string fileName = Path.GetFileName(filepath);
                string destPath = Path.Combine(targetFolder, fileName);


                try
                {
                    File.Move(filepath, destPath);
                    Console.WriteLine($"moved {fileName} to {folderNames}");


                }
                catch (Exception e)
                {
                    Console.WriteLine($"Couldn'tt move {fileName}: {e.Message}");



                }


            }
        }


        Console.WriteLine("Moved files.");

    }
}
