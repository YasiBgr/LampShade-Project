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
        private readonly IFileUploader _fileUploader;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();

            var picturePath = _fileUploader.Upload(command.Picture, "Slide");
            var slide = new Slide(picturePath, command.PictureAlt, command.PictureTitle,
                command.Text, command.Title, command.Heading, command.BtnText,command.Link);
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
            var picturePath = _fileUploader.Upload(command.Picture, "Slide");

            result.Edit(picturePath, command.PictureAlt,
                command.PictureTitle, command.Text, command.Title, command.Heading, command.BtnText,command.Link);
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
