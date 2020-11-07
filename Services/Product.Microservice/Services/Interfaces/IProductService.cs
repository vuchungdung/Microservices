using Common.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Services.Interfaces
{
    public interface IProductService
    {
        bool Insert(ProductViewModel model);
        bool Delete(int id);
        bool Update(ProductViewModel model);
        ProductViewModel Item(int id);
        List<ProductViewModel> Items();
    }
}
