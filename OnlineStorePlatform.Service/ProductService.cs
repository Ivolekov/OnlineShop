namespace OnlineStorePlatform.Service
{
    using OnlineStorePlatform.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.ViewModels.Products;
    using Models.EntityModels;
    using AutoMapper;
    using Models;

    public class ProductService : Service
    {
        public const int PageSize = 6;
        //public IEnumerable<GetAllProductsVm> GatAllProducts(int page)
        public ProductListVm GatProducts(string category, int page)
        {
            ProductListVm model = new ProductListVm
            {
                Products = this.Context.Products
                .Where(p => category == null || p.Category.Name == category)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                   this.Context.Products.Count() :
                   this.Context.Products.Where(p => p.Category.Name == category).Count()
                },
                CurrentCategory = category
            };

            //IEnumerable<Product> model = this.Context.Products
            //    .OrderBy(p=>p.Id)
            //    .Skip((page-1)*PageSize)
            //    .Take(PageSize);

            //IEnumerable<GetAllProductsVm> vms = Mapper.Instance.Map<IEnumerable<Product>, IEnumerable<GetAllProductsVm>>(model);
            //return vms;

            return model;
        }

        public ProductListVm GetAllProducts(int page)
        {
            ProductListVm model = new ProductListVm
            {
                Products = this.Context.Products
               .OrderBy(p => p.Id)
               .Skip((page - 1) * PageSize)
               .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = this.Context.Products.Count()
                }
            };

            return model;
        }
    }
}
