using EscuelaDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EscuelaDB.Services
{
    public class ProfesoresService
    {
        private readonly IMongoCollection<Profesor> _profesoresCollection;

        public ProfesoresService(IOptions<EscuelaDBDatabaseSettings> escuelaDBDatabaseSettings)
        {
            var mongoClient = new MongoClient(escuelaDBDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(escuelaDBDatabaseSettings.Value.DatabaseName);

            _profesoresCollection = mongoDatabase.GetCollection<Profesor>(escuelaDBDatabaseSettings.Value.ProfesoresCollectionName);
        }

        public async Task<List<Profesor>> GetAsync() =>
            await _profesoresCollection.Find(_ => true).ToListAsync();

        public async Task<Profesor?> GetAsync(string id) =>
            await _profesoresCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Profesor newProfesor) =>
            await _profesoresCollection.InsertOneAsync(newProfesor);

        public async Task UpdateAsync(string id, Profesor updateProfesor) =>
            await _profesoresCollection.ReplaceOneAsync(x => x.Id == id, updateProfesor);

        public async Task RemoveAsync(string id) =>
            await _profesoresCollection.DeleteOneAsync(x => x.Id == id);
    }
}
