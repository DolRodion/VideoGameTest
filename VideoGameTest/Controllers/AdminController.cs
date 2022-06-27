using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VideoGameTest.Application.Interface;
using VideoGameTest.Application.Models;
using VideoGameTest.Application.Params;

namespace VideoGameTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        /// <summary>
        /// Добавление видеоигры в БД
        /// </summary>
        /// <param name="FormAddVideoGameParams"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddVideoGame")]
        public async Task<ActionResult<bool>> AddVideoGameAsync(FormAddVideoGameParams formAddVideoGameParams)
        {
            var result = await _adminService.AddVideoGameAsync(formAddVideoGameParams);

            return Ok(result);
        }

        /// <summary>
        /// Удаление игры
        /// </summary>
        [HttpGet]
        [Route("RemoveVideoGameById")]
        public async Task<ActionResult<bool>> RemoveVideoGameByIdAsync(int videoGameId)
        {
            var result = await _adminService.RemoveVideoGameByIdAsync(videoGameId);

            return Ok(result);
        }

        /// <summary>
        /// Получение игры по Id
        /// </summary>
        [HttpGet]
        [Route("GetVideoGameById")]
        public async Task<ActionResult<VideoGameModel>> GetVideoGameByIdAsync(int id)
        {
            var result = await _adminService.GetVideoGameByIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Редактирование видеоигры в БД
        /// </summary>
        /// <param name="FormAddVideoGameParams"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("EditVideoGame")]
        public async Task<ActionResult<bool>> EditVideoGameAsync(FormAddVideoGameParams formAddVideoGameParams)
        {
            var result = await _adminService.EditVideoGameAsync(formAddVideoGameParams);  

            return Ok(result);
        }

        /// <summary>
        /// Удаление всех игр
        /// </summary>
        [HttpGet]
        [Route("RemoveAllVideoGames")]
        public async Task<ActionResult<bool>> RemoveVideoGameыAsync()
        {
            var result = await _adminService.RemoveAllVideoGamesAsync();

            return Ok(result);
        }
    }
}
