using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameTest.Application.Params
{
    public class FormAddVideoGameParams
    {
        public int Id { get; set; }
        /// <summary>
        /// Название игры
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// Студия разработчик
        /// </summary>
        public string StudioDeveloper { get; set; }

        /// <summary>
        /// Картинка игры
        /// </summary>
        public string? GamePicture { get; set; }

        /// <summary>
        /// Жанр/Ы игры
        /// </summary>
        public string GameType { get; set; }
    } 
}
