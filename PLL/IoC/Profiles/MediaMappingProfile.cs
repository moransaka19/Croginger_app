using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SharedKernel.Abstractions.BLL.DTOs.Media;
using SharedKernel.Abstractions.DAL.Models;

namespace PLL.IoC.Profiles
{
	class MediaMappingProfile : Profile
	{
		public MediaMappingProfile()
		{
			CreateMap<IMediaDTO, IMedia>()
				.ForMember(m => m.PlayList, opt => opt.Ignore());
		}
	}
}
