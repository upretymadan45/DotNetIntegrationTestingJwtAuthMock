using GST.Fake.Authentication.JwtBearer;

namespace Integration.Tests;

public class WeatherForecastTests : BaseTestFixture
{

    [Test]
    public async Task GetWeatherData_Should_Succeed()
    {
        dynamic data = new System.Dynamic.ExpandoObject();
        data.name = "Matt";
        data.role = "4";
        HttpClient.SetFakeBearerToken("matt@gmail.com", new[] { "4" }, (object)data);

        HttpClient.BaseAddress = new Uri("https://localhost:7038/");
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "WeatherForecast");

        var response = await HttpClient.SendAsync(httpRequestMessage);

        response.EnsureSuccessStatusCode();
    }
}
