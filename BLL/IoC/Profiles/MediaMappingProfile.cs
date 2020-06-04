using AutoMapper;
using DAL.Entities;
using SharedKernel.Abstractions.BLL.DTOs.Media;

namespace PLL.IoC.Profiles
{
	class MediaMappingProfile : Profile
	{
		public MediaMappingProfile()
		{
			CreateMap<IMediaDTO, Media>()
				.ForMember(m => m.PlayListId, opt => opt.Ignore());
		}
	}
}
