using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibTeam10.Data.Framework;
using ClassLibTeam10.Business.Entities;

namespace ClassLibTeam10.Data.Repositories
{
    static class GameRepository
    {
        static GameRepository()
        {
            GameList = new List<Game>();            
        }


        public static List<Game> GameList { get; set; }

        
        /// Een nieuwe GameData instantie wordt aangemaakt, en wordt gebruikt om de nieuwe rijdata in de database te plaatsen.       
        public static void Add(Game game)
        {
            GameList.Add(game);
            GameData GameData = new GameData();
            InsertResult insertResult = GameData.Insert(game);
        }



        /// GetId wordt voorlopig niet gebruikt, maar kan in theorie dienen om automatische ID-nummers te genereren. 
        /// Er is voor gekozen om de gebruiker zelf een ID te laten meegeven.
        /// GetId blijft voorlopig nog staan indien bij de volgende sprint gekozen wordt deze alsnog te implementeren.
        /// </summary>
        /// <returns></returns>        
        private static int GetId()
        {
            int id = 1;
            if (GameList.Count > 0)
            {
                id = GameList.Max(x => x.GameId) + 1;
            }
            return id;
        }
        
    }
}
