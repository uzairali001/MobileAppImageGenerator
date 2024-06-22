

using MobileAppImageGenerator.ConsoleApp.Models;

using System.IO;

Dictionary<string, string?> arguments = ArgumentParser.Parse(args);

// Check if 'help' argument is passed and output help string
// If Zero arguments are passed in then output help string
if (arguments.Count == 0 || arguments.ContainsKey("--help"))
{
    PrintHelp();
    return; // Exit the application
}

// Example: Retrieve the input path
if (!arguments.TryGetValue("--input", out string? inputPath) || string.IsNullOrEmpty(inputPath))
{
    Console.WriteLine("Invalid argument value supplied for --input=<path>");
    PrintHelp();
    return; // Exit the application
}

arguments.TryGetValue("--output", out string? output);

string[] exts = ["jpg", "png"];

var files = Directory
    .EnumerateFiles(inputPath, "*.*")
    .Where(file => exts.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase)));


string outputDirectory = output ?? "output";

IEnumerable<AndroidImageResolution> resolutions = [
    new () { Name = "ldpi", Resolution = 36 },
    new () { Name = "mdpi", Resolution = 48 },
    new () { Name = "hdpi", Resolution = 72 },
    new () { Name = "xhdpi", Resolution = 96 },
    new () { Name = "xxhdpi", Resolution = 144 },
    new () { Name = "xxxhdpi", Resolution = 192 },
];
ImageService imageService = new();

foreach (string file in files)
{
    foreach (AndroidImageResolution resolution in resolutions)
    {
        string outputFileName = Path.ChangeExtension(Path.GetFileName(file), ".png");
        string outputPath = Path.Combine(outputDirectory, resolution.Name, outputFileName);
        Console.WriteLine($"Generating => {outputPath}");
        await ProcessFile(file, outputPath, resolution.Resolution);
    }

    Console.WriteLine();
}

Console.WriteLine($"Total {files.Count() * resolutions.Count()} files generated from {files.Count()} files.");
Console.WriteLine("Press any key to exit...");

Console.ReadKey();

static void PrintHelp()
{
    Console.WriteLine("Help:");
    Console.WriteLine("------");
    Console.WriteLine("Usage: Mobile App Image Generator [options]");
    Console.WriteLine();
    Console.WriteLine("Options:");
    Console.WriteLine("  --help             Display this help message");
    Console.WriteLine("  --input=<path>     Specify input path");
    Console.WriteLine("  --output=<path>    Specify output path");
}


async Task ProcessFile(string input, string output, int resolution)
{
    Directory.CreateDirectory(Path.GetDirectoryName(output)!);

    using MemoryStream stream = imageService.ResizeImage(new FileResizeOptions()
    {
        FilePath = input,
        Width = resolution,
        Height = resolution,
    }, output);

    using var outputStream = File.Open(output, FileMode.OpenOrCreate);
    await stream.CopyToAsync(outputStream);
}