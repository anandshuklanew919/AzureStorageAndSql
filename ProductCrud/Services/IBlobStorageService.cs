
namespace ProductCrud.Services
{
    public interface IBlobStorageService
    {
        Task<bool> DeleteBlobData(string fileUrl);
        Task<string> UploadFileToBlobAsync(string strFileName, Stream content, string contentType);
    }
}