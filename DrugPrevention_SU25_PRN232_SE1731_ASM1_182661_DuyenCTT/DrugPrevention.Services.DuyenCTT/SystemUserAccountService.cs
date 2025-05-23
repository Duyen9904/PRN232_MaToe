using DrugPrevention.Repositories.DuyenCTT;
using DrugPrevention.Repositories.DuyenCTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.DuyenCTT
{
    public class SystemUserAccountService
    {
        private readonly SystemUserAccountRepository _repository;
        public SystemUserAccountService() => _repository = new SystemUserAccountRepository();
        public SystemUserAccountService(SystemUserAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task<SystemUserAccount> GetUserAccount(string username, string password)
        {
            return await _repository.GetUserAccount(username, password);
        }
    }
}
