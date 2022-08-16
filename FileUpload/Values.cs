using System;


namespace Values
{
class Settings
{
    // Path could be web server's path, if you want to upload files to web server.
    public const string path = @"C:\Users\haiki\Pictures";

    // Used for providing the link for web server.
    public const string domain = "http://localhost/";

    // Image location inside the path
    public static readonly string imageLocation = Path.Combine("Files", "Images"); // Basically outputs \Files\Images by default
    public static readonly string imagePath = Path.Combine(path, imageLocation); // Combines path and Images path. On default /var/www/html/Files/Images
    public static readonly string[] imageExt = { ".jpg", ".JPEG", ".png" }; // Allowed image extensions

    // Video location
    public static readonly string videoLocation = Path.Combine("Files", "Videos");
    public static readonly string videoPath = Path.Combine(path, videoLocation);
    public static readonly string[] videoExt = { ".mp4", ".mkv"};

    // If you needed to upload different kinds of files, you could add them below.
    // In example:
    // Game location
    // public static string gameLocation = Path.Combine("Files", "Games");
    // public string gamePath = Path.Combine(path, gameLocation);

    // You also need to add them to GetPath function inside FileUploadController.cs
}

}
