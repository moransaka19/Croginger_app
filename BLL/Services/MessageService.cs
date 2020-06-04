using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SharedKernel.Abstractions.BLL.DTOs.Messages;
using SharedKernel.Abstractions.BLL.Services;
using SharedKernel.Abstractions.DAL.Repositories;

namespace BLL.Services
{
	public class MessageService : IMessageService
	{
		private readonly IRepository<Message> _messageRepository;
		private readonly UserManager<User> _userManager;
		private readonly HttpContext _httpContext;

		public MessageService(IRepository<Message> messageRepository, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
		{
			_messageRepository = messageRepository;
			_userManager = userManager;
			_httpContext = httpContextAccessor.HttpContext;
		}

		public async Task AddAsync(IMessageDTO dto)
		{
			var user = await _userManager.FindByNameAsync(_httpContext.User.Identity.Name);

			var message = Mapper.Map<Message>(dto);

			message.UserId = user.Id;

			_messageRepository.Add(message);
		}
	}
}
