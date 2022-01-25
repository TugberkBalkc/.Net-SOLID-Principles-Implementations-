using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryAmountManager : ICategoryAmountService
    {
        private ICategoryService _categoryService;
        public CategoryAmountManager(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IResult CheckStatus()
        {
           var result = _categoryService.GetAll().Data.Count;
            return result >= 9
                 ? new ErrorResult(Titles.Error, Messages.CategoryAmountError)
                 : new SuccessfulResult();
        }
    }
}
