using _0_FramBase.Domain;
using CommentManagement.Application.Contracts.Comment.folder;
using System.Collections.Generic;

namespace CommentManagement.CommentAgg
{
    public interface ICommentRepository : IRepository<long, Comment>
    {
        List<CommentViewModel> Search(CommentSearchModel command);

    }
}
