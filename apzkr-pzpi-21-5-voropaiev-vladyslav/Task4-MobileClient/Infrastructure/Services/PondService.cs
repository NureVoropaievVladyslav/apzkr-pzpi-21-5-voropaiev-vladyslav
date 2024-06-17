using Application.Abstractions.Factories;
using Application.Abstractions.Services;
using Application.Features.Ponds.Commands;
using Domain.Entities;
using Infrastructure.Configurations.Auth;

namespace Infrastructure.Services
{
    public class PondService : ServiceBase, IPondService
    {
        public PondService(IHttpClientFactory httpClientFactory, AuthConfiguration authConfiguration)
            : base(httpClientFactory, authConfiguration)
        {
        }

        public async Task<List<Pond>> GetPondsAsync(CancellationToken cancellationToken)
        {
            return await SendRequestAsync<List<Pond>>(HttpMethod.Get, "ponds/email", cancellationToken);
        }

        public async Task UpdateScheduleAsync(Pond? currentEntity)
        {
            var request = new UpdateFeedingScheduleCommand(
                currentEntity!.FeedingSchedule.Id, 
                currentEntity!.Id, 
                currentEntity!.FeedingSchedule.FeedingFrequencyInHours, 
                currentEntity!.FeedingSchedule.FoodAmount);
            await SendRequestAsync(HttpMethod.Put, "feedingSchedules", request, CancellationToken.None);
        }
    }
}