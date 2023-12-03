using AgilePJAPINhomC.Data;
using AgilePJAPINhomC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace AgilePJAPINhomC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestUpDownController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public TestUpDownController(ApplicationDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [HttpPost(Name = "UploadFile")]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> UploadFile(IFormFile file, CancellationToken cancellationToken)
        {
            var fileType = Path.GetExtension(file.FileName);
            try
            {
                //var fileType = Path.GetExtension(file.FileName);
                
                if (fileType.ToLower() == ".mp4" || fileType.ToLower() == ".mkv" || fileType.ToLower() == ".avi"
                    || fileType.ToLower() == ".webm" || fileType.ToLower() == ".mov")
                {
                    var result = await this.WriteFile(file);
                    if (_context.Clip == null)
                    {
                        return Problem("Entity set 'ApplicationDbContext.Clip'  is null.");
                    }
                    Clip clip = new Clip();
                    clip.DateUpload = DateTime.Now;
                    clip.ClipName = file.FileName;
                    clip.ClipStatus = 1; 
                    clip.Filepath = Path.Combine(Directory.GetCurrentDirectory(), "Data\\Files");
                    clip.ClipDesc = file.ContentType.ToString();
                    var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                    var fileExtension = Path.GetExtension(clip.Filepath);
                    var thumbJpegStream = file.FileName.Replace(fileExtension, ".jpg");
                      ffMpeg.GetVideoThumbnail(clip.Filepath, thumbJpegStream, 5);
                    clip.Thumbnail = thumbJpegStream;
                    clip.Filesize =  ((int)file.Length);
                    clip.ChannelId.ChannelId = 1;

                    _context.Clip.Add(clip);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetClip", new { id = clip.ClipId }, clip);
                    // return Ok(result);
                } else
                { 
                     return BadRequest("This is not a video");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name = "DownloadFile")]

        public async Task<ActionResult> DownloadFile(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data\\Files", fileName);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contenttype, Path.GetFileName(filePath));
        }
        private async Task<string> WriteFile(IFormFile file)
        {
            string fileName = file.FileName;
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data\\Files");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Data\\Files", fileName);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return fileName;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            return fileName;
        }
    }
}
