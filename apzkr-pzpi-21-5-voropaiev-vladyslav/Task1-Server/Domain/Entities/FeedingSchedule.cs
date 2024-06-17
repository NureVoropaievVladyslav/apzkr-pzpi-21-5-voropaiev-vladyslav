using System.Text.Json.Serialization;

namespace Domain.Entities;

public class FeedingSchedule : BaseEntity
{
    [JsonIgnore]
    public Guid PondId { get; set; }
    
    [JsonIgnore]
    public Pond? Pond { get; set; }
    
    public int FeedingFrequencyInHours { get; set; }
    
    public double FoodAmount { get; set; }
}