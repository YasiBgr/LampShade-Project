using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.CommentAgg;
using ShopManagmentAplication.Contracts.Comment.folder;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagment.Infrastructure.efCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly ShopContext _context;

        public CommentRepository(ShopContext context):base(context)
        {
            _context = context;
        }

        public List<CommentViewModel> GetList()
        {
            var list= _context.Comments.Include(x => x.Product).Select(x => new CommentViewModel
            {
                ProductName = x.Product.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                Email = x.Email,
                Id = x.Id,
                Message = x.Message,
                Name = x.Name,
                Status = x.Status,
                ProductId=x.ProductId,
                ProductCategory=x.Product.Category.Name
                
            }).ToList();
            return list;
        }

        public List<CommentViewModel> Search(CommentSearchModel command)
        {
            var query= _context.Comments.Select(x => new CommentViewModel 
            {
            Id=x.Id,
            Name=x.Name,
            Email=x.Email,
            Message=x.Message  ,
            CreationDate=x.CreationDate.ToFarsi(),
            ProductId=x.ProductId,
            ProductName=x.Product.Name,
            //IsCanceled=x.IsCanceled,
            //IsConfirmed=x.IsConfirmed
            Status=x.Status,
                ProductCategory = x.Product.Category.Name,
               
            });
            if (!string.IsNullOrWhiteSpace(command.Name))
                query = query.Where(x => x.Name.Contains(command.Name));
            if (!string.IsNullOrWhiteSpace(command.Email))
                query = query.Where(x => x.Email.Contains(command.Email));
            return query.OrderByDescending(x => x.Id).ToList();
    }
    }
}
