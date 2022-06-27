using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameTest.Application.Interface;
using VideoGameTest.DataAccess.Entities;
using VideoGameTest.DataAccess.Interfaces;

namespace VideoGameTest.Application.Services
{
    public class GameTypeService : IGameTypeService
    {
        private readonly IGenericRepository<GameType> _gameTypeRepository;

        public GameTypeService(IGenericRepository<GameType> gameTypeRepository)
        {
            _gameTypeRepository = gameTypeRepository;
        }

        /// <summary>
        /// Получаем все жанры
        /// </summary>
        public async Task<string[]> GetAllAsync()
        {
            return await _gameTypeRepository.AsQueryable()
                .Select(w => w.Name)
                .ToArrayAsync();
        }

        public async Task<string> GetGameTypeByVideoGameIdAsync(int videoGameId)
        {
            var gameType = await _gameTypeRepository.AsQueryable()
                .Where(q => q.VideoGames.Any(r => r.Id == videoGameId))
                .Select(w => w.Name)
                .ToArrayAsync();

            return string.Join(",", gameType.ToArray());
        }

        public async Task<GameType[]> AddUnicalGameTypeAsync(string[] gameTypeNames)
        {
            var entityGameTypes = await _gameTypeRepository.AsQueryable().ToListAsync();


            foreach (var type in gameTypeNames.Distinct())
            {
                if (!entityGameTypes.Any(q => q.Name == type.Trim().ToLower()))
                {

                    var newGameType = new GameType(type.Trim().ToLower());

                    await _gameTypeRepository.InsertAsync(newGameType);
                    entityGameTypes.Add(newGameType);
                }
            }
                   

            try
            {
                await _gameTypeRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Ошибка сохранения");
            }

            var gameTypes = new List<string>();

            foreach (var item in gameTypeNames)
            {
                gameTypes.Add(item.Trim().ToLower());
            }

            return entityGameTypes.Where(q => gameTypes
                    .Contains(q.Name))
                .ToArray();
        }

        public Task<int> GetGameTypeIdByName(string name)
        {
            return _gameTypeRepository.AsQueryable()
                .Where(q => q.Name == name)
                .Select(q => q.Id).FirstOrDefaultAsync();
        }

        public async Task RemoveGameTypeAsync(int gameTypeId)
        {
            await _gameTypeRepository.DeleteAsync(gameTypeId);
            await _gameTypeRepository.SaveChangesAsync();
        }

        public async Task RemoveAllGameTypesAsync()
        {
            var allVideogames = await _gameTypeRepository.AsQueryable().Select(q => q.Id).ToListAsync();

            foreach (var item in allVideogames)
            {
                await _gameTypeRepository.DeleteAsync(item);
            }

            await _gameTypeRepository.SaveChangesAsync();
        }

        public async Task<GameType[]> GetGameTypeByGameTypeName(string[] gameTypeNames)
        {
            var entityGameTypes = await _gameTypeRepository.AsQueryable().ToListAsync();
            return entityGameTypes.AsQueryable()
                   .Where(q => gameTypeNames
                   .Contains(q.Name))
                   .ToArray();
        }

        public async Task UpdateGameType()
        {
            await _gameTypeRepository.SaveChangesAsync();
        }

    }
       
}

 

