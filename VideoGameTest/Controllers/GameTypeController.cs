using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VideoGameTest.Application.Interface;
using VideoGameTest.Application.Models;

namespace VideoGameTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameTypeController : ControllerBase
    {
        private readonly IGameTypeService _gameTypeService;

        public GameTypeController(IGameTypeService gameTypeService)
        {
            _gameTypeService = gameTypeService;
        }

        /// <summary>
        /// Получить жанры
        /// </summary>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<string[]>> GetAllAsync()
        {
            var result = await _gameTypeService.GetAllAsync();

            return Ok(result);
        }
    }
}
