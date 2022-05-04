using System;
using AccountManagement.Application.Contracts.Account.folder;
using ShopManagment.Domain.Services;

namespace ShopManagment.Infrastructure.AccountAcl
{
    public class ShopAccountAcl: IShopAccountAcl
    {
        private readonly IAccountApplication _accountApplication;

        public ShopAccountAcl(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public (string name, string number) GetAccountBy(long id)
        {
            var account = _accountApplication.GetAccountBy(id);
            return (account.Fullname, account.Mobail);
        }
    }
}
