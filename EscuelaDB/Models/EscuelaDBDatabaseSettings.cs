namespace EscuelaDB.Models
{
    public class EscuelaDBDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProfesoresCollectionName { get; set; } = null!;
        public string MateriasCollectionName { get; set; } = null!;
        public string AlumnosCollectionName { get; set; } = null!;
        public string CalificacionesCollectionName { get; set; } = null!;
    }
}
