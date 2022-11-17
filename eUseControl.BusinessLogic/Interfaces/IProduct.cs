using eUseControl.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface IProduct
     {
          List<ProductData> GetProductList();
          List<ProductData> GetOrdersByUser(int userId);
          List<ProductData> GetOrdersByUser();
     }
}
