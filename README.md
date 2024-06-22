# Image Resizer for Mobile App

## Overview
The **Image Resizer for Android** is a .NET console application designed to resize images for various Android screen densities. This tool simplifies the process of generating appropriately scaled images for ldpi, mdpi, hdpi, xhdpi, xxhdpi, and xxxhdpi from a single source image.

## Features
* **Batch Processing:** Resize all images in a specified folder.
* **Multiple Resolutions:** Generate images for six different Android screen densities.
* **Easy to Use:** Simple command-line interface for efficient usage.

## Prerequisites
* .NET 6.0 SDK or later
* A folder containing the source images

## Installation
1. Clone the repository or download the application package.

2. Navigate to the project directory.

3. Build the application using the .NET CLI:
``` bash
dotnet build
```

## Usage
To run the application, use the following command format:

```
dotnet run -- [path_to_images_folder]
```
Replace [path_to_images_folder] with the actual path to the folder containing your source images.

## Example
```
dotnet run -- C:\Users\YourUsername\Pictures\SourceImages
```

## Screen Density Multipliers
The application uses the following scale factors to resize images:

* **ldpi:** 0.75x
* **mdpi:** 1x (baseline)
* **hdpi:** 1.5x
* **xhdpi:** 2x
* **xxhdpi:** 3x
* **xxxhdpi:** 4x

## Output
The resized images will be saved in subfolders within the specified input folder, named according to the target densities:

* **ldpi**
* **mdpi**
* **hdpi**
* **xhdpi**
* **xxhdpi**
* **xxxhdpi**
Each subfolder will contain the corresponding resized images.

Example Directory Structure
Before running the application:

```
📂 SourceImages
├── 🗎 image1.png
├── 🗎 image2.png
└── 🗎 image3.jpg
```
After running the application:

```
📂 OutputImages
├── 📂 ldpi
│   ├── 🗎 image1.png
│   ├── 🗎 image2.png
│   └── 🗎 image3.jpg
├── 📂 mdpi
│   ├── 🗎 image1.png
│   ├── 🗎 image2.png
│   └── 🗎 image3.jpg
├── 📂 hdpi
│   ├── 🗎 image1.png
│   ├── 🗎 image2.png
│   └── 🗎 image3.jpg
├── 📂 xhdpi
│   ├── 🗎 image1.png
│   ├── 🗎 image2.png
│   └── 🗎 image3.jpg
├── 📂 xxhdpi
│   ├── 🗎 image1.png
│   ├── 🗎 image2.png
│   └── 🗎 image3.jpg
└── 📂 xxxhdpi
│   ├── 🗎 image1.png
│   ├── 🗎 image2.png
│   └── 🗎 image3.jpg
```
## Error Handling
The application includes basic error handling for common issues such as:

* Invalid input directory
* Non-image files in the input directory
* Read/write permissions issues

## Contributing
Contributions are welcome! Please follow these steps:

1. Fork the repository.
1. Create a new branch (**git checkout -b feature-branch**).
1. Commit your changes (**git commit -am 'Add new feature'**).
1. Push to the branch (**git push origin feature-branch**).
1. Create a new Pull Request.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.

## Contact
For any issues or questions, please open an issue on GitHub or contact the project maintainers.
