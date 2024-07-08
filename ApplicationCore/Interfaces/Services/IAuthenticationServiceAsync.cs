using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IAuthenticationServiceAsync
    {
        public Task<int> InsertAuthentication(AuthenticationRequestModel model);
        public Task<int> UpdateAuthentication(AuthenticationRequestModel model, int id);
        public Task<int> DeleteAuthentication(int id);
        public Task<IEnumerable<AuthenticationResponseModel>> GetAllAuthentication();

        public Task<AuthenticationResponseModel> GetAuthenticationById(int id);
    }
}
