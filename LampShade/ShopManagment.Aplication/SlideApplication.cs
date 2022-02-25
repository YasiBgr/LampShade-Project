using _0_FramBase.Application;
using ShopManagment.Domain.SliderAgg;
using ShopManagmentAplication.Contracts.Slide.Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Aplication
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository )
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();
            var slide = new Slide(command.Picture, command.PictureAlt, command.PictureTitle,
                command.Text, command.Title, command.Heading, command.BtnText);
            _slideRepository.Create(slide);
            _slideRepository.Save();
           return operation.Succedded();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var result = _slideRepository.Get(command.Id);
            if (result==null)
                operation.Failed(ApplicationMessages.RecordNotFound);
            
            result.Edit(command.Picture, command.PictureAlt,
                command.PictureTitle, command.Text, command.Title, command.Heading, command.BtnText);
            _slideRepository.Save();
            return operation.Succedded();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }

        public OperationResult Removed(long Id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(Id);
            if (slide==null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }
            slide.IsRmoved();
            _slideRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Restore(long Id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(Id);
            if (slide == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }
            slide.Restore();
            _slideRepository.Save();
            return operation.Succedded();
        }
    }
}
