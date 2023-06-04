using ClassLibTeam10.Business;

using ClassLibTeam10.Business.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;




    

namespace WebApiTeam10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        /// HttpPost is noodzakelijk zodat Swagger weet dat dit een POST-methode is.
        /// De Route geeft dit een duidelijke naam in Swagger
        /// Add-methode in Games.cs wordt aangesproken om de post uit te voeren.
        /// een Game-instantie wordt gradueel opgebouwd om vervolgens door te geven. 
        [HttpPost]
        [Route("AddGame")]
        public void Addgame( string gameName, string developerName, string gameGenre, double gamePrice, string imageTag, string audioTag)
        {
            Game game = new Game();            
            game.GameName = gameName;
            game.DeveloperName = developerName;
            game.GameGenre = gameGenre;
            game.GamePrice = gamePrice;
            game.ImageTag = imageTag;
            game.AudioTag = audioTag;
            Games.Add(game);

        }
        [HttpPost]
        [Route("BasicAddGame")]
        public void BasicAddgame(string gameName, string developerName, string gameGenre, double gamePrice)
        {
            Game game = new Game();
            game.GameName = gameName;
            game.DeveloperName = developerName;
            game.GameGenre = gameGenre;
            game.GamePrice = gamePrice;            
            Games.SimpleAdd(game);

        }

        /// HttpGet is noodzakelijk zodat Swagger weet dat dit een GET-methode is.
        /// De Route geeft dit een duidelijke naam in Swagger 
        /// HttpGet is noodzakelijk zodat Swagger weet dat dit een GET-methode is.
        /// GetGames-methode in Games.cs wordt aangesproken om de post uit te voeren.    
        [HttpGet]
        [Route("GetAllGames")]
        public ActionResult GetAllGames()
        {
            var result = Games.GetGames();
            if (result.Succeeded)
            {
                var games = result.DataTable;
                string JSONresult = JsonConvert.SerializeObject(games);
                return Ok(JSONresult);
            }
            return NotFound();
        }


    }
}
