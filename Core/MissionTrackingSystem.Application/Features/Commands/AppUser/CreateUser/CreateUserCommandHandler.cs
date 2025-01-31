﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using MissionTrackingSystem.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
           IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id=Guid.NewGuid().ToString(),
                UserName = request.UserName,
                Email = request.Email,
                FullName = request.FullName,

            }, request.Password);

            CreateUserCommandResponse response = new(){ Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";

            else
            
                foreach(var error in result.Errors)
                    response.Message += $" {error.Code} - {error.Description}\n";

                return response;
            
            
        }
    }
}
