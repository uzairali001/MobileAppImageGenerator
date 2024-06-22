namespace MobileAppImageGenerator.ConsoleApp;
public class ArgumentParser
{
    public static Dictionary<string, string?> Parse(string[] args)
    {
        Dictionary<string, string?> arguments = [];

        foreach (var arg in args)
        {
            // Split the argument by '=' to handle key/value pairs
            string[] parts = arg.Split('=');

            // Check if the argument is in the format "key=value"
            if (parts.Length == 2)
            {
                arguments[parts[0]] = parts[1];
            }
            // If not, assume it's just a named argument without a value
            else
            {
                arguments[arg] = null;
            }
        }

        return arguments;
    }
}
