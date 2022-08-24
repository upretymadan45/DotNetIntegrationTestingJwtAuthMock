using GST.Fake.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.Tests;

public class BaseTestFixture
{
    protected HttpClient HttpClient;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddAuthentication(options =>
                {
                    options.DefaultScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                }).AddFakeJwtBearer();
            });
        });

        HttpClient = application.CreateDefaultClient();
    }
}
