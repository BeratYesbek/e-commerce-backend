using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.Concretes;
using Core.Utilities.Results.Abstracts;
using DataAccess.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dtos;
using System.Linq;
namespace DataAccess.Concretes
{
    public class EfProductDal : EntityRepositoryBase<Product, DatabaseContext>, IProductDal
    {
        public List<ProductDto> GetAllProductDetail(Expression<Func<ProductDto, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from product in context.Products
                             join catergory in context.Categories on product.CategoryId equals catergory.CategoryId
                             join brand in context.Brands on product.BrandId equals brand.BrandId
                             join color in context.Colors on product.ColorId equals color.ColorId
                             select new ProductDto
                             {
                                 ProductId = product.ProductId,
                                 ProductDescription = product.ProductDescription,
                                 ProductName = product.ProductName,
                                 ProductPrice = product.ProductPrice,
                                 ProductQuantity = product.ProductQuantity,
                                 CategoryId = catergory.CategoryId,
                                 CategoryName = catergory.CategoryName,
                                 BrandName =  brand.BrandName,
                                 BrandId = brand.BrandId, 
                                 BrandLogo = brand.BrandImagePath,
                                 ColorId = color.ColorId,
                                 ColorName = color.ColorName,   
                                 ColorCode = color.ColorCode,   
                                 Comments = (from i in context.Comments where i.ProductId == product.ProductId select i).ToList(),
                                 Images = (from i in context.ProductImages where i.ProductId == product.ProductId select i.ImagePath).ToList()

                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        public ProductDto GetProductDetailById(Expression<Func<Product, bool>> filter)
        {
            using(DatabaseContext context = new DatabaseContext())
            {
                var result = from product in context.Products.Where(filter)
                             join catergory in context.Categories on product.CategoryId equals catergory.CategoryId
                             join color in context.Colors on product.ColorId equals color.ColorId
                             join brand in context.Brands on product.BrandId equals brand.BrandId
                             select new ProductDto
                             {
                                 ProductId = product.ProductId,
                                 ProductDescription = product.ProductDescription,
                                 ProductName = product.ProductName,
                                 ProductPrice = product.ProductPrice,
                                 ProductQuantity = product.ProductQuantity,
                                 CategoryId = catergory.CategoryId,
                                 CategoryName = catergory.CategoryName,
                                 BrandName = brand.BrandName,
                                 BrandId = brand.BrandId,
                                 BrandLogo = brand.BrandImagePath,
                                 ColorId = color.ColorId,
                                 ColorName = color.ColorName,
                                 ColorCode = color.ColorCode,
                                 Comments = (from i in context.Comments where i.ProductId == product.ProductId select i).ToList(),
                                 Images = (from i in context.ProductImages where i.ProductId == product.ProductId select i.ImagePath).ToList()
                             };

                    return result.Single();
            }
        }
    }
}
