using Common.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Microservice.Services.Interfaces
{
    public interface IOrderService
    {
        bool Insert(OrderViewModel model);
        bool Delete(int id);
        bool Update(OrderViewModel model);
        OrderViewModel Item(int id);
        List<OrderViewModel> Items();
    }
}
