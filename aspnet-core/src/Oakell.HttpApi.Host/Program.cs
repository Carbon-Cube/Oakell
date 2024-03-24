using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace Oakell;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

        try
        {
            Log.Information("Starting Oakell.HttpApi.Host.");

            // Determine the environment
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            // Load and log the appsettings.json content
            var appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var appSettingsContent = await File.ReadAllTextAsync(appSettingsPath);
            Log.Information($"Contents of appsettings.json:\n{appSettingsContent}");

            // Optionally, load and log environment-specific appsettings content if exists
            var envAppSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.{environmentName}.json");
            if (File.Exists(envAppSettingsPath))
            {
                var envAppSettingsContent = await File.ReadAllTextAsync(envAppSettingsPath);
                Log.Information($"Contents of appsettings.{environmentName}.json:\n{envAppSettingsContent}");
            }

            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            await builder.AddApplicationAsync<OakellHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
