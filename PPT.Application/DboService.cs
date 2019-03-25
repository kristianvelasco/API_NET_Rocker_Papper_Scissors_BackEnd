using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPT.Application.Core;
using PPT.Domain.entities;
using PPT.Infrastructure.Data;

namespace PPT.Application
{
    public class DboService : Service, IDboService
    {
        #region Repositories
        protected DboRepository<tblGame> GamesRepository;
        protected DboRepository<tblPlayer> PlayersRepository;
        protected DboRepository<tblResultGame> ResultGamesRepository;

        #endregion

        public DboService()
        {
        }

        public DboService(string schema, string connectionStringName)
        {
            this.ConnectionStringName = connectionStringName;
            this.Schema = schema;
        }

        public new void Initialize()
        {
            base.Initialize();
            UnitOfWork = new UoW(ConnectionStringName, Schema);
            GamesRepository = new DboRepository<tblGame>("dbo", UnitOfWork);
            PlayersRepository = new DboRepository<tblPlayer>("dbo", UnitOfWork);
            ResultGamesRepository = new DboRepository<tblResultGame>("dbo", UnitOfWork);

        }

        public List<tblGame> GetAllGames()
        {
            try
            {
                return GamesRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<tblPlayer> GetAllPlayers()
        {
            try
            {
                return PlayersRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<tblResultGame> GetAllResultGames()
        {
            try
            {
                return ResultGamesRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<tblResultGame> GetResultGamesByPlayerId(Guid Id)
        {
            try
            {
                return ResultGamesRepository.GetFilteredElements(f => f.Id == Id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tblPlayer> GetPlayersByPlayerName(string Name)
        {
            try
            {
                return PlayersRepository.GetFilteredElements(f => f.Name == Name).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Guid SavePlayer(string NamePlayer)
        {
            Guid PlayerId = Guid.NewGuid();
            try
            {
                List<tblPlayer> ExistPlayer = PlayersRepository.GetAll().Where(ls => ls.Name == NamePlayer).ToList();
                if (ExistPlayer.Count == 0)
                {
                    tblPlayer objPlayer = new tblPlayer()
                    {
                        Id = PlayerId,
                        Name = NamePlayer
                    };

                    PlayersRepository.Save(objPlayer);
                }
                else {
                    return ExistPlayer[0].Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PlayerId;
        }
        public Guid SaveGame(Guid OnePlayer, Guid SecondPayer)
        {
            Guid GameId = Guid.NewGuid();
            try
            {
                tblGame objGame = new tblGame()
                {
                    Id = GameId,
                    FirstPlayer = OnePlayer,
                    SecondPlayer = SecondPayer,
                    DateCreated = DateTime.Now
                };

                GamesRepository.Save(objGame);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return GameId;
        }
        public bool SaveResultGame(Guid GameId, Guid WinPlayer)
        {
            try
            {
                tblResultGame objResult = new tblResultGame()
                {
                    Id = Guid.NewGuid(),
                    GameId = GameId,
                    WinPlayerId = WinPlayer
                };

                ResultGamesRepository.Save(objResult);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
