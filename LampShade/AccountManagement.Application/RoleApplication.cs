﻿using _0_FramBase.Application;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.RoleAgg;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResult CreateRole(CreateRole command)
        {
            var operation = new OperationResult();
            if (_roleRepository.Exist(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DublicatedRecord);
            var role = new Role(command.Name);
            _roleRepository.Create(role);
            _roleRepository.Save();
            return operation.Succedded();

        }

        public OperationResult EditRole(EditRole command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.Get(command.Id);
            if (role == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_roleRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DublicatedRecord);
            role.Edit(command.Name);
            _roleRepository.Save();
            return operation.Succedded();
        }

        public EditRole GetDetails(long id)
        {
            return _roleRepository.GetDetails(id);

        }

        public List<RoleViewModel> List()
        {
            return _roleRepository.List();
        }
    }
}
