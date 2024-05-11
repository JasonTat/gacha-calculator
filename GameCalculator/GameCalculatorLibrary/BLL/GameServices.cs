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

    }
}
