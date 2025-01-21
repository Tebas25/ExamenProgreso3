using ExamenProgreso3.Interfaces;
using ExamenProgreso3.Models;
using SQLite;
using System.Text.Json.Nodes;

namespace ExamenProgreso3.Repositories
{
    public class PaisRepository : IPaisRepositoy
    {
        private static string NombreDB = "Almeida.db3";
        private SQLiteConnection _conexion;

        public PaisRepository() { Init(); }

        public void Init()
        {
            string _dbPath = Path.Combine(FileSystem.AppDataDirectory, NombreDB);
            _conexion = new SQLiteConnection(_dbPath);
            _conexion.CreateTable<PaisDB>();
        }

        public async Task PaisAPI(string nombrePais)
        {
            var pais = new PaisAPI();
            var client = new HttpClient();
            string url = "https://restcountries.com/v3.1/name/" + nombrePais + "?fields=name,region,maps";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(url);
            if (respuesta.IsSuccessStatusCode)
            {
                var responseBody = await respuesta.Content.ReadAsStringAsync();
                JsonNode node = JsonNode.Parse(responseBody);
                if (node is JsonArray array && array.Count > 0)
                {
                    JsonNode primerElemento = array[0];
                    string nombreOficial = primerElemento["name"]?["official"]?.ToString();
                    string region = primerElemento["region"]?.ToString();
                    string googleMaps = primerElemento["maps"]?["googleMaps"]?.ToString();
                    PaisDB Pais = new PaisDB()
                    {
                        Name = nombreOficial,
                        Region = region,
                        Map = googleMaps
                    };
                    UpdatePaisDb(Pais);
                }
            }
            else
            {
                Console.WriteLine("El nodo no es un objeto JSON.");
            }
        }

        public void UpdatePaisDb(PaisDB paisDB)
        {
            PaisDB pais = new PaisDB
            {
                Name = paisDB.Name,
                Region = paisDB.Region,
                Map = paisDB.Map
            };
            _conexion.Insert(pais);
        }

        public PaisDB GetPaisFromDb(string nombrePais)
        {
            return _conexion.Table<PaisDB>().FirstOrDefault(p => p.Name == nombrePais);
        }

    }
}
