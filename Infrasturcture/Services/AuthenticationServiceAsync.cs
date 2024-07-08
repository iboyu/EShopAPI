using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthenticationServiceAsync : IAuthenticationServiceAsync
    {
        private readonly IAuthenticationRepositoryAsync AuthenticationRepositoryAsync;
        private readonly IMapper mapper;

        public AuthenticationServiceAsync(IAuthenticationRepositoryAsync repo, IMapper mapper)
        {
            AuthenticationRepositoryAsync = repo;
            this.mapper = mapper;
        }
        public async Task<int> DeleteAuthentication(int id)
        {
            var result = await AuthenticationRepositoryAsync.GetAsync(id);
            if(result == null)
            {
                return -1;
            }
            return await AuthenticationRepositoryAsync.DeleteAsync(id);

        }

        public async Task<IEnumerable<AuthenticationResponseModel>> GetAllAuthentication()
        {
            var result = await AuthenticationRepositoryAsync.GetAllAsync();
            if(result == null)
            {
                return null;
            }
            return mapper.Map<IEnumerable<AuthenticationResponseModel>>(result);
        }

        public async Task<AuthenticationResponseModel> GetAuthenticationById(int id)
        {
            var result = await AuthenticationRepositoryAsync.GetAsync(id);
            if (result == null)
            {
                return null;
            }
            return mapper.Map<AuthenticationResponseModel>(result);
        }

        public async Task<int> InsertAuthentication(AuthenticationRequestModel model)
        {
            return await AuthenticationRepositoryAsync.InsertAsync(mapper.Map<Authentication>(model));
        }

        public async Task<int> UpdateAuthentication(AuthenticationRequestModel model, int id)
        {
            var result = await AuthenticationRepositoryAsync.GetAsync(id);
            if(result == null)
            {
                return -1;
            }

            return await AuthenticationRepositoryAsync.UpdateAsync(mapper.Map<Authentication>(result));
        }
    }
}
