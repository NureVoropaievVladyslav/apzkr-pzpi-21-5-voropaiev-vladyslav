using Domain.ValueObjects;

namespace Infrastructure.Repositories;

public class FeedingScheduleRepository : Repository<FeedingSchedule>, IFeedingScheduleRepository
{
    public FeedingScheduleRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override Task CreateAsync(FeedingSchedule entity, CancellationToken cancellationToken)
    {
        var pond = entity.Pond;
        if (entity.FoodAmount == 0.0f)
        {
            entity.FoodAmount = FishRequirements.GetFoodAmountPerDay(pond.FishSpecies) * pond.FishPopulation;
        }

        if (entity.FeedingFrequencyInHours == 0)
        {
            entity.FeedingFrequencyInHours = (int)FishRequirements.GetFeedingFrequency(pond.FishSpecies).TotalHours;
        }
        
        return base.CreateAsync(entity, cancellationToken);
    }

    public override async Task<FeedingSchedule?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await base.GetAsync(id, cancellationToken) ?? throw new DataNotFoundException();
    }
}