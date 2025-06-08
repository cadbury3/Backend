using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtGalleryApi.Models
{
    public class Artist
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Name { get; set; }
        public string? Tribe { get; set; }
        public string? Biography { get; set; }
    }
}