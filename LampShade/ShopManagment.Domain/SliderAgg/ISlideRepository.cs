using _0_FramBase.Domain;
using ShopManagmentAplication.Contracts.Slide.Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.SliderAgg
{
   public interface ISlideRepository:IRepository<long,Slide>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
