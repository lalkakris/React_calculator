using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using react_calculator.Models;
using react_calculator.Services;

namespace react_calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public IEnumerable<Expression> GetDataFromDb()
        {
            using (var context = new HistoryContext())
            {
                List<Expression> calcList = new List<Expression>();
                foreach (var entry in context.Expressions)
                {
                    Expression getEntry = new Expression
                    {
                        ID = entry.ID,
                        Example = entry.Example,
                        Solution = entry.Solution
                    };
                    calcList.Add(getEntry);
                }
                return calcList;
            }

        }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Expression> Get()
        {

            var calc = new GoCalculate();
            calc.Start();
            return GetDataFromDb();
        }
    }
}
