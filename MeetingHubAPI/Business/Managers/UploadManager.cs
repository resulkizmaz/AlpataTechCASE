using Microsoft.AspNetCore.Http;

namespace Business
{
    public class UploadManager: IUploadService
    {



        public UploadManager() { }
        public async Task<string> UploadSubscriberDocument(IFormFile file)
        {
            try
            {
                string folderName = Path.Combine("Resources", "Subscriber", "Document");
                string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                Directory.CreateDirectory(pathToSave);

                if (file != null)
                {
                    string extent = Path.GetExtension(file.FileName);
                    string filename = $"{Guid.NewGuid()}{extent}";
                    string fullpath = Path.Combine(pathToSave, filename);
                    string dbPath = Path.Combine(folderName, filename);

                    using (FileStream stream = new FileStream(fullpath, FileMode.Create))
                        await file.CopyToAsync(stream);

                    return dbPath;
                }

                return null;               
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
