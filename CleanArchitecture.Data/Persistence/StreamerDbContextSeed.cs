

using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger) 
        {
            if (!context.Streamers!.Any()) {
                context.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation($"Estamos insertando nuevos {context}", typeof(StreamerDbContext).Name);
            }
        }

        public static IEnumerable<Streamer> GetPreconfiguredStreamer() 
        {
            return new List<Streamer>
            {
                new Streamer { CreatedBy = "ese1", Nombre = "maxi", Url="https://test.com" },
                new Streamer { CreatedBy = "ese2", Nombre = "sali", Url="https://sali.com" }
            };
        }

    }
}
