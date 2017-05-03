using AutoMapper;
using OnlineStorePlatform.Data;
using OnlineStorePlatform.Models.BindingModels;
using OnlineStorePlatform.Models.BindingModels.Blog;
using OnlineStorePlatform.Models.BindingModels.Cart;
using OnlineStorePlatform.Models.BindingModels.Category;
using OnlineStorePlatform.Models.BindingModels.Product;
using OnlineStorePlatform.Models.EntityModels;
using OnlineStorePlatform.Models.EntityModels.Cart;
using OnlineStorePlatform.Models.ViewModels.Blog;
using OnlineStorePlatform.Models.ViewModels.Category;
using OnlineStorePlatform.Models.ViewModels.Order;
using OnlineStorePlatform.Models.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OnlineStorePlatform.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigerMapper();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(Cart), new CartBm());

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OnlineStorePlatformContext>());
        }

        private void ConfigerMapper()
        {
            Mapper.Initialize(expresion =>
            {
                expresion.CreateMap<Category, CategoriesVm>();

                expresion.CreateMap<AddNewCategoryBm, Category>();

                expresion.CreateMap<Category, EditCategoryVm>();

                expresion.CreateMap<Category, DeleteCategoryVm>();

                expresion.CreateMap<Product, GetAllProductsVm>()
               .ForMember(vm => vm.CategoryName, configurationExpresion => configurationExpresion
                 .MapFrom(product => product.Category.Name));

                expresion.CreateMap<Product, EditProductVm>().ForMember(vm => vm.CategoryName, configurationExpresion => configurationExpresion
                  .MapFrom(product => product.Category.Name));

                expresion.CreateMap<EditProductBm, Product>();

                expresion.CreateMap<Product, DeleteProductVm>();

                expresion.CreateMap<Product, ProductModalVm>();

                expresion.CreateMap<Order, OrderVm>();

                expresion.CreateMap<User, ArticleAuthorViewModel>();

                expresion.CreateMap<AddNewArticleBm, Article>();

                expresion.CreateMap<Article, ArticleViewModel>();
            });
        }
    }
}
