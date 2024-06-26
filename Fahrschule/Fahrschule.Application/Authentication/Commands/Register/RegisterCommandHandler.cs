﻿using ErrorOr;
using Fahrschule.Application.Common.Interfaces.Authentication;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.Common.Errors;
using MediatR;
using Fahrschule.Application.Authentication.Common;
using Fahrschule.Domain.UserAggregate.Entities;

namespace Fahrschule.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // 1. Validate that the user doesn't exist
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            // 2. Create user ( generate unique ID ) & Persist to DB
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            _userRepository.Add(user);

            // 3. Create JWT Token

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token
            );
        }
    }
}
