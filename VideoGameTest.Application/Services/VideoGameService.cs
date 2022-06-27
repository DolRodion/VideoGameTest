using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameTest.Application.Constants;
using VideoGameTest.Application.Interface;
using VideoGameTest.DataAccess.Entities;
using VideoGameTest.DataAccess.Interfaces;

namespace VideoGameTest.Application.Models
{
    public class VideoGameService : IVideoGameService
    {
        private readonly IGenericRepository<VideoGame> _videoGameRepository;
        private readonly IGameTypeService _gameTypeService;

        public VideoGameService(IGenericRepository<VideoGame> videoGameRepository, IGameTypeService gameTypeService)
        {
            _videoGameRepository = videoGameRepository;
            _gameTypeService = gameTypeService;
        }

        /// <summary>
        /// Получение всех игр
        /// </summary>
        /// <returns></returns>
        public async Task<VideoGameModel[]> GetAllVideoGameAsync()
        {
            var result = await _videoGameRepository.AsQueryable()
                .Select(q => new VideoGameModel
                {
                    Id = q.Id,
                    GameName = q.GameName,  
                    GamePicture = q.GamePicture,
                    StudioDeveloper = q.StudioDeveloper
                }).ToArrayAsync();

            foreach (var item in result)
            {
                item.GameType = await _gameTypeService.GetGameTypeByVideoGameIdAsync(item.Id);
            }

            return result;
        }

        /// <summary>
        /// Получение игры/р по жанру
        /// </summary>
        public async Task<VideoGameModel[]> GetVideoGameByGameTypeAsync(string gameTypeName)
        {
            if (gameTypeName == string.Empty)
            {
                throw new ArgumentNullException("Неверный идентификатор");
            }

            var query = _videoGameRepository.AsQueryable();

            //Фильтр для выбранной записи
            if (gameTypeName != DefaultFiltrValue.GameTypeAll)
            {
                query = query.Where(q => q.GameTypes.Any(w => w.Name == gameTypeName));
            }
  
            var result = await query.Select(q => new VideoGameModel
            {
                Id = q.Id,
                GameName = q.GameName,
                StudioDeveloper = q.StudioDeveloper,
                GamePicture = q.GamePicture,
            })
            .ToArrayAsync();

            foreach (var item in result)
            {
                item.GameType = await _gameTypeService.GetGameTypeByVideoGameIdAsync(item.Id);
            }

            return result;
        }

        /// <summary>
        /// Добавление новой игры в БД
        /// </summary>
        /// <returns></returns>
        public async Task AddVideoGameAsync(VideoGame videoGame)
        {
            await _videoGameRepository.InsertAsync(videoGame);
            await _videoGameRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Метод для удаления записи в БД
        /// </summary>
        public async Task<bool> RemoveVideoGameByIdAsync(int videoGameId)
        {
            if (videoGameId == 0)
            {
                throw new ArgumentNullException("Не верный ID");
            }

            await _videoGameRepository.DeleteAsync(videoGameId);
            await _videoGameRepository.SaveChangesAsync();

            return true;
        }

        public async Task RemoveAllVideoGamesAsync()
        { 
            var allVideogames = await _videoGameRepository.AsQueryable().Select(q => q.Id).ToListAsync();

            foreach (var item in allVideogames)
            {
                await _videoGameRepository.DeleteAsync(item);
            }

            await _videoGameRepository.SaveChangesAsync();
        }

        public async Task UpdateVideoGame()
        {
            try
            {
                await _videoGameRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка сохранения игры");
            }
            
        }

    }
}
