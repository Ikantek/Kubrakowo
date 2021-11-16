using System.IO;
using System.Threading.Tasks;

namespace Kubrakowo.WebApp.Infrastructure
{
    public interface IFileStorageService
    {
        public Task<byte[]> GetFile(string containerName, string fileName);
        public Task<string> GetUrlAsync(string containerName, string fileName);
        public Task<bool> Upload(Stream stream, string containerName, string fileName, string contentType);
    }
}
