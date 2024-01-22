using SignalR.DTO.Dtos.ProductDtos;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Interfaces
{
    public interface IProductService:IGenericService<Product>
    {

        List<ResultProductWithCategoryDto> GetProductsWithCategories();

        double AvgProductPrice();

        double AvgHamburgerPrice();

        string MostExpensiveProduct();
        string CheapestProduct();
    }
}
