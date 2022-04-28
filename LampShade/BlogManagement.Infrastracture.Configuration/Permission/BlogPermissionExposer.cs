using System.Collections.Generic;
using _0_FramBase.Infrastructure;

namespace BlogManagement.Infrastracture.Configuration.Permission
{
    public class BlogPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                "Article",new List<PermissionDto>
                {

                    new PermissionDto("CreateArticle", BlogPermission.CreateArticle),
                    new PermissionDto("EditArticle", BlogPermission.EditArticle),
                    new PermissionDto("ListArticle", BlogPermission.ListArticle),
                }
                },
                {
                    "ArticleCategory",new List<PermissionDto>
                    {

                        new PermissionDto("CreateArticleCategory", BlogPermission.CreateArticleCategory),
                        new PermissionDto("EditArticleCategory", BlogPermission.EditArticleCategory),
                        new PermissionDto("ListArticleCategory", BlogPermission.ListArticleCategory),
                    }
                }
            };
        }
    }
}
