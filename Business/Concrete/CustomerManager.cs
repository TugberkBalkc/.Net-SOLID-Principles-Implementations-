using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessfulResult(Messages.CustomerAdded, Titles.TransactionSuccessful);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessfulResult(Messages.CustomerDeleted, Titles.TransactionSuccessful);
        }

        public IDataResult<List<Customer>> GetAll()
        {
           var result =  _customerDal.GetAll();
            return result.Count == 0
                ? new ErrorDataResult<List<Customer>>(result,Messages.CustomersCouldNotListed, Titles.TransactionUnsuccessful)
                : new SuccessfulDataResult<List<Customer>>(result,Messages.CustomersListed, Titles.TransactionSuccessful);
        }

        public IDataResult<List<Customer>> GetAllByCityName(string cityName)
        {
            var result = _customerDal.GetAll(c=>c.City == cityName);
            return result.Count == 0
                ? new ErrorDataResult<List<Customer>>(result, Messages.CustomersCouldNotListedFilter, Titles.TransactionUnsuccessful)
                : new SuccessfulDataResult<List<Customer>>(result, Messages.CustomersListedFilter, Titles.TransactionSuccessful);
        }
        
        public IDataResult<List<Customer>> GetAllByCompanyName(string companyName)
        {
            var result = _customerDal.GetAll(c => c.CompanyName == companyName);
            return result.Count == 0
                ? new ErrorDataResult<List<Customer>>(result, Messages.CustomersCouldNotListedFilter, Titles.TransactionUnsuccessful)
                : new SuccessfulDataResult<List<Customer>>(result, Messages.CustomersListedFilter, Titles.TransactionSuccessful);
        }

        public IDataResult<List<Customer>> GetAllByContactName(string contactName)
        {
            var result = _customerDal.GetAll(c => c.ContactName == contactName);
            return result.Count == 0
                ? new ErrorDataResult<List<Customer>>(result, Messages.CustomersCouldNotListedFilter, Titles.TransactionUnsuccessful)
                : new SuccessfulDataResult<List<Customer>>(result, Messages.CustomersListedFilter, Titles.TransactionSuccessful);
        }

        public IDataResult<Customer> GetById(string id)
        {
            var result = _customerDal.Get(c => c.CustomerId == id);
            return result == null
              ? new ErrorDataResult<Customer>(result, Messages.CustomerCouldNotRecievedFilter, Titles.TransactionUnsuccessful)
              : new SuccessfulDataResult<Customer>(result, Messages.CustomerRecievedFilter, Titles.TransactionSuccessful);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessfulResult(Titles.TransactionSuccessful, Messages.CustomerUpdated);
        }
    }
}
