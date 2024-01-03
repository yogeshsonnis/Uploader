namespace Uploader.DB
{
    public class ProjectItem
    {
        public string Identifier { get; private set; }
        public string Name { get { return Identifier; } }

        public ProjectItem(string identifier)
        {
            this.Identifier = identifier;
        }
    }
}