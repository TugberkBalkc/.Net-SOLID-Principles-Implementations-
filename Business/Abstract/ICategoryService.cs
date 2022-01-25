using Core.Utilities.Results.Result;
using Core.Utilities.Results.DataResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        int GetCountOfCategories();

        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);


        IDataResult<List<Category>> GetAll();

        IDataResult<List<Category>> GetAllByDescription(string description);


        IDataResult<Category> GetById(int id);
    }
}
