namespace Application.Features.Ponds.Queries.GetByEmail;

public record GetPondsByEmailQuery(string Email = "john@gmail.com") : IRequest<List<PondResponse>>;

public class PondResponse
{
    public Guid Id { get; set; }
    
    public string FishSpecies { get; set; }
    
    public int FishPopulation { get; set; }
    
    public FeedingSchedule FeedingSchedule { get; set; }
    
    private class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pond, PondResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FishSpecies, opt => opt.MapFrom(src => src.FishSpecies.ToString()))
                .ForMember(dest => dest.FishPopulation, opt => opt.MapFrom(src => src.FishPopulation))
                .ForMember(dest => dest.FeedingSchedule, opt => opt.MapFrom(src => src.FeedingSchedule));;
        }
    }
}