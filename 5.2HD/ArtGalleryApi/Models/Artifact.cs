using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtGalleryApi.Models
{
    public class Artifact
    {
        [BsonId]
        [BsonElement("_id")]
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? ArtistId { get; set; }

        public List<string>? Tags { get; set; }
    }
}
