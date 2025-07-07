using DrugPrevention.Repositories.DuyenCTT.ModelExtensions;
using DrugPrevention.Repositories.DuyenCTT.SoapModels;
using DrugPrevention.Services.DuyenCTT;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace DrugPrevention.SoapApiServices.DuyenCTT.SoapServices
{
    [ServiceContract]
    public interface IAccountSoapService
    {
        [OperationContract]
        Task<List<SystemUserAccount>> GetAllAsync();
        [OperationContract]
        Task<SystemUserAccount> GetByCredentialsAsync(string username, string password);
    }

    public class AccountSoapService : IAccountSoapService
    {
        private readonly IServiceProviders _serviceProviders;

        public AccountSoapService(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        public async Task<List<SystemUserAccount>> GetAllAsync()
        {
            var result = await _serviceProviders.UserAccountService.GetUserAccounts();
            return JsonMapper.Map<List<Repositories.DuyenCTT.Models.SystemUserAccount>, List<SystemUserAccount>>(result);
        }

        public async Task<SystemUserAccount> GetByCredentialsAsync(string username, string password)
        {
            var repoModel = await _serviceProviders.UserAccountService.GetUserAccount(username, password);
            return JsonMapper.Map<Repositories.DuyenCTT.Models.SystemUserAccount, SystemUserAccount>(repoModel);
        }
    }
}
