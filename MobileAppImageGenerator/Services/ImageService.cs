﻿using MobileAppImageGenerator.Core.Models;

using SkiaSharp;

namespace MobileAppImageGenerator.Core.Services;

public class ImageService
{
    public Stream ResizeImage(FileResizeOptions options, string output)
    {
        if (!File.Exists(options.FilePath))
        {
            throw new FileNotFoundException("Unable to find", options.FilePath);
        }

        using var stream = File.OpenRead(options.FilePath);
        using var skData = SKData.Create(stream);
        using var codec = SKCodec.Create(skData);

        var supportedScale = codec
             .GetScaledDimensions((float)options.Width / codec.Info.Width);

        var nearest = new SKImageInfo(supportedScale.Width, supportedScale.Height);
        using var destinationImage = SKBitmap.Decode(codec, nearest);
        using var resizedImage = destinationImage.Resize(new SKImageInfo(options.Width, options.Height), Enum.Parse<SKFilterQuality>(options.Quality.ToString()));

        var format = Enum.Parse<SKEncodedImageFormat>(options.OutputType.ToString());
        using var outputImage = SKImage.FromBitmap(resizedImage);
        using var data = outputImage.Encode(format, options.Quality);

        //return data.AsStream();
        //using var outputStream = File.Open(output, FileMode.OpenOrCreate);
        //data.SaveTo(outputStream);

        //Stream ms = new MemoryStream();
        //data.AsStream().CopyTo(ms);

        var ms = new MemoryStream();
        data.SaveTo(ms);
        ms.Position = 0;

        //using var outputStream = File.Open($"images/output_{Path.GetFileNameWithoutExtension(options.FilePath)}.png", FileMode.OpenOrCreate);
        //using var outputStream = File.Open(output, FileMode.OpenOrCreate);
        //ms.CopyTo(outputStream);

        return ms;

    }
}
