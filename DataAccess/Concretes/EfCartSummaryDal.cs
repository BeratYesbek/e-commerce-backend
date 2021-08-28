using Core.DataAccess.Concretes;
using DataAccess.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concretes
{
    public class EfCartSummaryDal : EntityRepositoryBase<CartSummary, DatabaseContext>, ICartSummaryDal
    {
        public List<CartSummaryDto> GetCartSummaryDetailByUserId(Expression<Func<CartSummary, bool>> filter)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from cartSummary in context.CartSummaries.Where(filter)
                             join product in context.Products on cartSummary.ProductId equals product.ProductId 
                             join category in context.Categories on product.CategoryId equals category.CategoryId
                             join color in context.Colors on product.ColorId equals color.ColorId
                             join brand in context.Brands on product.BrandId equals brand.BrandId
                             

                             select new CartSummaryDto
                             {
                                 Id = cartSummary.Id,
                                 UserId = cartSummary.UserId,
                                 ProductId = cartSummary.ProductId,
                                 Product = product,
                                 Category = category,
                                 Brand = brand,
                                 Color = color,
                                 Images = (from image in context.ProductImages where image.ProductId == product.ProductId select image.ImagePath).ToList()
                             };
               
                return result.ToList();
            }
        }
    }
}
