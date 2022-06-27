using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VideoGameTest.Application.Interface;
using VideoGameTest.Application.Models;

namespace VideoGameTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IVideoGameService _videoGameService;
        public HomeController(IVideoGameService videoGameService)
        {
            _videoGameService = videoGameService;
        }

        /// <summary>
        /// Получить все игры
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllVideoGame")]
        public async Task<ActionResult<VideoGameModel[]>> GetAllVideoGameAsync()
        {
            var result = await _videoGameService.GetAllVideoGameAsync();

            return Ok(result);
        }

        /// <summary>
        /// Получение всех видеоигра по жанру
        /// </summary>
        [HttpGet]
        [Route("GetVideoGameByGameType")]
        public async Task<ActionResult<VideoGameModel[]>> GetVideoGameByGameTypeAsync(string gameTypeName)
        {
            var result = await _videoGameService.GetVideoGameByGameTypeAsync(gameTypeName);

            return Ok(result);
        }
    }
}
