using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto_s;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryService _categoryService;
        private readonly IStockControlService _stockControlService;
        private readonly ISystemRoutingeService _routingeService;


        public ProductManager
            (IProductDal productDal,
             ICategoryService categoryService,
             IStockControlService stockControlService,
             ISystemRoutingeService routingeService
            )
        {
            _productDal = productDal;
            _categoryService = categoryService;
            _stockControlService = stockControlService;
            _routingeService = routingeService;
        }


        [SecuredOperationAspect("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
          var logicResult =  BusinessLogicEngine.Run
                (
                     CheckIfProductAmountRestrictionInCertainCategory(product.CategoryId),
                      CheckIfProductNameExists(product.ProductName),
                       CheckIfCategoryAmountExceed()
                );
           var result = BusinessLogicEngine.Decider(logicResult);

            if (!result.Success)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessfulResult(Messages.ProductAdded, Titles.TransactionSuccessful);
        }


        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessfulResult(Messages.ProductDeleted, Titles.TransactionSuccessful);
        }



        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();

            //var logicResult = BusinessLogicEngine.Run
               // (_routingeService.DisableAccess());
           // var decide = BusinessLogicEngine.Decider<List<Product>>(result, logicResult);

            return /*decide.Success == false
                ? decide
                :*/ new SuccessfulDataResult<List<Product>>(result);
        }



        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            var result = _productDal.GetAll(p=>p.CategoryId == categoryId);
            return result.Count == 0
                     ? new ErrorDataResult<List<Product>>
                     (result, Messages.ProductsCouldNotListedFilter, Titles.TransactionUnsuccessful)
                     : new SuccessfulDataResult<List<Product>>
                     (result, Messages.ProductsListedFilter, Titles.TransactionSuccessful);
        }


        public IDataResult<List<Product>> GetAllByProductName(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName);
            return result.Count == 0
                     ? new ErrorDataResult<List<Product>>
                     (result, Messages.ProductsCouldNotListedFilter, Titles.TransactionUnsuccessful)
                     : new SuccessfulDataResult<List<Product>>
                     (result, Messages.ProductsListedFilter, Titles.TransactionSuccessful);
        }


        public IDataResult<List<Product>> GetAllByUnitPrice(decimal minPrice)
        {
            var result = _productDal.GetAll(p => p.UnitPrice >= minPrice);
            return result.Count == 0
                     ? new ErrorDataResult<List<Product>>
                     (result, Messages.ProductsCouldNotListedFilter, Titles.TransactionUnsuccessful)
                     : new SuccessfulDataResult<List<Product>>
                     (result, Messages.ProductsListedFilter, Titles.TransactionSuccessful);
        }


        public IDataResult<List<Product>> GetAllByUnitPrice(decimal minPrice, decimal maxPrice)
        {
            var result = _productDal.GetAll(p => p.UnitPrice >= minPrice && p.UnitPrice <=maxPrice);
            return result.Count == 0
                     ? new ErrorDataResult<List<Product>>
                     (result, Messages.ProductsCouldNotListedFilter, Titles.TransactionUnsuccessful)
                     : new SuccessfulDataResult<List<Product>>
                     (result, Messages.ProductsListedFilter, Titles.TransactionSuccessful);
        }


        public IDataResult<List<Product>> GetAllByUnitsInStock(short minStock)
        {
            var result = _productDal.GetAll(p => p.UnitsInStock >= minStock);
            return result.Count == 0
                     ? new ErrorDataResult<List<Product>>
                     (result, Messages.ProductsCouldNotListedFilter, Titles.TransactionUnsuccessful)
                     : new SuccessfulDataResult<List<Product>>
                     (result, Messages.ProductsListedFilter, Titles.TransactionSuccessful);
        }


        public IDataResult<List<Product>> GetAllByUnitsInStock(short minStock, short maxStock)
        {
            var result = _productDal.GetAll(p => p.UnitsInStock >= minStock && p.UnitPrice <= maxStock);
            return result.Count == 0
                     ? new ErrorDataResult<List<Product>>
                     (result, Messages.ProductsCouldNotListedFilter, Titles.TransactionUnsuccessful)
                     : new SuccessfulDataResult<List<Product>>
                     (result, Messages.ProductsListedFilter, Titles.TransactionSuccessful);
        }


        public IDataResult<Product> GetById(int id)
        {
            var result = _productDal.Get(p => p.ProductId == id);
            return result == null
                ? new ErrorDataResult<Product>(result, Messages.ProductCouldNotRecievedFilter, Titles.TransactionUnsuccessful)
                : new SuccessfulDataResult<Product>(result, Messages.ProductRecievedFilter, Titles.TransactionSuccessful);

        }


        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            var result = _productDal.GetProductDetails();

            return result.Count == 0
                ? new ErrorDataResult<List<ProductDetailDto>>(result, Messages.ProductsCouldNotListed, Titles.TransactionUnsuccessful)
                : new SuccessfulDataResult<List<ProductDetailDto>>(result, Messages.ProductsListed, Titles.TransactionSuccessful);
        }


        public IResult SellProduct(Product product, short amount)
        {
            var logicResults = BusinessLogicEngine.Run
                (_stockControlService.StockStatusCheck(product, amount),
                 _stockControlService.CriticalStockCheck(product));
                 
            var stockStatus = _stockControlService.StockStatusCheck(product, amount);
            if (stockStatus.Success)
            {
                product.UnitsInStock -= amount;
                this.Update(product);
                var criticalStockAlert = _stockControlService.CriticalStockCheck(product,50);
              
                return criticalStockAlert.Success == false
                    ? new SuccessfulResult(Titles.SoldSuccessfully, amount.ToString() + " " + Messages.ProductsSold+" " +criticalStockAlert.Message)
                    : new SuccessfulResult(Titles.SoldSuccessfully,amount.ToString() +" "+ Messages.ProductsSold );
            }
            else
            {
                return new ErrorResult(stockStatus.Title,Messages.ProductsCouldNotSold + " " + stockStatus.Message);
            }
        }


        public IResult Update(Product product)
        {
            BusinessLogicEngine.Run
                (
                    CheckIfProductAmountRestrictionInCertainCategory(product.CategoryId),
                    CheckIfProductNameExists(product.ProductName)
                );
                _productDal.Update(product);
                return new SuccessfulResult(Messages.ProductUpdated, Titles.TransactionSuccessful);
        }




        private IResult CheckIfProductAmountRestrictionInCertainCategory(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId);
            return result.Count >= 10
                ? new ErrorResult(Titles.Error,Messages.ProductAmountInCertainCategoryError)
                : new SuccessfulResult();
        }


        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p=>p.ProductName == productName).Count;
            return result == 0
                ? new SuccessfulResult()
                : new ErrorResult(Titles.Error,Messages.ProductNameAlreadyExists);
        } 


        private IResult CheckIfCategoryAmountExceed()
        {
            var resut = _categoryService.GetCountOfCategories();
            return resut >= 9
                ? new ErrorResult(Titles.Error, Messages.CategoryAmountError)
                : new SuccessfulResult();
        }

    }
}
