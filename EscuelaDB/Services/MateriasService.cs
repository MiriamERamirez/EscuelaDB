using EscuelaDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EscuelaDB.Services
{
    public class MateriasService
    {
        private readonly IMongoCollection<Materia> _materiasCollection;

        public MateriasService(IOptions<EscuelaDBDatabaseSettings> escuelaDBDatabaseSettings)
        {
            var mongoClient = new MongoClient(escuelaDBDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(escuelaDBDatabaseSettings.Value.DatabaseName);

            _materiasCollection = mongoDatabase.GetCollection<Materia>(escuelaDBDatabaseSettings.Value.MateriasCollectionName);
        }

        public async Task<List<Materia>> GetAsync() =>
            await _materiasCollection.Find(_ => true).ToListAsync();

        public async Task<Materia?> GetAsync(string id) =>
            await _materiasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Materia newMateria) =>
            await _materiasCollection.InsertOneAsync(newMateria);

        public async Task UpdateAsync(string id, Materia updateMateria) =>
            await _materiasCollection.ReplaceOneAsync(x => x.Id == id, updateMateria);

        public async Task RemoveAsync(string id) =>
            await _materiasCollection.DeleteOneAsync(x => x.Id == id);
    }
}
