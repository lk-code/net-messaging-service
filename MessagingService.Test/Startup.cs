using Microsoft.Extensions.DependencyInjection;
using System;

namespace MessagingService.Test
{
    public class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider Init()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IMessagingService, MessagingService>()
                .BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }
    }
}