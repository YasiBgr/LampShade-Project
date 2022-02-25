using _0_FramBase.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagmentAplication.Contracts.Slide.Folder
{
  public  interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        OperationResult Removed(long Id);
        OperationResult Restore(long Id);
        List<SlideViewModel> GetList();
        EditSlide GetDetails(long id);
    }
}
