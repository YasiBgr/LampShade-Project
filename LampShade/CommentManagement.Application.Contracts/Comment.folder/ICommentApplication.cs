using _0_FramBase.Application;
using System.Collections.Generic;

namespace CommentManagement.Application.Contracts.Comment.folder
{
    public interface ICommentApplication
    {
        OperationResult AddComment(AddComment command);
        OperationResult Confirm(long id);
        OperationResult Delete(long id);
        List<CommentViewModel> Search(CommentSearchModel command);
      
    }
}
