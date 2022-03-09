using _0_FramBase.Application;
using DiscountManagmengDomain.CustomerDiscount;
using DiscountManagment.Application.Contract.CustomerDiscount;
using System;
using System.Collections.Generic;

namespace DiscountManagment.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var operation = new OperationResult();
            if (_customerDiscountRepository.Exist(x => x.ProductId == command.ProductId && x.DicountRate == command.DicountRate))
                return operation.Failed(ApplicationMessages.DublicatedRecord);
            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();
            var defineCustomer = new CustomerDiscount(command.ProductId, command.DicountRate, startDate, endDate, command.Occasion);
            _customerDiscountRepository.Create(defineCustomer);
            _customerDiscountRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operation = new OperationResult();
            var customerDiscount = _customerDiscountRepository.Get(command.Id);
            if (customerDiscount == null)
                operation.Failed(ApplicationMessages.RecordNotFound);

            if (_customerDiscountRepository.Exist(x=>x.ProductId==command.ProductId &&
            x.DicountRate==command.DicountRate && x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DublicatedRecord);

            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();
            customerDiscount.Edit(command.ProductId, command.DicountRate, startDate, endDate, command.Occasion);
            
            _customerDiscountRepository.Save();
            return operation.Succedded();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
         return   _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel command)
        {
            return _customerDiscountRepository.Search(command);
        }
    }
}
