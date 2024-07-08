using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AuthenticationRepositoryAsync : BaseRepositoryAsync<Authentication>, IAuthenticationRepositoryAsync
    {
        public AuthenticationRepositoryAsync(EShopDbContext db) : base(db)
        {
        }
    }
}
