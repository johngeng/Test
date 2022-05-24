using System;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        // GET api/day/monday
        [HttpGet("{day}")]
        public ActionResult<string> GetNext(string day)
        {
            if (Enum.TryParse(typeof(DayOfWeek), day, true, out object dayInput))
            {
                var baseDay = DateTime.Today.Date.AddDays(- (int) DateTime.Today.DayOfWeek);
                var nextDay = baseDay.AddDays((int)dayInput + 1);

                //assuming return back furture day
                return $"{nextDay.AddDays(nextDay <= DateTime.Today.Date ? 7 : 0).ToString("dd MMM yyyy")}";
            }

            return "Incorrect day supplied.";
        }
    }
}
