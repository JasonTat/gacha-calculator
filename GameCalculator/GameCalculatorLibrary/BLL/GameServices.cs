using GameCalculatorLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCalculatorLibrary.BLL
{
    public class GameServices
    {
        private readonly GachaGameCalculatorContext _gameCalculatorContext;

        internal GameServices(GachaGameCalculatorContext gameCalculatorContext)
        {
            _gameCalculatorContext = gameCalculatorContext;
        }

        #region query
        public Game FetchGameFromId(int id)
        {
            Game game = _gameCalculatorContext.Games
                            .Where(x => x.ID == id)
                            .Select(x => new Game
                            {
                                ID = x.ID,
                                GameName = x.GameName,
                                MinutesPerEnergy = x.MinutesPerEnergy,
                                MaximumEnergyCap = x.MaximumEnergyCap
                            })
                            .FirstOrDefault();
            return game;
        }

        public int GameEnergyCalculator(int currentAmount, Game game)
        {
            int totalTimeToReplenish;
            int difference = (int)game.MaximumEnergyCap - currentAmount;
            totalTimeToReplenish = difference * (int)game.MinutesPerEnergy;
            return totalTimeToReplenish;
        }

        public List<Game> PopulateGameList()
        {
            List<Game> list = new List<Game>();

            list = _gameCalculatorContext.Games
                        .Select(x => new Game
                        {
                            ID = x.ID,
                            GameName = x.GameName,
                            MinutesPerEnergy = x.MinutesPerEnergy == null ? 0 : (int)x.MinutesPerEnergy,
                            MaximumEnergyCap = x.MaximumEnergyCap == null ? 0 : (int)x.MaximumEnergyCap
                        })
                        .ToList();
            return list;
        }

        #endregion

    }
}
