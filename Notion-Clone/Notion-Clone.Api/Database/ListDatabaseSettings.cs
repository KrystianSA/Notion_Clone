namespace Notion_Clone.Api.Database
{
    public class ListDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ListCollectionName { get; set; } = null!;
    }
}
