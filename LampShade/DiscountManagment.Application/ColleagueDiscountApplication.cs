using _0_FramBase.Application;
using DiscountManagmengDomain.ColleagueDiscount;
using DiscountManagment.Application.Contract.ColleagueDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagment.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            var operation = new OperationResult();
            if (_colleagueDiscountRepository.Exist(x => x.ProductId == x.ProductId && x.DiscountRate == command.DiscountRate ))
                return operation.Failed(ApplicationMessages.DublicatedRecord);
            var define = new ColleagueDiscount(command.ProducrId, command.DiscountRate);
            _colleagueDiscountRepository.Create(define);
            _colleagueDiscountRepository.Save();
            return operation.Succedded();

        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(command.Id);
            if (colleagueDiscount == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_colleagueDiscountRepository.Exist(x => x.ProductId == x.ProductId && x.DiscountRate == command.DiscountRate && x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DublicatedRecord);

            colleagueDiscount.Edit(command.ProducrId, command.DiscountRate);
            _colleagueDiscountRepository.Save();
            return operation.Succedded();
            
        }

        public EditColleagueDiscount GetDetails(long id)
        {
          return  _colleagueDiscountRepository.GetDetails(id);

        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            if (colleagueDiscount == null) return operation.Failed(ApplicationMessages.RecordNotFound);

            colleagueDiscount.Remove();
            _colleagueDiscountRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            if (colleagueDiscount == null) return operation.Failed(ApplicationMessages.RecordNotFound);

            colleagueDiscount.Restore();
            _colleagueDiscountRepository.Save();
            return operation.Succedded();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel command)
        {
            return _colleagueDiscountRepository.Search(command).ToList();
        }
    }
}
