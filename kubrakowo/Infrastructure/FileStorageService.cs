using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;

namespace Kubrakowo.WebApp.Infrastructure
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FileStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("FileStorage");
        }
        public async Task<byte[]> GetFile(string containerName, string fileName)
        {
            var blobClient = new BlobClient(_connectionString, containerName, fileName);
            var result = await blobClient.DownloadStreamingAsync();
            var memoryStream = new MemoryStream();
            await result.Value.Content.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
        public async Task<string> GetUrlAsync(string containerName, string fileName)
        {
            var blobClient = new BlobClient(_connectionString, containerName, fileName);
            var url = await blobClient.ExistsAsync() ? blobClient.Uri.AbsoluteUri : string.Empty;
            return url;
        }
        public async Task<bool> Upload(Stream stream, string containerName, string fileName, string contentType)
        {
            try
            {
                await EnsureContainerExistsAsync(containerName);
                var blobClient = new BlobClient(_connectionString, containerName, fileName);
                await blobClient.UploadAsync(stream, overwrite: true);
                BlobHttpHeaders headers = new BlobHttpHeaders();
                headers.ContentType = contentType;
                blobClient.SetHttpHeaders(headers);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File has not been uploaded to blob storage. Exception {ex}.");
                return false;
            }
        }

        private async Task EnsureContainerExistsAsync(string containerName)
        {
            var blobContainerClient = new BlobContainerClient(_connectionString, containerName);
            await blobContainerClient.CreateIfNotExistsAsync();
            await blobContainerClient.SetAccessPolicyAsync(PublicAccessType.Blob);
        }
    }
}
