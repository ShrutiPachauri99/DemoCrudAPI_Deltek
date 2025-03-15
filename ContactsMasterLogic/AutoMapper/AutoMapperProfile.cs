using AutoMapper;
using ContactsMasterData.Domain;
using ContactsMasterInfra.ViewModel;

namespace ContactsMasterLogic.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contact, ContactViewModel>().ReverseMap();
        }
    }
}
