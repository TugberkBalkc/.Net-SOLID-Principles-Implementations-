using System;
using Business.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Results.Result;
using Business.Constants;
using Core.Utilities.Results.DataResult;

namespace Business.Concrete
{
    public class StockControlManager : IStockControlService
    {
        public IResult CriticalStockCheck(Product product, short criticalAmount = 0)
        {
            if (product.UnitsInStock > criticalAmount)
            {
                return new SuccessfulResult();
            }
            else
            {
                return new ErrorResult(Titles.CriticalStock, Messages.CriticalStockAmount);
            }
        }

        public IResult CriticalStockCheck(Product product)
        {
            return new SuccessfulResult();
        }

        public IResult StockStatusCheck(Product product,short amount)
        {
            if (product.UnitsInStock-amount >= 0)
            {
                return new SuccessfulResult();
            }
            else
            {
                return new ErrorResult(Titles.NotEnoughStocks, Messages.NotEnoughStock);
            }
        }
        
    }
}
