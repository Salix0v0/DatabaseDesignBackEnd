using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Instructor> Get()
    {
        string selectTest = "SELECT * FROM C##CAR.INSTRUCTOR";
        string msg = "";
        DataTable dt= OracleHelper.SelectSql(selectTest,ref msg);

        return Enumerable.Range(0, dt.Rows.Count).Select(index => new Instructor
        {
            ID = int.Parse(dt.Rows[index]["ID"].ToString()),
            Name = dt.Rows[index]["NAME"].ToString(),
            Dept_Name = dt.Rows[index]["DEPT_NAME"].ToString(),
            Salary = float.Parse(dt.Rows[index]["SALARY"].ToString())
        })
        .ToArray();
    }
}
