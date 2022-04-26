using _0_FramBase.Application;
using AccountManagement.Application.Contracts.Account.folder;
using System.Collections.Generic;
using System.Linq;
using AccountManagement.AccountAgg;
using AccountManagement.RoleAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRoleRepository _RoleRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;

        public AccountApplication(IAccountRepository accountRepository,
            IPasswordHasher passwordHasher, IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
            _RoleRepository = roleRepository;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordNotMatch);
            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();
            if (_accountRepository.Exist(x => x.Username == command.Username || x.Mobail == command.Mobail))
                return operation.Failed(ApplicationMessages.DublicatedRecord);
            var password = _passwordHasher.Hash(command.Password);
            var path = $"ProfilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            var newaccount = new Account(command.Fullname, command.Username, password, command.RollId, command.Mobail, picturePath);
            _accountRepository.Create(newaccount);
            _accountRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_accountRepository.Exist(x => (x.Username == command.Username || x.Mobail == command.Mobail) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DublicatedRecord);
            var path = $"ProfilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            account.Edit(command.Fullname, command.Username, command.RollId, command.Mobail, picturePath);
            _accountRepository.Save();
            return operation.Succedded();
        }

        public List<AccountViewModel> GetAccount()
        {
            return _accountRepository.GetAccount();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.Username);
            if (account == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);
            var result = _passwordHasher.Check(account.Password, command.Password);
            if (!result.Verified)
                 return  operation.Failed(ApplicationMessages.WrongUserPass);

            var permissions = _RoleRepository.Get(account.RollId).Permissions.Select(x => x.Code).ToList();
           
                var authViewModel = new AuthViewModel(account.Id, account.RollId, account.Fullname, account.Username, account.Mobail,permissions);
                _authHelper.Signin(authViewModel);
                operation.Succedded(ApplicationMessages.LoginIsSuccedded);
                return operation.Succedded();
            

        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public List<AccountViewModel> Search(AccountSearchModel command)
        {
            return _accountRepository.Search(command);
        }
    }
}