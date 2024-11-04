using AutoMapper;

using WebApplication25.DTO;
using WebApplication25.VO;

namespace WebApplication25.AutoMapper
{
    public class UserLoginProfile : Profile
    {
        public UserLoginProfile()
        {
            CreateMap<UserLoginRequestVO, UserLoginRequestDTO>();
            CreateMap<UserLoginResultDTO, UserLoginResultVO>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom<CustomConverter>());
        }
    }

    internal class CustomConverter : IValueResolver<UserLoginResultDTO, UserLoginResultVO, bool>
    {
        public bool Resolve(UserLoginResultDTO source
            , UserLoginResultVO destination
            , bool destMember
            , ResolutionContext context)
        {
            return source.Code == 0;
        }
    }
}
