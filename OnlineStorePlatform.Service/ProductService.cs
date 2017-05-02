namespace OnlineStorePlatform.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.ViewModels.Products;
    using Models.EntityModels;
    using AutoMapper;
    using Models;
    using Interfaces;

    public class ProductService : Service, IProductService
    {
        public const int PageSize = 6;
        public ProductListVm GatProductsByCategory(string category, int page)
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
               .OrderBy(pro => pro.Id)
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

        public ProductListVm GetProducts(int page, string search)
        {
            ProductListVm model = new ProductListVm
            {
                Products = this.Context.Products.Where(product=>product.Name.StartsWith(search))
               .OrderBy(pro => pro.Id)
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

        public List<string> GetProductsAsString(string term)
        {
            return this.Context.Products.Where(product => product.Name.StartsWith(term)).Select(p => p.Name).ToList();
        }

        public ProductModalVm GetProductForModalView(int id)
        {
            Product product = this.Context.Products.Find(id);
            ProductModalVm vm = Mapper.Map<Product, ProductModalVm>(product);
            return vm;

        }
    }
}
