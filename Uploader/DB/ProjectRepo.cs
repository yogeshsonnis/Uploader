using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Uploader.Helper;
using Uploader.Helpers;

namespace Uploader.DB
{
    internal class ProjectRepo
    {
        public static ProjectRepo SCIENCE_REPO = new ProjectRepo(ContainerSetting.SLIME_CONTAINER);

        private BlobStorageRepo blobStorageRepo;

        public ProjectRepo(ContainerSetting containerSetting) 
        {
            blobStorageRepo = new BlobStorageRepo(containerSetting.ConnectionString, containerSetting.ContainerName);
        }

        public IEnumerable<ProjectItem> GetProjectItemList()
        {
            var blobList = blobStorageRepo.GetBlobList();
            var projectList = blobList.Select(x => new ProjectItem(x));
            return projectList;
        }

        internal async Task<ProjectInfo> GetProjectAsync(string projectFile)
        {
            var response = await blobStorageRepo.DownloadAsync(projectFile);

            if (response == null) throw new CustomException("Error reading file from cloud.");

            var fileName = IOUtil.DownloadFileToTemp(response);
            var directory = IOUtil.ExtractZipFileToTempDirectory(fileName);
            var fullPath = Path.Combine(Path.Combine(directory, Path.GetFileNameWithoutExtension(projectFile)), ContainerSetting.INFO_FILE_NAME);
            ProjectInfo project = IOUtil.JSONDeserialize<ProjectInfo>(fullPath);

            return project;
        }
    }
}
