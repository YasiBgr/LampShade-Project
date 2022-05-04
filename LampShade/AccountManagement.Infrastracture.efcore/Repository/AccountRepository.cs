using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using AccountManagement.Application.Contracts.Account.folder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.AccountAgg;

namespace AccountManagement.Infrastracture.efcore.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _accountContext;

        public AccountRepository(AccountContext accountContext):base(accountContext)
        {
            _accountContext = accountContext;
        }

        public List<AccountViewModel> GetAccount()
        {
            return _accountContext.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname
            }).ToList(); 
        }

        public Account GetBy(string username)
        {
            return _accountContext.Accounts.Where(x=>!x.Delete).FirstOrDefault(x => x.Username == username);
        }

        public EditAccount GetDetails(long id)
        {
            return _accountContext.Accounts.Select(x => new EditAccount 
            {
            Id=x.Id,
            Fullname=x.Fullname,
             Mobail=x.Mobail,
             Password=x.Password,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> Search(AccountSearchModel command)
        {
            var query = _accountContext.Accounts
                .Include(x=>x.Role)
                .Select(x => new AccountViewModel
            {
                Id = x.Id,
                Username = x.Username,
                Password = x.Password,
                Fullname = x.Fullname,
                ProfilePhoto = x.ProfilePhoto,
                Mobail = x.Mobail,
                Roll = x.Role.Name,
                RollId = x.RollId,
                CreationDate = x.CreationDate.ToFarsi(),
                Delete = x.Delete
                
            }).Where(x=>!x.Delete) ;

            if (!string.IsNullOrWhiteSpace(command.Fullname))
                query = query.Where(x => x.Fullname.Contains(command.Fullname));

            if (!string.IsNullOrWhiteSpace(command.Username))
                query = query.Where(x => x.Fullname.Contains(command.Username));

            if (!string.IsNullOrWhiteSpace(command.Mobail))
                query = query.Where(x => x.Fullname.Contains(command.Mobail));
            if (command.RollId > 0)
                query = query.Where(x => x.RollId == command.RollId);
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
