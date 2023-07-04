namespace webapi;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }

}

public class Instructor
{
    public int ID { get; set; }

    public string? Name { get; set; }

    public string? Dept_Name { get; set; }

    public float Salary { get; set; }
}
