using static System.Environment;

namespace Northwind.DataContext.Sqlite;

public class NorthwindContextLogger
{
    public static void WriteLine(string message)
    {
        string path = Path.Combine(GetFolderPath(SpecialFolder.DesktopDirectory), "NorthwindLog.txt");

        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine(message);
        }
    }
}
