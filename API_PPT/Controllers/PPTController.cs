using PPT.Application;
using PPT.Domain.entities;
using PPT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace API_PPT.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PPTController : ApiController
    {
        protected IDboService dboService;
        private const string Maquina = "Maquina";
        public PPTController()
        {
            dboService = new DboService("dbo", "PPT");
            dboService.Initialize();
        }

        //#region "GETS"
        //public IQueryable<tblGame> GetGames()
        //{
        //    return db.tblGames;
        //}

        //// GET: api/Inventories/2018-01-01
        //[HttpGet()]
        //[Route("Api/PPT/GetResultGames")]
        //[ResponseType(typeof(List<tblResultGame>))]
        //public IQueryable<tblResultGame> GetResultGames()
        //{
        //    return db.tblResultGames;
        //}

        //[HttpGet()]
        //[Route("Api/PPT/GetPlayers")]
        //[ResponseType(typeof(List<tblPlayer>))]
        //public IQueryable<tblPlayer> GetPlayers()
        //{
        //    return db.tblPlayers;
        //}
        //#endregion

        //#region "POST"
        //// POST

        //[HttpPost()]
        //[Route("Api/PPT/SavePlayer/{Name}")]
        //[ResponseType(typeof(List<tblPlayer>))]
        //public IHttpActionResult SavePlayer(string Name)
        //{
        //    List<tblPlayer> _player = null;

        //    try
        //    {
        //        _player = db.tblPlayers.Where(w => w.NamePlayer == Name).ToList();

        //        if (_player.Count == 0)
        //        {
        //            var player = new tblPlayer()
        //            {
        //                NamePlayer = Name
        //            };

        //            db.tblPlayers.Add(player);
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    return Ok(_player);
        //}

        //// PLAYER VS MACHINE
        //[HttpPost]
        //[Route("Api/PPT/PlayGameMachine/{Jugador1}/{Arma}")]
        //[ResponseType(typeof(List<tblResultGame>))]
        //public IHttpActionResult PlayGameMachine(int Jugador1, int Arma)
        //{
        //    int ArmaMaquina = 0, JugadorMaquina = 0, JugadorGanador = -1;
        //    Random random = new Random();
        //    ArmaMaquina = random.Next(1, 3);
        //    JugadorMaquina = db.tblPlayers.Where(ls => ls.NamePlayer == Maquina).FirstOrDefault().Id;

        //    var _game = new tblGame()
        //    {
        //        FirstPlayerId = Jugador1,
        //        SecondPlayerId = JugadorMaquina
        //    };

        //    db.tblGames.Add(_game);
        //    db.SaveChanges();

        //    if (Arma == ArmaMaquina)
        //    {
        //        JugadorGanador = -1;
        //    }
        //    else if ((Arma - ArmaMaquina + 3) % 3 == 1)
        //    {
        //        JugadorGanador = Jugador1;
        //    }
        //    else
        //    {
        //        JugadorGanador = JugadorMaquina;
        //    }

        //    List<tblGame> games = db.tblGames.ToList();
        //    var _result = new tblResultGame()
        //    {
        //        GameId = games.Max(ls => ls.Id),
        //        WinPlayerId = JugadorGanador
        //    };

        //    db.tblResultGames.Add(_result);
        //    db.SaveChanges();

        //    return Ok(db.tblResultGames);
        //}

        //// MULTIPLAYER
        //[HttpPost]
        //[Route("Api/PPT/PlayGameMultiPlayer/{Jugador1}/{Arma1}/{Jugador2}/{Arma2}")]
        //[ResponseType(typeof(List<tblResultGame>))]
        //public IHttpActionResult PlayGameMultiPlayer(int Jugador1, int Arma1, int Jugador2, int Arma2)
        //{
        //    int winPlayer = -1;
        //    var _game = new tblGame()
        //    {
        //        FirstPlayerId = Jugador1,
        //        SecondPlayerId = Jugador2
        //    };

        //    db.tblGames.Add(_game);
        //    db.SaveChanges();

        //    if (Arma1 == Arma2)
        //    {
        //        winPlayer = -1;
        //    }
        //    else if ((Arma1 - Arma2 + 3) % 3 == 1)
        //    {
        //        winPlayer = Jugador1;
        //    }
        //    else
        //    {
        //        winPlayer = Jugador2;
        //    }

        //    List<tblGame> games = db.tblGames.ToList();
        //    var _result = new tblResultGame()
        //    {
        //        GameId = games.Max(ls => ls.Id),
        //        WinPlayerId = winPlayer
        //    };

        //    db.tblResultGames.Add(_result);
        //    db.SaveChanges();

        //    return Ok(db.tblResultGames);
        //}
        //#endregion


        //OTHER

        [Route("api/PPT/GetAllGames")]
        [HttpGet]
        public IHttpActionResult GetAllGames()
        {
            try
            {
                List<tblGame> result = dboService.GetAllGames();

                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Error get information." + ex.Message);
            }
        }

        [Route("api/PPT/GetAllPlayers")]
        [HttpGet]
        public IHttpActionResult GetAllPlayers()
        {
            try
            {
                List<tblPlayer> result = dboService.GetAllPlayers();

                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Error get information." + ex.Message);
            }
        }

        [Route("api/PPT/GetAllResultGames")]
        [HttpGet]
        public IHttpActionResult GetAllResultGames()
        {
            try
            {
                List<tblResultGame> result = dboService.GetAllResultGames();

                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Error get information." + ex.Message);
            }
        }

        [Route("api/PPT/SavePlayer/{NamePlayer}")]
        [HttpPost]
        public IHttpActionResult SavePlayer(string NamePlayer)
        {
            try
            {
                var result = dboService.SavePlayer(NamePlayer);

                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
                throw;
            }
        }


        // PLAYER VS MACHINE
        [HttpPost]
        [Route("Api/PPT/PlayGameMachine/{NameOnePlayer}/{Arma}")]
        [ResponseType(typeof(List<tblResult>))]
        public IHttpActionResult PlayGameMachine(string NameOnePlayer, int Arma)
        {
            int ArmaMaquina = 0, Armawinner;
            Guid MachinePlayer, WinPlayer, GameId,OnePlayer;
            List<tblPlayer> _players = dboService.GetPlayersByPlayerName(Maquina);
            Random random = new Random();
            tblResult objResultGame = new tblResult();

            ArmaMaquina = random.Next(1, 3);
            if (_players.Count() > 0)
            {
                MachinePlayer = _players[0].Id;

                //Save the game
                OnePlayer = dboService.SavePlayer(NameOnePlayer);
                GameId = dboService.SaveGame(OnePlayer, MachinePlayer);
                if (Arma == ArmaMaquina)
                {
                    WinPlayer = Guid.Empty;
                    Armawinner = -1;
                }
                else if ((Arma - ArmaMaquina + 3) % 3 == 1)
                {
                    WinPlayer = OnePlayer;
                    Armawinner = Arma;
                }
                else
                {
                    WinPlayer = MachinePlayer;
                    Armawinner = ArmaMaquina;
                }

                //Save the result
                dboService.SaveResultGame(GameId, WinPlayer);
                string nameWinner = "";
                if (WinPlayer != Guid.Empty)
                {
                    nameWinner = dboService.GetAllPlayers().Where(ls => ls.Id == WinPlayer).ToList()[0].Name;
                }

                objResultGame.NameWinPlayer = nameWinner;
                objResultGame.Weapon = Armawinner;

                return Content(HttpStatusCode.OK, objResultGame);
            }
            else
            {
                return BadRequest();
            }
        }

        // MULTIPLAYER
        [HttpPost]
        [Route("Api/PPT/PlayGameMultiPlayer/{NameOnePlayer}/{Arma1}/{NameSecondPlayer}/{Arma2}")]
        [ResponseType(typeof(List<tblResult>))]
        public IHttpActionResult PlayGameMultiPlayer(string NameOnePlayer, int Arma1, string NameSecondPlayer, int Arma2)
        {
            Guid WinPlayer = Guid.Empty, GameId = Guid.Empty,OnePlayer,SecondPlayer;
            tblResult objResultGame = new tblResult();
            int Armawinner;
            //Save the game
            OnePlayer = dboService.SavePlayer(NameOnePlayer);
            SecondPlayer = dboService.SavePlayer(NameSecondPlayer);
            GameId = dboService.SaveGame(OnePlayer, SecondPlayer);

            if (Arma1 == Arma2)
            {
                WinPlayer = Guid.Empty;
                Armawinner = -1;
            }
            else if ((Arma1 - Arma2 + 3) % 3 == 1)
            {
                WinPlayer = OnePlayer;
                Armawinner = Arma1;
            }
            else
            {
                WinPlayer = SecondPlayer;
                Armawinner = Arma2;
            }

            //Save the result
            dboService.SaveResultGame(GameId, WinPlayer);
            string nameWinner = "";
            if (WinPlayer != Guid.Empty)
            {
                nameWinner = dboService.GetAllPlayers().Where(ls => ls.Id == WinPlayer).ToList()[0].Name;
            }

            objResultGame.NameWinPlayer = nameWinner;
            objResultGame.Weapon = Armawinner;


            return Content(HttpStatusCode.OK, objResultGame);
        }
    }
}
