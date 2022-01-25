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
    public interface IStockControlService
    {
         IResult StockStatusCheck(Product produc,short amount);
        IResult CriticalStockCheck(Product product);
         IResult CriticalStockCheck(Product product, short criticalAmount);

    }
}
