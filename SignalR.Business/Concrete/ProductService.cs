using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SignalR.Business.Interfaces;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Interfaces;
using SignalR.DTO.Dtos.CategoryDtos;
using SignalR.DTO.Dtos.ProductDtos;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly SignalRContext _context;
   

        public ProductService(IRepository<Product> productRepository, SignalRContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }

        public double AvgHamburgerPrice()
        {
            return Convert.ToDouble(_context.Products.Where(x => x.Category.CategoryName.ToLower() == "hamburger").Average(x => x.Price));
        }

        public double AvgProductPrice()
        {
         return Convert.ToDouble(_context.Products.Average(x => x.Price));
        }

        public string CheapestProduct()
        {
            return _context.Products.Where(x => x.Price == (_context.Products.Min(x => x.Price))).Select(x => x.ProductName).FirstOrDefault();
        }

        public List<ResultProductWithCategoryDto> GetProductsWithCategories()
        {
          return  _context.Products.Include(x=>x.Category).Select(y=>new ResultProductWithCategoryDto
          {
              ProductId = y.ProductId,
              ProductName = y.ProductName,
              ImageUrl = y.ImageUrl,
              Price = y.Price,
              Status = y.Status,
              Description = y.Description,
              CategoryName=y.Category.CategoryName,
              
          }).ToList();
        }

        public string MostExpensiveProduct()
        {
            return _context.Products.Where(x => x.Price == (_context.Products.Max(x => x.Price))).Select(x => x.ProductName).FirstOrDefault();
        }

        public void TAdd(Product entity)
        {
            _productRepository.Add(entity);
        }

        public int TCount()
        {
            return _productRepository.Count();
        }

        public void TDelete(int id)
        {
           _productRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<Product, bool>> predicate)
        {
            return _productRepository.FilterCount(predicate);
        }

        public List<Product> TGetAll()
        {
            return _productRepository.GetAll(); 
        }

        public Product TGetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> TGetFilteredList(Expression<Func<Product, bool>> predicate)
        {
            return _productRepository.GetFilteredList(predicate);
        }

        public void TUpdate(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}
