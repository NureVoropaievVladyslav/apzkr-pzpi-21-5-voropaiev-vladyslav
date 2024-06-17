namespace Domain.Entities;

public class FeedingSchedule
{
    public Guid Id { get; set; }
    
    public int FeedingFrequencyInHours { get; set; }
    
    public double FoodAmount { get; set; }
}