using ClassLibTeam10.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibTeam10.Business.Entities;
using ClassLibTeam10.Data;
using ClassLibTeam10.Data.Framework;

namespace ClassLibTeam10.Business
{
    public static class Games
    {
        public static IEnumerable<Game> List()
        {
            return GameRepository.GameList;
        }

        /// GetGames start zoals gevraagd een nieuwe GameData instantie op 
        /// die via Select() de tabelwaarden ophaalt.
        /// (Verzoek via GameData.cs naar SqlServer.cs)        
        public static SelectResult GetGames()
        {
            GameData gameData = new GameData();
            return gameData.Select();            
        }
        /// Add voegt via GameRepository een nieuwe rij in in de database.
        /// De nodige data wordt meegegeven.
        /// </summary>        
        public static InsertResult Add(Game game)
        {
            GameData gameData = new GameData();
            return gameData.Insert(game);
            
        }

        public static InsertResult SimpleAdd(Game game)
        {
            GameData gameData = new GameData();
            return gameData.SimpleInsert(game);

        }


    }
}
