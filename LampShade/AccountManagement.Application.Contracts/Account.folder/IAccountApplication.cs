using _0_FramBase.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Account.folder
{
    public interface IAccountApplication
    {
        AccountViewModel GetAccountBy(long id);
        OperationResult Register (RegisterAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult DeleteAccount(long id);
        OperationResult ChangePassword(ChangePassword command);
        OperationResult Login(Login command);
        EditAccount GetDetails(long id);
        List<AccountViewModel> Search(AccountSearchModel command);
        List<AccountViewModel> GetAccount();
        void Logout();
    }
}
