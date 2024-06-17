using Domain.Enums;

namespace Infrastructure.Repositories;

public class PondRepository : Repository<Pond>, IPondRepository
{
    public PondRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override async Task<Pond?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await base.GetAsync(id, cancellationToken) ?? throw new DataNotFoundException();
    }

    public async Task<object> GetDataAsync(Guid pondId, CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);
        
        object dataFromSmartDevice = new
        {
            TemperatureInCelcius = 20.0,
            FoodAmountInKilos = 0.125,
            PhLevel = 7.2,
            DissolvedAmmoniaMgL = 0.3
        };
        
        var temperatureInCelsius = 
            (double)dataFromSmartDevice.GetType().GetProperty("TemperatureInCelcius")!.GetValue(dataFromSmartDevice)!;
        var temperatureInFahrenheit = ConvertCelsiusToFahrenheit(temperatureInCelsius);

        var foodAmountInKilos =
            (double)dataFromSmartDevice.GetType().GetProperty("FoodAmountInKilos")!.GetValue(dataFromSmartDevice)!;
        var foodAmountInPounds = ConvertKilosToPounds(foodAmountInKilos);
        
        double dissolvedAmmoniaMgL = 
            (double)dataFromSmartDevice.GetType().GetProperty("DissolvedAmmoniaMgL")!.GetValue(dataFromSmartDevice)!;
        double dissolvedAmmoniaLbsOz = ConvertMgLtoLbsOz(dissolvedAmmoniaMgL);
        
        dataFromSmartDevice = new
        {
            TemperatureInCelcius = 20.0,
            FoodAmountInKilos = 0.125,
            PhLevel = 7.2,
            DissolvedAmmoniaMgL = 0.3,
            TemperatureInFahrenheit = temperatureInFahrenheit,
            FoodAmountInPounds = foodAmountInPounds,
            DissolvedAmmoniaLbsOz = dissolvedAmmoniaLbsOz
        };

        return dataFromSmartDevice;
    }

    public Task<List<Pond>> GetByEmailAsync(string requestEmail, CancellationToken cancellationToken)
    {
        return Context.Set<Pond>()
            .Include(p => p.Personnel)
            .Where(p => p.Personnel.Any(u => u.Email == requestEmail))
            .Include(p => p.FeedingSchedule)
            .ToListAsync(cancellationToken);
    }

    private double ConvertCelsiusToFahrenheit(double temperatureInCelsius)
    {
        return (temperatureInCelsius * 9 / 5) + 32;
    }

    private double ConvertKilosToPounds(double valueInKilos)
    {
        return valueInKilos * 2.20462;
    }

    private double ConvertMgLtoLbsOz(double valueInMgL)
    {
        return valueInMgL * 2.20462e-6 * 35.27396;
    }
}