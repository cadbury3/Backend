using ArtGalleryApi.Models;
using MongoDB.Driver;

namespace ArtGalleryApi.Services
{
    public class ArtistService
    {
        private readonly IMongoCollection<Artist> _artists;

        public ArtistService(MongoDbContext context)
        {
            _artists = context.Artists;
        }

        public List<Artist> Get() => _artists.Find(a => true).ToList();
        public Artist? Get(string id) => _artists.Find(a => a.Id == id).FirstOrDefault();
        public void Create(Artist artist) => _artists.InsertOne(artist);
        public void Update(string id, Artist artist) => _artists.ReplaceOne(a => a.Id == id, artist);
        public void Remove(string id) => _artists.DeleteOne(a => a.Id == id);
    }
}
