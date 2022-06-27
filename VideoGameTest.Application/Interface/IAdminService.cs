using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameTest.Application.Models;
using VideoGameTest.Application.Params;

namespace VideoGameTest.Application.Interface
{
    public interface IAdminService
    {
        Task<bool> AddVideoGameAsync(FormAddVideoGameParams formAddVideoGameParams);

        Task<bool> EditVideoGameAsync(FormAddVideoGameParams formAddVideoGameParams);

        Task<bool> RemoveVideoGameByIdAsync(int videoGameId);

        Task<VideoGameModel> GetVideoGameByIdAsync(int videoGameId);

        Task<bool> RemoveAllVideoGamesAsync();
    }
}
