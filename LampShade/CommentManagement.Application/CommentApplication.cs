using _0_FramBase.Application;
using CommentManagement.Application.Contracts.Comment.folder;
using CommentManagement.CommentAgg;
using System.Collections.Generic;

namespace CommentManagement.Application
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
            var newComment = new Comment(command.Name,command.Email,command.Message,command.Website,command.OwnerRecordId,command.Type,command.ParentId);
            _commentRepository.Create(newComment);
            _commentRepository.Save();
            return operation.Succedded();

        }

        public OperationResult Confirm(long id)
        {
            var operation = new OperationResult();
            var newComment = _commentRepository.Get(id);
            if (newComment == null)
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

       

        public List<CommentViewModel> Search(CommentSearchModel command)
        {
            return _commentRepository.Search(command);
        }
    }
}