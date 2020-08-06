using gameOfLife.engine;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameOfLife.Controllers
{
    [ApiController]
    [Route("[gameoflife]")]
    public class GameInstanceController
    {
       
        private readonly GameOfLife _gameInstance;

        public GameInstanceController(GameOfLife gameInstance)
        {
            _gameInstance = gameInstance;
        }

        [HttpGet]
        public string getGameInstance()
        {
            return _gameInstance.gameStateToJSON();
        }


    }
}
