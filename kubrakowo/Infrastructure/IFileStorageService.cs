using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubrakowo.WebApp.Infrastructure
{
    public interface IFileStorageService
    {
        public Task<byte[]> GetFile(string containerName, string fileName);
        public Task<string> GetUrlAsync(string containerName, string fileName);
    }
}
