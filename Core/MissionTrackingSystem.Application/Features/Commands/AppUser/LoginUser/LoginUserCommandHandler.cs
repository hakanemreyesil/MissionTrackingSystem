using MediatR;
using Microsoft.AspNetCore.Identity;
using MissionTrackingSystem.Application.Abstractions.Token;
using MissionTrackingSystem.Application.DTOs;
using MissionTrackingSystem.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signinManager;
        readonly ITokenHandler _tokenHandler;
        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, 
            SignInManager<Domain.Entities.Identity.AppUser> signinManager, 
            ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _tokenHandler = tokenHandler;
        }




        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(request.UsernameorEmail);
            if (user == null)
                user = await _userManager.FindByNameAsync(request.UsernameorEmail);
            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signinManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(5);
                return new LoginUserSuccessCommandResponse()
                {
                    Token = token

                };
            }
            //return new LoginUserErrorCommandResponse()
            //{
            //    Message = "Kullanıcı adı veya şifre hatalı"
            //};
            throw new AuthenticationErrorException();
            
        }
    }
}
