using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbModels;
using Notion_Clone.Api.Database;

namespace Notion_Clone.Api.Services
{
    public class ListService
    {
        private readonly IMongoCollection<Exercise> _listCollection;
        public ListService(IOptions<ListDatabaseSettings> listDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            listDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                listDatabaseSettings.Value.DatabaseName);

            _listCollection = mongoDatabase.GetCollection<Exercise>(
                listDatabaseSettings.Value.ListCollectionName);
        }
        public async Task<List<Exercise>> GetAsync() =>
        await _listCollection.Find(_ => true).ToListAsync();
        public async Task CreateAsync(Exercise newTask) =>
        await _listCollection.InsertOneAsync(newTask);
    }
}
