namespace Application.Features.Ponds.Queries.GetPondDataQuery;

public class PondDataResponse
{
    public double FoodAmountInKilos { get; set; }
    
    public double FoodAmountInPounds { get; set; }
    
    public double TemperatureInCelcius { get; set; }
    
    public double TemperatureInFahrenheit { get; set; }
    
    public double PhLevel { get; set; }
    
    public double DissolvedOxygenLevel { get; set; }
}