using _0_FramBase.Domain;
using ShopManagmentAplication.Contracts.Comment.folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long, Comment>
    {
        List<CommentViewModel> Search(CommentSearchModel command);
        List<CommentViewModel> GetList();
      
    }
}
