using System.ComponentModel.DataAnnotations;

namespace Fahrschule.Infrastructure.Persistence
{
    public class CosmosDbOptions
    {
        public const string Schueler = "Schueler";
        public const string Lehrer = "Lehrer";
        public const string Termin = "Termin";

        public static string[] GetAllNames()
        {
            return new[] {
                CosmosDbOptions.Schueler, CosmosDbOptions.Lehrer, CosmosDbOptions.Termin };
        }

        [Required]
        public string DatabaseName { get; set; }

        [Required]
        public string ContainerName { get; set; }

        public string AuthKeyOrResourceToken { get; set; }

        [Required]
        public string AccountEndpoint { get; set; }

        [Required]
        public int DefaultDatabaseRUs { get; set; }
    }

}
