using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ProductCrud.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        string connectionString;
        string containerName;
        IConfiguration _config;
        public BlobStorageService(IConfiguration config)
        {
            _config = config;
            connectionString = _config["Storage:Connection"];
            containerName = _config["Storage:Container"];
        }
        private string GenerateFileName(string fileName)
        {
            string[] strName = fileName.Split('.');
            string strFileName = DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." + strName[strName.Length - 1];
            return strFileName;
        }

        public async Task<string> UploadFileToBlobAsync(string strFileName, Stream content, string contentType)
        {
            string fileName = this.GenerateFileName(strFileName);
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            container.CreateIfNotExists();

            BlobClient blob = container.GetBlobClient(fileName);
            await blob.UploadAsync(content, new BlobHttpHeaders { ContentType = contentType });
            return blob.Uri.ToString();
        }

        public async Task<bool> DeleteBlobData(string fileUrl)
        {
            Uri uriObj = new Uri(fileUrl);
            string BlobName = Path.GetFileName(uriObj.LocalPath);

            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            BlobClient blob = container.GetBlobClient(BlobName);
           return await blob.DeleteIfExistsAsync();
        }


       
    }
}
