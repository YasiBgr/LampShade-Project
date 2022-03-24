using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using ShopManagment.Domain.SliderAgg;
using ShopManagmentAplication.Contracts.Slide.Folder;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagment.Infrastructure.efCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                BtnText = x.BtnText,
                Heading = x.Heading,
              
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
                Title = x.Title,
                Link=x.Link
                
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Heading = x.Heading,
                Picture = x.Picture,
                Title = x.Title,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved =x.IsRemove

            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
