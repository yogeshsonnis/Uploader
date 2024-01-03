using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using System.IO;
using Azure;
using Azure.Storage.Blobs.Models;

namespace Uploader.DB
{
    internal class BlobStorageRepo
    {
        private readonly string connectionString;
        private readonly string containerName;
        private readonly BlobContainerClient containerClient;

        public BlobStorageRepo(string connectionString, string containerName)
        {
            this.connectionString = connectionString;
            this.containerName = containerName;
            this.containerClient = new BlobContainerClient(connectionString, containerName);
        }

        // Create or overwrite a blob
        public async Task UploadAsync(string blobName, Stream stream)
        {
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(stream, true); // true means overwrite if already exists
        }

        // Read a blob to a stream
        public async Task<Stream> DownloadAsync(string blobName)
        {
            var blobClient = containerClient.GetBlobClient(blobName);
            var response = await blobClient.OpenReadAsync();
            return response;
        }

        // Update a blob
        public async Task UpdateAsync(string blobName, Stream stream)
        {
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(stream, true); // true means overwrite
        }

        // Delete a blob
        public async Task DeleteAsync(string blobName)
        {
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();
        }

        public List<string> GetBlobList()
        {
            var resultSegment = containerClient.GetBlobs().AsPages(default, 10);
            var blobList = new List<string>();

            foreach (Page<BlobItem> blobPage in resultSegment)
                foreach (BlobItem blobItem in blobPage.Values)
                    blobList.Add(blobItem.Name);

            return blobList;
        }
    }
}

