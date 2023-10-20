using Microsoft.Extensions.DependencyInjection;
using TRON_TEST.Services;

internal class Program
{
    static string walletAddress = "TU1XvmdHLtqPCmsYNP1BkvEsZZFw12okeG";
    private static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<ILogger, ConsoleLogger>() // Register services
            .AddTransient<TronAPI>()
            .BuildServiceProvider(); // Build the service provider

        // Resolve services
        var logger = serviceProvider.GetRequiredService<ILogger>();
        var tronAPI = serviceProvider.GetRequiredService<TronAPI>();

        // Use the resolved services



        //await tronAPI.GetAccountInfo("TU1XvmdHLtqPCmsYNP1BkvEsZZFw12okeG");
        //await tronAPI.GetTransactionInfo("TU1XvmdHLtqPCmsYNP1BkvEsZZFw12okeG");
        //await tronAPI.GetContractTransactionInfo("TU1XvmdHLtqPCmsYNP1BkvEsZZFw12okeG");
        //await tronAPI.BroadcastTransaction();
        //await tronAPI.BroadcastHex();
        //await tronAPI.CreateTransaction();
        await tronAPI.GetWallet(walletAddress);







        // Dispose of the service provider when done
        serviceProvider.Dispose();
    }

    public interface ILogger
    {
        void Log(string message);
    }

    // ConsoleLogger.cs
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}