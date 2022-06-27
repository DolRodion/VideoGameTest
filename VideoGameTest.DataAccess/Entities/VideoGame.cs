using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameTest.DataAccess.Entities
{
    public class VideoGame : BaseEntities
    {
        /// <summary>
        /// Название игры
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// Студия разработчик игры
        /// </summary>
        public string StudioDeveloper { get; set; }

        /// <summary>
        /// Картинка игры
        /// </summary>
        public string? GamePicture { get; set; }

        /// <summary>
        /// Список жанров
        /// </summary>
        public ICollection<GameType> GameTypes { get; set; }

        public VideoGame()
        {
            GameTypes = new List<GameType>();
        }
    }
}
