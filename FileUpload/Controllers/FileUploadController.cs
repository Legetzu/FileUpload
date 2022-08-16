using Microsoft.AspNetCore.Mvc;



namespace FileUpload.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        
        public IActionResult Get()
        {
            return Ok("File Uploader running");
        }
        [HttpPost]
        [Route("upload")]
        public IActionResult Upload(IFormFile file)
        {
            string extension; // file's extension.
            string path; // path to folder.
            string link; // path as a link. Meant for web servers.
            string name; // file's randomized name
            string savePath; // Path, where the file is saved. Basically path + name
            if (file != null)
            {
                Console.WriteLine("Got a file: {0}", file);
                extension = Path.GetExtension(file.FileName);
                path = GetPath(extension, out link);
                if (path == "")
                {
                    Console.WriteLine("Extension not allowed");
                    return BadRequest("Extension not allowed");
                }
            }
            else
            {
                Console.WriteLine("No file");
                return BadRequest("No file");
            }

            name = NameGenerator(path, extension);
            savePath = Path.Combine(path, name);
            var linkPath = Path.Combine(link, name);
            var stream = new FileStream(savePath, FileMode.Create);
            file.CopyTo(stream);
            Console.WriteLine("File uploaded to {0}",savePath);
            return Ok(new { linkPath });    
        }
        private static string GetPath(string ext, out string link)  // Checks the file's extension and then returns the path and link.
        {
            if (Values.Settings.imageExt.Contains(ext) == true)
            {
                link = Values.Settings.domain + Values.Settings.imageLocation;
                return Values.Settings.imagePath;
            }
            else if (Values.Settings.videoExt.Contains(ext) == true)
            {
                link = Values.Settings.domain + Values.Settings.videoLocation;
                return Values.Settings.videoPath;
            }
            else
            {
                link = "";
                return "";
            }
        }
        private static string NameGenerator(string path, string ext) // Generating a random name for the file.
        {
            var random = new Random();
            string name = random.Next(000000, 999999).ToString() + ext;
            while (System.IO.File.Exists(path + name) == true)
            {
                name = random.Next(000000, 999999).ToString() + ext;
            }
            return name;
        }
    }
}
