using Newtonsoft.Json;
using RickAndMortyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;

namespace RickAndMortyApi.Controllers
{
    public class CharactersController
    {
        private readonly HttpClient client;

        public CharactersController()
        {
            client = new HttpClient();
        }

        public async Task<CharactersList> GetAllCharacters()
        {
            try
            {
                CharactersList charactersList = new();
                HttpResponseMessage response = await client.GetAsync("https://rickandmortyapi.com/api/character");

                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                charactersList = JsonConvert.DeserializeObject<CharactersList>(responseJson);

                return charactersList!;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return null!;
            }
        }

    }
}
