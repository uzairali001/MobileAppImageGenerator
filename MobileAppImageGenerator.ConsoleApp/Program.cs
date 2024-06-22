
ImageService imageService = new();

using var stream = imageService.ResizeImage(new FileResizeOptions()
{
    FilePath = "test.png",
    Width = 124,
    Height = 124,
});

var outputStream = File.Open("output.png", FileMode.OpenOrCreate);

stream.CopyTo(outputStream);

outputStream.Close();
stream.Close();