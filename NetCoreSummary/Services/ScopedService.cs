using Microsoft.Extensions.Logging;
using System;

namespace NetCoreSummary.Services
{
    public interface IScopedService
    {
        public void Do();
    }

    public class ScopedService : IScopedService
    {
        private readonly ILogger logger; // ILogger - framework provided service

        // type required to resolve concreate named logger
        public ScopedService(ILogger<ScopedService> logger)
        {
            this.logger = logger;
        }

        public void Do()
        {
            Console.WriteLine($"{this.GetType().Name} execute method Do");
            logger.LogInformation("Log message");
        }
    }
}
