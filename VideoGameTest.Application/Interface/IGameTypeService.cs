using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameTest.DataAccess.Entities;

namespace VideoGameTest.Application.Interface
{
    public interface IGameTypeService
    {
        Task<string> GetGameTypeByVideoGameIdAsync(int videoGameId);

        Task<GameType[]> AddUnicalGameTypeAsync(string[] gameTypeNames);

        Task<string[]> GetAllAsync();

        Task<int> GetGameTypeIdByName(string name);

        Task RemoveGameTypeAsync(int gameTypeId);

        Task RemoveAllGameTypesAsync();

        Task<GameType[]> GetGameTypeByGameTypeName(string[] gameTypeNames);

        Task UpdateGameType();
    }
}
