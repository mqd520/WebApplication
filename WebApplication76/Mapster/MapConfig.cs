using Mapster;

using WebApplication76.Dto;
using WebApplication76.Entity;

namespace WebApplication76.Mapster
{
    public static class MapConfig
    {
        public static void Register()
        {
            TypeAdapterConfig<UserInfo2Entity, UserInfo2Dto>
                .NewConfig()
                .Map(dest => dest.UserId, src => src.Id)
                .Map(dest => dest.UserName, src => src.Name);

            TypeAdapterConfig<UserInfo3Entity, UserInfo3Dto>
                .NewConfig()
                .Map(dest => dest.UserId, src => src.Id)
                .Map(dest => dest.UserName, src => src.Name.Equals("Jane Doe") ? src.Name : "Default Name");
        }
    }
}
