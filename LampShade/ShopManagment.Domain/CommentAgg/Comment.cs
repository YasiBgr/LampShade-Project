using _0_FramBase.Domain;
using ShopManagment.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.CommentAgg
{
    public class Comment : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
       // public bool IsConfirmed { get; private set; }
      //  public bool IsCanceled { get; private set; }
        public long ProductId { get; set; }
        public int Status { get; private set; }
        public Product Product { get; private set; }

        public Comment(string name, string email, string message, long productId)
        {
            Name = name;
            Email = email;
            Message = message;
            ProductId = productId;
            Status = Statuses.New;
        }
        public Comment()
        {

        }
        public void Confirm()
        {
            this.Status = Statuses.Confirmed;
        }

        public void Cancel()
        {
            this.Status = Statuses.Canceled;

        }
    }
}

