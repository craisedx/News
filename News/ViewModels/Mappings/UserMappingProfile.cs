using AutoMapper;

namespace News.ViewModels.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<NewsViewModel, Models.Item>()
                .ForMember(i => i.Id, opt => opt.MapFrom(nvm => nvm.Id))
                .ForMember(i => i.Header, opt => opt.MapFrom(nvm => nvm.Header))
                .ForMember(i => i.Subtitle, opt => opt.MapFrom(nvm => nvm.Subtitle))
                .ForMember(i => i.Text, opt => opt.MapFrom(nvm => nvm.Text))
                .ForMember(i => i.Image, opt => opt.MapFrom(nvm => nvm.Image))
                .ReverseMap();
        }
    }
}
