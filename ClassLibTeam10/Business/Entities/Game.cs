using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam10.Business.Entities
{
 
    //Alle gekozen kolomcategoriën voor de retrogametabel.
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string DeveloperName { get; set; }
        public string GameGenre { get; set; }
        public double GamePrice { get; set; }
        public string ImageTag { get; set; }
        public string AudioTag { get; set; }

    }
}

