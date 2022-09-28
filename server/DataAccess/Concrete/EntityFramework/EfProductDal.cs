using Entities.Concrete;
using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ProductCatalogContext>, IProductDal
    {
        public List<ProductDetailsDto> GetAllProductDetails(Expression<Func<ProductDetailsDto, bool>> filter = null)
        {
            using (ProductCatalogContext context = new ProductCatalogContext())
            {
                var result = from p in context.Products
                             join b in context.Brands on p.BrandId equals b.BrandId into blist from b in blist.DefaultIfEmpty()
                             join i in context.ProductImages on p.ProductId equals i.ProductId
                             join c in context.Colors on p.ColorId equals c.ColorId into clist from c in clist.DefaultIfEmpty()
                             join a in context.Categories on p.CategoryId equals a.CategoryId
                             join u in context.UsingStatuses on p.UsingStatusId equals u.UsingStatusId
                             join o in context.Users on p.UserId equals o.UserId
                             select new ProductDetailsDto
                             {
                                 CategoryId = a.CategoryId,
                                 ProductId = p.ProductId,
                                 BrandName = b.Name,
                                 CategoryName = a.Name,
                                 ImagePath = i.ImagePath,
                                 ColorName = c.Name,
                                 Description = p.Description,
                                 InsertTime = p.InsertTime,
                                 IsOfferable = p.IsOfferable,
                                 IsSold = p.IsSold,
                                 Price = p.Price,
                                 ProductName = p.ProductName,
                                 UsingStatusName = u.Name,
                                 UserName = o.FirstName +" "+ o.LastName
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        public void UpdateIsSold(int productId, bool isSold)
        {
            var product = new Product { ProductId = productId, IsSold = isSold };
            using (ProductCatalogContext contex = new ProductCatalogContext())
            {
                contex.Products.Attach(product);
                contex.Entry(product).Property(p => p.IsSold).IsModified = true;
                contex.SaveChanges();
            }
        }
    }
}
