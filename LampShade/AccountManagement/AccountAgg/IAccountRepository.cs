using _0_FramBase.Domain;
using AccountManagement.Application.Contracts.Account.folder;
using System.Collections.Generic;

namespace CommentManagement.CommentAgg
{
    public interface IAccountRepository : IRepository<long, Account>
    {
        Account GetBy(string username);
        List<AccountViewModel> Search(AccountSearchModel command);
        List<AccountViewModel> GetAccount();
        EditAccount GetDetails(long id);
    }
}
