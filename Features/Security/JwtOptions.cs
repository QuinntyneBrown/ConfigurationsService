using Microsoft.Owin.Security.Jwt;
using System;
using ConfigurationsService.Features.Security;

namespace ConfigurationsService.Features.Security
{
    public class JwtOptions : JwtBearerAuthenticationOptions
    {
        public JwtOptions(Lazy<IAuthConfiguration> lazyAuthConfiguration)
        {
            _lazyAuthConfiguration = lazyAuthConfiguration;
            AllowedAudiences = new[] { _authConfiguration.JwtAudience };
            IssuerSecurityTokenProviders = new[] 
            {
                new SymmetricKeyIssuerSecurityTokenProvider(_authConfiguration.JwtIssuer, _authConfiguration.JwtKey)
            };
        }

        protected IAuthConfiguration _authConfiguration { get { return _lazyAuthConfiguration.Value; } }
        protected Lazy<IAuthConfiguration> _lazyAuthConfiguration;
    }
}
