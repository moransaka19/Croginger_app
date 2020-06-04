using AutoMapper;
using DAL.Entities;
using SharedKernel.Abstractions.BLL.DTOs.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IoC.Profiles
{
	class MessageMappingProfile : Profile
	{
		public MessageMappingProfile()
		{
			CreateMap<IMessageDTO, Message>()
				.ForMember(m => m.Room, opt => opt.Ignore())
				.ForMember(m => m.User, opt => opt.Ignore())
				// TODO: Get hash messahe
				.ForMember(m => m.HashMessage,
					opt => opt.MapFrom(dto => dto.Message));
		}
	}
}
