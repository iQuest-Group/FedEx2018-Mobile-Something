using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinClient.Dto;
using XamarinClient.Models;

namespace XamarinClient.Services
{
    public class GameService
    {
        private HttpClient _client;

        public GameService()
        {
            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<string> Register(UserDto userDto)
        {
            var uri = new Uri("http://10.124.2.119:50001/tictactoe/api/game/register");
            var body = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync(uri, body);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var id = JsonConvert.DeserializeObject<string>(content);
                    return id;
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return string.Empty;
        }

        public async Task<GameStateDto> GetGameStatus()
        {
            var uri = new Uri("http://10.124.2.119:50001/tictactoe/api/game/state");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var gameState = JsonConvert.DeserializeObject<GameStateDto>(content);
                    return gameState;
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return null;
        }

        public async Task<GameStateDto> MakeMove(MoveDto moveDto)
        {
            var uri = new Uri("http://10.124.2.119:50001/tictactoe/api/game/move");
            var body = new StringContent(JsonConvert.SerializeObject(moveDto), Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync(uri, body);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var gameState = JsonConvert.DeserializeObject<GameStateDto>(content);
                    return gameState;
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return null;

        }

        public async Task Reset()
        {
            var uri = new Uri("http://10.124.2.119:50001/tictactoe/api/game/reset");

            try
            {
                var response = await _client.PutAsync(uri, null);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
        }
    }
}
