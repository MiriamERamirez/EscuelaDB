using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EscuelaDB.Models
{
    public class Calificacion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Materia")]
        public string MateriaNombre { get; set; } = null!;
        public string Alumno { get; set; } = null!;
        public decimal Nota { get; set; }
    }
}
