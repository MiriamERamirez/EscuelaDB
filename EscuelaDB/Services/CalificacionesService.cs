using EscuelaDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EscuelaDB.Services
{
    public class CalificacionesService
    {
        private readonly IMongoCollection<Calificacion> _calificacionesCollection;

        public CalificacionesService(IOptions<EscuelaDBDatabaseSettings> escuelaDBDatabaseSettings)
        {
            var mongoClient = new MongoClient(escuelaDBDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(escuelaDBDatabaseSettings.Value.DatabaseName);

            _calificacionesCollection = mongoDatabase.GetCollection<Calificacion>(escuelaDBDatabaseSettings.Value.CalificacionesCollectionName);
        }

        public async Task<List<Calificacion>> GetAsync() =>
            await _calificacionesCollection.Find(_ => true).ToListAsync();

        public async Task<Calificacion?> GetAsync(string id) =>
            await _calificacionesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Calificacion newCalificacion) =>
            await _calificacionesCollection.InsertOneAsync(newCalificacion);

        public async Task UpdateAsync(string id, Calificacion updateCalificacion) =>
            await _calificacionesCollection.ReplaceOneAsync(x => x.Id == id, updateCalificacion);

        public async Task RemoveAsync(string id) =>
            await _calificacionesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
