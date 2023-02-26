using BookingHotelServer.Service.IService;
using Microsoft.AspNetCore.Components.Forms;

namespace BookingHotelServer.Service;

public class FileUpload : IFileUpload
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileUpload(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public bool DeleteFile(string fileName)
    {
        try
        {
            var path = $"{_webHostEnvironment.WebRootPath}\\RoomImages\\{fileName}";
            if(File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<string> UploadFile(IBrowserFile file)
    {
        try
        {
            FileInfo fileInfo = new FileInfo(file.Name);
            var fileName=Guid.NewGuid().ToString()+fileInfo.Extension;
            var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\RoomImages";
            //var path=Path.Combine(folderDirectory, fileName);
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "RoomImages", fileName);

            var memoryStreem= new MemoryStream();
            await file.OpenReadStream().CopyToAsync(memoryStreem);
            if (!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }

            await using(var fs= new FileStream(path,FileMode.Create,FileAccess.Write))
            {
                memoryStreem.WriteTo(fs);
            }
            var fullPath = $"RoomImages/{fileName}";
            return fullPath;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
