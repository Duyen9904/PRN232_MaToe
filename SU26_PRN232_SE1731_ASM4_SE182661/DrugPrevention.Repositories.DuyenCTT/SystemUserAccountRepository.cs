using DrugPrevention.Repositories.DuyenCTT.Basic;
using DrugPrevention.Repositories.DuyenCTT.DBContext;
using DrugPrevention.Repositories.DuyenCTT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.DuyenCTT
{
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository() { }
        public SystemUserAccountRepository(SE18_PRN232_SE1731_G2_MaToeContext context) => _context = context;

        public async Task<SystemUserAccount> GetUserAccount(string username, string password)
        {
            return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Email == username && u.Password == password && u.IsActive == true);
            //return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }
    }
}
