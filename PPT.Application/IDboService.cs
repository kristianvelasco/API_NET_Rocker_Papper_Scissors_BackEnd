using PPT.Application.Core;
using PPT.Domain.entities;
using PPT.Infrastructure.Data;
using System;
using System.Collections.Generic;

namespace PPT.Application
{
    public interface IDboService : IService
    {
        /// <summary>
        /// Get all Players in database.
        /// </summary>
        /// <returns>tblColors</returns>
        List<tblPlayer> GetAllPlayers();

        /// <summary>
        /// Get Player By name in Database
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        List<tblPlayer> GetPlayersByPlayerName(string Name);

        /// <summary>
        /// Get all Games in database.
        /// </summary>
        /// <returns>tblColors</returns>
        List<tblGame> GetAllGames();

        /// <summary>
        /// Get all Results Games in database.
        /// </summary>
        /// <returns>tblColors</returns>
        List<tblResultGame> GetAllResultGames();

        /// <summary>
        /// Get Result Games By PlayerId in database.
        /// </summary>
        /// <returns>tblColors</returns>
        List<tblResultGame> GetResultGamesByPlayerId(Guid Id);

        /// <summary>
        /// Save Item Player in Database
        /// </summary>
        /// <param name="NamePlayer"></param>
        /// <returns></returns>
        Guid SavePlayer(string NamePlayer);

        /// <summary>
        /// Save Game in Database
        /// </summary>
        /// <param name="OnePlayer"></param>
        /// <param name="SecondPayer"></param>
        /// <returns></returns>
        Guid SaveGame(Guid OnePlayer, Guid SecondPayer);

        /// <summary>
        /// Save Game Result In Database
        /// </summary>
        /// <param name="GameId"></param>
        /// <param name="WinPlayer"></param>
        /// <returns></returns>
        bool SaveResultGame(Guid GameId, Guid WinPlayer);


    }
}
