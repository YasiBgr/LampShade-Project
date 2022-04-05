using _0_FramBase.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Account.folder
{
    public interface IAccountApplication
    {
        OperationResult Create(CreateAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult ChangePassword(ChangePassword command);
        OperationResult Login(Login command);
        EditAccount GetDetails(long id);
        List<AccountViewModel> Search(AccountSearchModel command);
        void Logout();
    }
}
