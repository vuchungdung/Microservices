using Common.DataAccess.Helper;
using Common.DataAccess.Helper.Interfaces;
using Common.Model.ViewModel;
using Order.Microservice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Microservice.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDatabaseHelper _helper;
        public OrderService(IDatabaseHelper helper)
        {
            _helper = helper;
        }
        public bool Delete(int id)
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_DEL_ORDER", "@ID", id);
                if(dt != null)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(OrderViewModel model)
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_ADD_ORDER", "@DATE", model.CreateDate,"@NAME",model.Customer);
                if (dt != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderViewModel Item(int id)
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_GET_ID_ORDER", "@ID", id);
                if (dt != null)
                {
                    return dt.ConvertTo<OrderViewModel>().ToList().ElementAt(0);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderViewModel> Items()
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_GET_ALL_ORDER");
                if (dt != null)
                {
                    return dt.ConvertTo<OrderViewModel>().ToList();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(OrderViewModel model)
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_UPDATE_ORDER", "@DATE", model.CreateDate, "@NAME", model.Customer);
                if (dt != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
