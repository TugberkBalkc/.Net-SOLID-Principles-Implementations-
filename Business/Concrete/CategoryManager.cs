using Business.Abstract;
using DataAccess.Abstract;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        public ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessfulResult(Titles.TransactionSuccessful, Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessfulResult(Titles.TransactionSuccessful, Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            return result.Count == 0
                ? new ErrorDataResult<List<Category>>(result, Messages.CategoriesCouldNotListed, Titles.TransactionUnsuccessful)
                : new SuccessfulDataResult<List<Category>>(result, Messages.CategoriesListed, Titles.TransactionSuccessful);
        }

        public IDataResult<List<Category>> GetAllByDescription(string description)
        {
            var result =_categoryDal.GetAll(c => c.Description.Contains(description));
            return result.Count == 0
                ? new ErrorDataResult<List<Category>>(result, Messages.CategoriesCouldNotListedFilter, Titles.TransactionUnsuccessful)
                : new SuccessfulDataResult<List<Category>>(result, Messages.CategoriesListedFilter, Titles.TransactionSuccessful);
        }

        public IDataResult<Category> GetById(int id)
        {
            var result = _categoryDal.Get(c => c.CategoryId == id);
            return result == null
                ? new ErrorDataResult<Category>(result,Messages.CategroyCouldNotRecievedFilter, Titles.TransactionUnsuccessful)
                : new SuccessfulDataResult<Category>(result,Messages.CategoryRecievedFilter, Titles.TransactionSuccessful);
        }

        public int GetCountOfCategories()
        {
            return _categoryDal.GetAll().Count;
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessfulResult(Titles.TransactionSuccessful, Messages.CategoryUpdated); 
        }
    }
}
