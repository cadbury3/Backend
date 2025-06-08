using Microsoft.AspNetCore.Mvc;
using ArtGalleryApi.Models;
using MongoDB.Driver;

namespace ArtGalleryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtifactsController : ControllerBase
    {
        private readonly IMongoCollection<Artifact> _artifacts;
        private readonly IMongoCollection<Counter> _counters;

        public ArtifactsController(MongoDbContext context)
        {
            _artifacts = context.Artifacts;
            _counters = context.Database.GetCollection<Counter>("Counters");
        }

        private int GetNextId()
        {
            var filter = Builders<Counter>.Filter.Eq(c => c.Id, "artifactid");
            var update = Builders<Counter>.Update.Inc(c => c.Seq, 1);

            var result = _counters.FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Counter>
                {
                    IsUpsert = true,
                    ReturnDocument = ReturnDocument.After
                });

            return result.Seq;
        }

        // GET: api/artifacts
        [HttpGet]
        public ActionResult<List<Artifact>> Get() =>
            _artifacts.Find(_ => true).ToList();

        // GET: api/artifacts/1
        [HttpGet("{id}")]
        public ActionResult<Artifact> Get(string id)
        {
            if (!int.TryParse(id, out int intId))
                return BadRequest("Invalid ID format.");

            var artifact = _artifacts.Find(a => a.Id == intId).FirstOrDefault();

            if (artifact == null)
                return NotFound();

            return artifact;
        }

        // POST: api/artifacts
        [HttpPost]
        public ActionResult<Artifact> Create(Artifact artifact)
        {
            artifact.Id = GetNextId();
            _artifacts.InsertOne(artifact);
            return CreatedAtAction(nameof(Get), new { id = artifact.Id }, artifact);
        }

        // PUT: api/artifacts/1
        [HttpPut("{id}")]
        public IActionResult Update(string id, Artifact updatedArtifact)
        {
            if (!int.TryParse(id, out int intId))
                return BadRequest("Invalid ID.");

            var existing = _artifacts.Find(a => a.Id == intId).FirstOrDefault();
            if (existing == null)
                return NotFound();

            updatedArtifact.Id = intId;
            _artifacts.ReplaceOne(a => a.Id == intId, updatedArtifact);
            return NoContent();
        }

        // DELETE: api/artifacts/1
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!int.TryParse(id, out int intId))
                return BadRequest("Invalid ID.");

            var result = _artifacts.DeleteOne(a => a.Id == intId);

            if (result.DeletedCount == 0)
                return NotFound();

            return NoContent();
        }
    }

    public class Counter
    {
        public string Id { get; set; }
        public int Seq { get; set; }
    }
}
