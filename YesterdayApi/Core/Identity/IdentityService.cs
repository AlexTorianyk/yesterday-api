using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel.Client;
using IdentityServer.Core.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using YesterdayApi.Core.Identity.Web;
using YesterdayApi.Utilities.Exceptions;

namespace YesterdayApi.Core.Identity
{
    public class IdentityService : IIdentityService
    {
        private const string DiscoveryUrl = "http://localhost:5000";
        private readonly IUserIdentityService _userIdentityService;
        private readonly ITokenDecoder _tokenDecoder;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        public IdentityService(IUserIdentityService userIdentityService, ITokenDecoder tokenDecoder, IMapper mapper, IConfiguration configuration)
        {
            _userIdentityService = userIdentityService;
            _tokenDecoder = tokenDecoder;
            _mapper = mapper;
            _configuration = configuration;
            _client = new HttpClient();
        }

        public Task<string> GetAccessToken(UserIdentityRequest userIdentityRequest)
        {
            throw new NotImplementedException();
        }

        public Task<string> RefreshAccessToken(string authHeader)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> RegisterUser(UserRegistrationRequest userRegistrationRequest)
        {
            throw new NotImplementedException();
        }

        public Task SetAdmin(string userName)
        {
            throw new NotImplementedException();
        }

        private async Task<DiscoveryResponse> GetDiscoveryDocument()
        {
            var disco = await _client.GetDiscoveryDocumentAsync(DiscoveryUrl);
            if (disco.IsError)
            {
                throw new InternalServerErrorException("Error", "Encountered problems in the process of getting the discovery document.");
            }

            return disco;
        }
    }
}
