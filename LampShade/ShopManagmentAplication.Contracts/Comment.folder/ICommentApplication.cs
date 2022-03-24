using _0_FramBase.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagmentAplication.Contracts.Comment.folder
{
   public interface ICommentApplication
    {
        OperationResult AddComment(AddComment command);
        OperationResult Confirm(long id);
        OperationResult Delete(long id);
        List<CommentViewModel> Search(CommentSearchModel command);
        List<CommentViewModel> GetList();
    }
}
