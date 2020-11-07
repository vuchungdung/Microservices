using Common.DataAccess.Helper;
using Common.DataAccess.Helper.Interfaces;
using Common.Model.ViewModel;
using Product.Microservice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Services
{
    public class ProductService : IProductService
    {
        private readonly IDatabaseHelper _helper;

        public ProductService(IDatabaseHelper helper)
        {
            _helper = helper;
        }
        public bool Delete(int id)
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_DEL_PRODUCT", "@ID", id);
                if(dt!= null)
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

        public bool Insert(ProductViewModel model)
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_ADD_PRODUCT", "@NAME", model.Name,"@PRICE",model.Price,"@CATEGORYID",model.CategoryId);
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

        public ProductViewModel Item(int id)
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_GET_ID_PRODUCT", "@ID", id);
                if (dt != null)
                {
                    return dt.ConvertTo<ProductViewModel>().ToList().ElementAt(0);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductViewModel> Items()
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_GET_ALL_PRODUCT");
                if (dt != null)
                {
                    return dt.ConvertTo<ProductViewModel>().ToList();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ProductViewModel model)
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_UPDATE_PRODUCT", "@NAME", model.Name, "@PRICE", model.Price, "@CATEGORYID", model.CategoryId);
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
