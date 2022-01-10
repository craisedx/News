using AutoMapper;
using News.ViewModels.Mappings;

namespace News.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappers()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<UserMappingProfile>();
            });

            mapperConfig.AssertConfigurationIsValid();
        }
    }
}
