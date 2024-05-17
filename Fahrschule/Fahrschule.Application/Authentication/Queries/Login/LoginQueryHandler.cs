using ErrorOr;
using Fahrschule.Application.Authentication.Common;
using Fahrschule.Application.Common.Interfaces.Authentication;
using Fahrschule.Application.Common.Interfaces.Persistence;
using Fahrschule.Domain.Common.Errors;
using Fahrschule.Domain.UserAggregate.Entities;
using MediatR;

namespace Fahrschule.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // 1. Validate that the user exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 2. Validate that the password is correct
            if (user.Password != query.Password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }

            // 3. Create JWT Token
            var token = _jwtTokenGenerator.GenerateToken(
                user
            );

            return new AuthenticationResult(
                user,
                token
            );
        }
    }
}
