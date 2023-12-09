using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EscuelaDB.Models
{
    public class Materia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Nombre")]
        public string MateriaNombre { get; set; } = null!;
        public string Profesor { get; set; } = null!;
        public string Creditos { get; set; } = null!;
    }
}
