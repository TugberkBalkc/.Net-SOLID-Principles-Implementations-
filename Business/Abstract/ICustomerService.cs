using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);


        IDataResult<List<Customer>> GetAll();

        IDataResult<List<Customer>> GetAllByContactName(string contactName);

        IDataResult<List<Customer>> GetAllByCompanyName(string companyName);
        IDataResult<List<Customer>> GetAllByCityName(string cityName);


        IDataResult<Customer> GetById(string id); // CustomerId is NVarchar Type in Northwind Database
       

    }
}
