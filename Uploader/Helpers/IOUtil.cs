using Uploader.Helpers;
using Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader.Helper
{
    internal class IOUtil
    {
        public static string ExtractZipFileToTempDirectory(string zipFilePath)
        {
            if (!File.Exists(zipFilePath))
            {
                throw new FileNotFoundException($"File not found: {zipFilePath}");
            }

            var temporaryDirectoryPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(temporaryDirectoryPath);

            ZipFile.ExtractToDirectory(zipFilePath, temporaryDirectoryPath);

            return temporaryDirectoryPath;
        }

        public static string DownloadFileToTemp(Stream stream)
        {
            var filePath = Path.GetTempFileName();
            if (filePath == null) throw new CustomException("Error creating temp file.");

            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    stream.CopyTo(fileStream);
            }
            catch (Exception ex) { throw new CustomException("Error downloading activity.", ex); }

            return filePath;

        }

        internal static T JSONDeserialize<T>(string filePath)
        {
            T result;

            try
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    result = (T)serializer.Deserialize(file, typeof(T));
                }
            }
            catch (Exception ex) { throw new CustomException("Error reading activity file.", ex); }

            return result;
        }
    }

    /* Todo: Delete leftover files
     * try
        {
            Directory.Delete(TemporaryDirectoryPath, true); // true means recursive delete
        }
        catch { /* Ignore any exceptions when trying to delete the directory */
}