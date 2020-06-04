using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entities;
using SharedKernel.Abstractions.BLL.DTOs.Rooms;
using SharedKernel.Extensions;
using SharedKernel.Helpers;

namespace BLL.IoC.Profiles
{
	class RoomMappingProfile : Profile
	{
		public RoomMappingProfile()
		{
			CreateMap<IAddRoomDTO, Room>()
				   .ForMember(r => r.PasswordHash, opt => opt.MapFrom(dto => HashPasswordHelper.GetPasswordHash(dto.Password)));
		}
	}
}
