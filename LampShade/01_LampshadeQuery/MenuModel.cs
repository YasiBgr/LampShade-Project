using _01_LampshadeQuery.Contract.ArticleCategory;
using _01_LampshadeQuery.Contract.ProductCategory;
using System.Collections.Generic;
using System.Linq;
using _01_LampshadeQuery.Contract.Product;
using ShopManagmentAplication.Contracts.Product.folder;
using ShopManagmentAplication.Contracts.ProductCategory.folder;
using Microsoft.AspNetCore.Mvc;
using _01_LampshadeQuery.Contract.Article;

namespace _01_LampshadeQuery
{

    public class MenuModel
    {
     
            public List<ProductCategoryQueryModel> ProductCategories { get; set; }
            public List<ProductQueryModel> Products { get; set; }
           public List<ArticleCategoryQueryModel> ArticleCategory { get; set; }
           public List<ArticleQueryeModel> Article { get; set; }
        //public List<ProductQueryModel> Products { get; set; }
        //{

        //    private readonly IProductApplication _productApplication;
        //    private readonly IProductCategoryApplication _productCategoryApplication;

        //    public MenuModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        //    {
        //        _productApplication = productApplication;
        //        _productCategoryApplication = productCategoryApplication;
        //    }


        //    public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        //    public List<ProductCategoryViewModel> ProductCategories { get; set; }
        //    public List<ProductViewModel> Products { get; set; }



        //    public List<ProductViewModel> listProducts()
        //    {
        //        Products = _productApplication.GetProducts();
        //        return Products;
        //    }

        //    public List<ProductCategoryViewModel> listCategory()
        //    {
        //        ProductCategories = _productCategoryApplication.GetProductCategories();
        //        return ProductCategories;
        //    }
    }
}
