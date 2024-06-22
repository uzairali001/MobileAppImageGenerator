namespace MobileAppImageGenerator.Core.Models;
public class FileResizeOptions
{
    /// <summary>
    /// The path of the file to be resized.
    /// </summary>
    public required string FilePath { get; set; }

    /// <summary>
    /// Desired output width of the image.
    /// </summary>
    public required int Width { get; set; }

    /// <summary>
    /// Desired output height of the image.
    /// </summary>
    public required int Height { get; set; }

    /// <summary>
    /// The level of quality to use when scaling the pixels.
    /// </summary>
    public ImageQuality ScaleQuality { get; set; } = ImageQuality.High;

    /// <summary>
    /// The file format used to encode the image.
    /// </summary>
    public ImageType OutputType { get; set; } = ImageType.Png;

    /// <summary>
    /// The quality level to use for the image. This is in the range from 0-100.
    /// </summary>
    public int Quality { get; set; } = 90;
}
