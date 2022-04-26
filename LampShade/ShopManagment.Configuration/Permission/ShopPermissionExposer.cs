using _0_FramBase.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Configuration.Permission
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Product",
                    new List<PermissionDto>
                    {
                        new PermissionDto("ListProduct", ShopPermission.ListProduct),
                        new PermissionDto("SearchProducts", ShopPermission.SearchProduct),
                        new PermissionDto("CreateProducts", ShopPermission.CreateProduct),
                        new PermissionDto("EditProducts", ShopPermission.EditProduct),
                    }
                },

                {
                    "ProductCategory",
                    new List<PermissionDto>
                    {
                        new PermissionDto("ListProductCategory", ShopPermission.ListProductCategory),
                        new PermissionDto("SearchProductCategory", ShopPermission.SearchProductCategory),
                        new PermissionDto("CreateProductCategory", ShopPermission.CreateProductCategory),
                        new PermissionDto("EditProductCategory", ShopPermission.EditProductCategory),
                    }
                }
            };
        }
    }
}
