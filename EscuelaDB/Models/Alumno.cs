using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EscuelaDB.Models
{
    public class Alumno
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Nombre")]
        public string AlumnoNombre { get; set; } = null!;
        public string Curso { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
    }
}
