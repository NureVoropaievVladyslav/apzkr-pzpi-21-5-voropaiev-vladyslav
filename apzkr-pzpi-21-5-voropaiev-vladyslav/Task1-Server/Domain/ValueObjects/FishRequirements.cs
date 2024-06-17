using Domain.Enums;

namespace Domain.ValueObjects;

public static class FishRequirements
{
    public static float GetFoodAmountPerDay(FishSpecies species)
    {
        return species switch
        {
            FishSpecies.Tilapia => 1.5f,
            FishSpecies.Catfish => 2.0f,
            FishSpecies.Carp => 1.8f,
            FishSpecies.Trout => 1.2f,
            FishSpecies.Salmon => 1.5f,
            FishSpecies.Bass => 2.5f,
            FishSpecies.Bluegill => 0.8f,
            FishSpecies.Crappie => 0.7f,
            FishSpecies.Sturgeon => 3.0f,
            FishSpecies.Pike => 2.2f,
            _ => 0.0f
        };
    }
    
    public static TimeSpan GetFeedingFrequency(FishSpecies species)
    {
        return species switch
        {
            FishSpecies.Tilapia => TimeSpan.FromHours(12),
            FishSpecies.Catfish => TimeSpan.FromHours(8),
            FishSpecies.Carp => TimeSpan.FromHours(10),
            FishSpecies.Trout => TimeSpan.FromHours(6),
            FishSpecies.Salmon => TimeSpan.FromHours(8),
            FishSpecies.Bass => TimeSpan.FromHours(12),
            FishSpecies.Bluegill => TimeSpan.FromHours(24),
            FishSpecies.Crappie => TimeSpan.FromHours(24),
            FishSpecies.Sturgeon => TimeSpan.FromHours(8),
            FishSpecies.Pike => TimeSpan.FromHours(12),
            _ => TimeSpan.FromHours(0)
        };
    }
}