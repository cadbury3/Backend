using ArtGalleryApi.Models;
using MongoDB.Driver;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        _database = client.GetDatabase(config["MongoDB:DatabaseName"]);
    }

    public IMongoCollection<Artist> Artists => _database.GetCollection<Artist>("Artists");
    public IMongoCollection<Artifact> Artifacts => _database.GetCollection<Artifact>("Artifacts");
    public IMongoDatabase Database => _database;
}
