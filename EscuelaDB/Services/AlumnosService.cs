using EscuelaDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EscuelaDB.Services
{
    public class AlumnosService
    {
        private readonly IMongoCollection<Alumno> _alumnosCollection;

        public AlumnosService(IOptions<EscuelaDBDatabaseSettings> escuelaDBDatabaseSettings)
        {
            var mongoClient = new MongoClient(escuelaDBDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(escuelaDBDatabaseSettings.Value.DatabaseName);

            _alumnosCollection = mongoDatabase.GetCollection<Alumno>(escuelaDBDatabaseSettings.Value.AlumnosCollectionName);
        }

        public async Task<List<Alumno>> GetAsync() =>
            await _alumnosCollection.Find(_ => true).ToListAsync();

        public async Task<Alumno?> GetAsync(string id) =>
            await _alumnosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Alumno newAlumno) =>
            await _alumnosCollection.InsertOneAsync(newAlumno);

        public async Task UpdateAsync(string id, Alumno updateAlumno) =>
            await _alumnosCollection.ReplaceOneAsync(x => x.Id == id, updateAlumno);

        public async Task RemoveAsync(string id) =>
            await _alumnosCollection.DeleteOneAsync(x => x.Id == id);
    }
}
