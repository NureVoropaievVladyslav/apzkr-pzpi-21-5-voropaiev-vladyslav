namespace Domain.Entities;

public class Pond
{
    public Guid Id { get; set; }
    
    public string FishSpecies { get; set; } 
    
    public int FishPopulation { get; set; }
    
    public FeedingSchedule FeedingSchedule { get; set; }
}