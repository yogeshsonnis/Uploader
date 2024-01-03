using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader.DB
{
    public class ContainerSetting
    {
        public const string CONNECTION_STRING = "DefaultEndpointsProtocol=https;AccountName=flatomdev;AccountKey=OCeDRFKnlJYEOsXkiogcarfyPAsDFrR9wOgziAZmZOe+bI/NJQhmbbBZ+UrvnwL4X9Bw4VZTO0Ln+ASt1OkasA==;EndpointSuffix=core.windows.net";
        public const string INFO_FILE_NAME = "info.json";

        public string ContainerName { get; private set; }
        public string ConnectionString {get; private set;}

        private ContainerSetting(string connectionString, string containerName)
        {
            ConnectionString = connectionString;
            this.ContainerName = containerName;
        }

        public static ContainerSetting ART_CONTAINER = new ContainerSetting(CONNECTION_STRING, "art-projects");
        public static ContainerSetting LAB_CONTAINER = new ContainerSetting(CONNECTION_STRING, "lab-projects");
        public static ContainerSetting MATERIAL_CONTAINER = new ContainerSetting(CONNECTION_STRING, "materials");
        public static ContainerSetting SLIME_CONTAINER = new ContainerSetting(CONNECTION_STRING, "robot-projects");
        public static ContainerSetting ROBOT_CONTAINER = new ContainerSetting(CONNECTION_STRING, "slime-projects");
        public static ContainerSetting[] StorageSettingList = new ContainerSetting[]
        {
            ART_CONTAINER,
            LAB_CONTAINER,
            SLIME_CONTAINER,
            ROBOT_CONTAINER
        };
    }
}
