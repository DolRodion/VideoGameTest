using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameTest.Application.Models;
using VideoGameTest.DataAccess.Entities;

namespace VideoGameTest.Application.Interface
{
    public interface IVideoGameService
    {
        Task<VideoGameModel[]> GetAllVideoGameAsync();

        Task AddVideoGameAsync(VideoGame videoGame);

        Task<bool> RemoveVideoGameByIdAsync(int videoGameId);

        Task<VideoGameModel[]> GetVideoGameByGameTypeAsync(string gameTypeName);

        Task RemoveAllVideoGamesAsync();

        Task UpdateVideoGame();
    }
}
