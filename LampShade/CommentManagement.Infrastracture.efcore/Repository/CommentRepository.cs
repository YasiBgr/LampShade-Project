using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using CommentManagement.Application.Contracts.Comment.folder;
using CommentManagement.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CommentManagement.Infrastracture.efcore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _context;

        public CommentRepository(CommentContext context) : base(context)
        {
            _context = context;
        }

      
        public List<CommentViewModel> Search(CommentSearchModel command)
        {
            var query = _context.Comments.Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Website=x.Website,
                Message = x.Message,
                OwnerRecordId=x.OwnerRecordId,
                Type=x.Type,
                CreationDate = x.CreationDate.ToFarsi(),
               // ProductId = x.ProductId,
               // ProductName = x.Product.Name,
                //IsCanceled=x.IsCanceled,
                //IsConfirmed=x.IsConfirmed
                Status = x.Status,
               // ProductCategory = x.Product.Category.Name,

            });
            if (!string.IsNullOrWhiteSpace(command.Name))
                query = query.Where(x => x.Name.Contains(command.Name));
            if (!string.IsNullOrWhiteSpace(command.Email))
                query = query.Where(x => x.Email.Contains(command.Email));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
