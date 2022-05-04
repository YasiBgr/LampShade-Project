using System.Collections.Generic;
using _01_LampshadeQuery;
using _01_LampshadeQuery.Contract.Article;
using _01_LampshadeQuery.Contract.ArticleCategory;
using _01_LampshadeQuery.Contract.Product;
using _01_LampshadeQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiseHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly IProductQuery _productQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        private readonly IArticleQuery _articleQuery;

        public MenuViewComponent(IProductCategoryQuery productCategoryQuery, IProductQuery productQuery, IArticleCategoryQuery articleCategoryQuery, IArticleQuery articleQuery)
        {
            _productCategoryQuery = productCategoryQuery;
            _productQuery = productQuery;
            _articleCategoryQuery = articleCategoryQuery;
            _articleQuery = articleQuery;
        }

        public IViewComponentResult Invoke()
        {

            var result = new MenuModel()
            {
                ProductCategories = _productCategoryQuery.GetListProductCategory(),
                Products = _productQuery.GetListProduct(),
                ArticleCategory = _articleCategoryQuery.GetArticleCategories(),
                Article = _articleQuery.GetListArticles()

            
            };
            

            return View(result);
        }
    }
}
