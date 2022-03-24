using _0_FramBase.Application;
using ShopManagment.Domain.CommentAgg;
using ShopManagmentAplication.Contracts.Comment.folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Aplication
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public OperationResult AddComment(AddComment command)
        {
            var operation = new OperationResult();
            var newComment = new Comment(command.Name, command.Email, command.Message, command.ProductId);
            _commentRepository.Create(newComment);
            _commentRepository.Save();
            return operation.Succedded();

        }

        public OperationResult Confirm(long id)
        {
            var operation = new OperationResult();
            var newComment = _commentRepository.Get(id);
            if (newComment==null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            newComment.Confirm();
            _commentRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var newComment = _commentRepository.Get(id);
            if (newComment == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            newComment.Cancel();
            _commentRepository.Save();
            return operation.Succedded();
        }

        public List<CommentViewModel> GetList()
        {
             var res=_commentRepository.GetList();
            return res;
        }

        public List<CommentViewModel> Search(CommentSearchModel command)
        {
            return _commentRepository.Search(command);
        }
    }
}