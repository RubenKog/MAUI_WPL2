using System;

namespace ClassLibTeam10.Data.Framework
{
    static class Settings
    {
        public static string GetConnectionString()
        {
            String connectionString = "Trusted_Connection = True;";
            
            connectionString += $@"Server=LAPTOP-5R72ANGP\PXLRUBENSQL;";
            connectionString += $"Database=DB_Ruben_Kog;";
            return connectionString;
        }
    }
}
