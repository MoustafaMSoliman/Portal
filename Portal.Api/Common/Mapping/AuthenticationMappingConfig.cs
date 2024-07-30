using Mapster;
using Portal.Application.Services.Authentication.Commands;
using Portal.Application.Services.Authentication.Common;
using Portal.Application.Services.Authentication.Queries;
using Portal.Conttracts.Authentication;

namespace Portal.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthResult, AuthenticationResult>()
            .Map(dest=>dest.Token, src=>src.Token)
            .Map(dest=>dest.FirstName, src=>src.User.Profile.FirstName)
            .Map(dest=>dest.LastName, src=>src.User.Profile.LastName)
            .Map(dest=>dest.Email, src=>src.User.Email);
        config.NewConfig<RegisterCommand, RegisterRequest>()
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password);
        config.NewConfig<LoginQuery, LoginRequest>()
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password);
    }
}
