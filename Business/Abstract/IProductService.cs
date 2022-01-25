using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result;
using Entities.Concrete;
using Entities.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IDataResult<List<Product>> GetAll();

        IDataResult<List<Product>> GetAllByCategoryId(int categoryId);

        IDataResult<List<Product>> GetAllByUnitsInStock(short minStock);
        IDataResult<List<Product>> GetAllByUnitsInStock(short minStock ,short maxStock);

        IDataResult<List<Product>> GetAllByUnitPrice(decimal minPrice);
        IDataResult<List<Product>> GetAllByUnitPrice(decimal minPrice, decimal maxPrice);

        IDataResult<List<Product>> GetAllByProductName(string productName);


        IDataResult<Product> GetById(int id);

        IResult SellProduct(Product product, short Amount);
    }
}
