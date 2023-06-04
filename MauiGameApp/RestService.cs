using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibTeam10.Business.Entities;
using Newtonsoft.Json;

namespace MauiGameApp
{
    
    internal class RestService
    {
        private string REST_URL
        { get; set; }
        private bool IsAndroid() =>
        DeviceInfo.Current.Platform ==
        DevicePlatform.Android;
        string serializedstring;
        List<Game> games;
        public RestService() 
        {
            REST_URL = IsAndroid() ?
            "http://10.0.2.2:7155/api/Game/GetAllGames" :
            "http://localhost:7155/api/Game/GetAllGames";
        }
        public HttpClient HttpClient = new HttpClient();

        public async Task<List<Game>> getGames()
        {
            try
            {
                HttpResponseMessage Response = await HttpClient.GetAsync(REST_URL);
                if (Response.IsSuccessStatusCode) 
                {
                    serializedstring = await Response.Content.ReadAsStringAsync();
                    games = JsonConvert.DeserializeObject<List<Game>>(serializedstring);

                }
                
            }
            catch (Exception ex) 
            {
                Debug.WriteLine("Error found in RestService:", ex.Message);
            }
            return games;
        }
        


    }
}
