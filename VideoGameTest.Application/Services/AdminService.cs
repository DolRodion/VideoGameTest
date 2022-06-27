using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameTest.Application.Interface;
using VideoGameTest.Application.Models;
using VideoGameTest.Application.Params;
using VideoGameTest.DataAccess.Entities;
using VideoGameTest.DataAccess.Interfaces;

namespace VideoGameTest.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IGenericRepository<VideoGame> _videoGameRepository;
        private readonly IGameTypeService _gameTypeService;
        private readonly IVideoGameService _videoGameService;


        public AdminService(IGenericRepository<VideoGame> videoGameRepository,IGameTypeService gameTypeService, IVideoGameService videoGameService)
        {
            _videoGameRepository = videoGameRepository;
            _gameTypeService = gameTypeService;
            _videoGameService = videoGameService;
        }

        /// <summary>
        /// Метод для добавления новой записи в БД
        /// </summary>
        public async Task<bool> AddVideoGameAsync(FormAddVideoGameParams formAddVideoGameParams)
        {
            var entitiesGameType = await _gameTypeService.AddUnicalGameTypeAsync(formAddVideoGameParams.GameType.Split(","));

            await _videoGameService.AddVideoGameAsync(new VideoGame()
            {
                GameName = formAddVideoGameParams.GameName,
                StudioDeveloper = formAddVideoGameParams.StudioDeveloper,
                GamePicture = formAddVideoGameParams.GamePicture,
                GameTypes = entitiesGameType

            });

            return true;
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

            var gameTypeByVideGameId = await _gameTypeService.GetGameTypeByVideoGameIdAsync(videoGameId);

            var entityVideoGame = await _videoGameService.RemoveVideoGameByIdAsync(videoGameId);

            //ищем и удаляем entity gameType без связей
            foreach (var item in gameTypeByVideGameId.Split(","))
            {
                var query = _videoGameRepository.AsQueryable()
                .Where(q => q.GameTypes
                .Any(w => w.Name == item)).FirstOrDefault();

                if (query == null)
                {
                    var GameTypeId = await _gameTypeService.GetGameTypeIdByName(item);
                    await _gameTypeService.RemoveGameTypeAsync(GameTypeId);
                }
            }
             

            return entityVideoGame;
        }

        /// <summary>
        /// Метод для получения игры по Id
        /// </summary>
        public async Task<VideoGameModel> GetVideoGameByIdAsync(int videoGameId)
        {
            if (videoGameId == 0)
            {
                throw new ArgumentNullException("Неверный идентификатор");
            }

            var result = await _videoGameRepository.AsQueryable()
                .Where(q => q.Id == videoGameId)
                .Select(q => new VideoGameModel
                {
                    Id = q.Id,
                    GameName = q.GameName,
                    GamePicture = q.GamePicture,
                    StudioDeveloper = q.StudioDeveloper,

                }).FirstOrDefaultAsync();


            result.GameType = await _gameTypeService.GetGameTypeByVideoGameIdAsync(videoGameId);


            if (result == null)
            {
                throw new ArgumentNullException($"Запись с id = {videoGameId} не найдена");
            }

            return result;
        }

        /// <summary>
        /// Метод для редактирования игры
        /// </summary>
        /// <returns></returns>
        public async Task<bool> EditVideoGameAsync(FormAddVideoGameParams formAddVideoGameParams)
        {
            //Получаем entity со связями
            var entity = await _videoGameRepository.AsQueryable().Include(y => y.GameTypes).Where(q => q.Id == formAddVideoGameParams.Id).FirstOrDefaultAsync();

            var nameGameTypesById = await _gameTypeService.GetGameTypeByVideoGameIdAsync(formAddVideoGameParams.Id);

            var entityGameTypes = await _gameTypeService.GetGameTypeByGameTypeName(nameGameTypesById.Split(","));

            //удаляем старые связи
            foreach (var item in entityGameTypes)
            {
                entity.GameTypes.Remove(item);
            }

            await _gameTypeService.UpdateGameType();

            var entitiesGameType = await _gameTypeService.AddUnicalGameTypeAsync(formAddVideoGameParams.GameType.Split(","));

            if(entity != null)
            {
                entity.GameName = formAddVideoGameParams.GameName;
                entity.GamePicture = formAddVideoGameParams.GamePicture;
                entity.StudioDeveloper = formAddVideoGameParams.StudioDeveloper;
            }
            
            //добавляем новые связи
            foreach (var item in entitiesGameType)
            {
                entity.GameTypes.Add(item);
            }


            await _videoGameService.UpdateVideoGame();

            //удаляем entity gameTypes без связей
            foreach (var item in nameGameTypesById.Split(","))
            {
                var query = _videoGameRepository.AsQueryable()
                .Where(q => q.GameTypes
                .Any(w => w.Name == item)).FirstOrDefault();

                if (query == null)
                {
                    var GameTypeId = await _gameTypeService.GetGameTypeIdByName(item);
                    await _gameTypeService.RemoveGameTypeAsync(GameTypeId);
                }
            }

            return true;
        }

        // <summary>
        /// Метод для удаления всех игр и жанров
        /// </summary>
        public async Task<bool> RemoveAllVideoGamesAsync()
        {
            try {

                await _videoGameService.RemoveAllVideoGamesAsync();
                await _gameTypeService.RemoveAllGameTypesAsync();
            }
            catch 
            {
                throw new ArgumentNullException("Ошибка удаления всех игры");
            }

            return true;
        }
    }
}
