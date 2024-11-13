using AutoMapper;
using Jornada.API.Data.Dtos;
using Jornada.API.Models;

namespace Jornada.API.Profiles;

public class FeedbackProfile : Profile
{
    public FeedbackProfile()
    {
        CreateMap<CreateFeedbackDto, Feedback>();
        CreateMap<UpdateFeedbackDto, Feedback>();
        CreateMap<Feedback, UpdateFeedbackDto>();
    }
}
