using System.Collections.Generic;
using _0_FramBase.Infrastructure;

namespace CommentManagement.Configuration.Permission
{
    public class CommentPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                "Comment",new List<PermissionDto>
                {

                    new PermissionDto("AddComment", CommentPermission.AddComment),
                    new PermissionDto("ConfirmComment", CommentPermission.ConfirmComment),
                    new PermissionDto("CancelComment", CommentPermission.CancelComment),
                    new PermissionDto("ListComment", CommentPermission.ListComment),
                      }

                }
            };
        }
    }
}
