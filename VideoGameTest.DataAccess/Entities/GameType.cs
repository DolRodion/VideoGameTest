using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameTest.DataAccess.Entities
{
   public class GameType : BaseEntities
    {
        /// <summary>
        /// Название видеоигры
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список игр
        /// n:m
        /// </summary>
        public ICollection<VideoGame> VideoGames { get; set; }

        public GameType(string name)
        {
            Name = name;
            VideoGames = new List<VideoGame>();
        }
    }
}
