using ClassLibTeam10.Data.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibTeam10.Business.Entities;


namespace ClassLibTeam10.Data
{
    internal class GameData : SqlServer
    {
        public GameData()
        {           
            TableName = "games";
        }
        public string TableName { get; set; }

        /// Haalt via SqlServer.cs tabeldata op van een gekozen tabel (Voorlopig enkel "games").
        public SelectResult Select()
        {
            return base.Select(TableName);
        }

        /// Bouwt gradueel een insertquery en insertcommand op om een rij toe te voegen aan de database
        /// Hier worden ook de datatypen van de rijen nogmaals gedeclareerd in SQL-stijl.       
        public InsertResult Insert(Game game)
        {
            var result = new InsertResult();
            try
            {
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {TableName} ");
                insertQuery.Append($"(gamename, developername, gamegenre, gameprice, imagetag, audiotag) VALUES ");
                insertQuery.Append($"(@gamename, @developername, @gamegenre, @gameprice, @imagetag, @audiotag); ");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {                    
                    insertCommand.Parameters.Add("@gamename", SqlDbType.VarChar).Value =
                        game.GameName;
                    insertCommand.Parameters.Add("@developername", SqlDbType.VarChar).Value =
                        game.DeveloperName;
                    insertCommand.Parameters.Add("@gamegenre", SqlDbType.VarChar).Value =
                        game.GameGenre;
                    insertCommand.Parameters.Add("@gameprice", SqlDbType.Float).Value =
                        game.GamePrice;
                    insertCommand.Parameters.Add("@imagetag", SqlDbType.VarChar).Value =
                        game.ImageTag;
                    insertCommand.Parameters.Add("@audiotag", SqlDbType.VarChar).Value =
                        game.AudioTag;
                    result = InsertRecord(insertCommand);
                }
            }
            //Exception is tijdelijk uitgezet wegens occasionele throw error
            //terwijl upload naar database en verkrijgen van data wel correct verloopt.
            //Zet opnieuw aan bij implementeren van nieuwe features.
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        public InsertResult SimpleInsert(Game game)
        {
            var result = new InsertResult();
            try
            {
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {TableName} ");
                insertQuery.Append($"(gamename, developername, gamegenre, gameprice) VALUES ");
                insertQuery.Append($"(@gamename, @developername, @gamegenre, @gameprice); ");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@gamename", SqlDbType.VarChar).Value =
                        game.GameName;
                    insertCommand.Parameters.Add("@developername", SqlDbType.VarChar).Value =
                        game.DeveloperName;
                    insertCommand.Parameters.Add("@gamegenre", SqlDbType.VarChar).Value =
                        game.GameGenre;
                    insertCommand.Parameters.Add("@gameprice", SqlDbType.Float).Value =
                        game.GamePrice;
                    result = InsertRecord(insertCommand);
                }
            }
            //Exception is tijdelijk uitgezet wegens occasionele throw error
            //terwijl upload naar database en verkrijgen van data wel correct verloopt.
            //Zet opnieuw aan bij implementeren van nieuwe features.
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }


    }
}
