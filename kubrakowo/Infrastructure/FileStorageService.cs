using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
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
    }
}
