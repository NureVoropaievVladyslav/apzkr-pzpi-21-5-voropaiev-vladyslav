using System.Text.Json.Serialization;
using Domain.Enums;

namespace Domain.Entities;

public class Pond : BaseEntity
{
    public FishSpecies FishSpecies { get; set; }
    
    public int FishPopulation { get; set; }
    
    public List<User> Personnel { get; private set; } = [];

    public Guid? FeedingScheduleId { get; set; }
    
    public FeedingSchedule? FeedingSchedule { get; set; }
}